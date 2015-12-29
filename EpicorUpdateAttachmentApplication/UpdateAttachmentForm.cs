using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Epicor.Mfg.Core;
using Epicor.Mfg.Common;
using Epicor.Mfg.Lib;
using Epicor.Mfg.BO;
using Epicor.Mfg.Shared;

namespace EpicorUpdateAttachmentApplication
{
	/**
	 * This class demonstrates how to use the PartRevSearch, Attachment, and XFileRef Business Objects 
	 * to list and create attachments from outside of Epicor. There is almost no error handling or encapsulation
	 * so I do not recommend using this in production in its current state. Hopefully it will familiarize you with
	 * the procedure of using Epicor BO's to manipulate the ERP from external systems.
	 */
	public partial class UpdateAttachmentForm : Form
	{
		EpicorFacade epicor;

		public UpdateAttachmentForm(EpicorFacade efInstance)
		{
			this.epicor = efInstance;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			InitializeComponent();
			toolStripProgressBar1.Step = 20;
			toolStripStatusLabel1.Text = EpicorFacade.sessionCredentials();
			dataGridViewAttachments.AutoGenerateColumns = false;
			openFileDialog1.FileOk += openFileDialog1_FileOk;
			textBoxPartNumber.Validated += textBoxPartNumberValidated;
			listBoxStatusUpdates.SelectedIndexChanged += ListBoxStatusUpdates_SelectedIndexChanged;
		}

		private void ListBoxStatusUpdates_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.listBoxStatusUpdates.SelectedIndex = this.listBoxStatusUpdates.Items.Count - 1;
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			textBoxNewAttachmentPath.Text = openFileDialog1.FileName.ToString();
		}

		private void buttonListAttachments_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedValue == null)
			{
				MessageBoxEx.Show(this, "Part Number could not be found", "Search");
				return;
			}

			// show the progress bar
			toolStripProgressBar1.Visible = true;
			toolStripProgressBar1.PerformStep();

			// define parameters for query to Attachment BO
			string partNumber = textBoxPartNumber.Text.ToString();
			string revisionLevel = comboBox1.SelectedValue.ToString();
			string whereClause = "key1 = '" + partNumber + "' AND key2 = '" + revisionLevel + "'";
			bool morePages = false;
			toolStripProgressBar1.PerformStep();

			// erase any columns left over in the DataGridView
			dataGridViewAttachments.Columns.Clear();

			// grab list of attachments and assign them to DataGridView
			DataTable attachmentList = epicor.AttachmentBO.GetRows(whereClause, 0, 0, out morePages).Tables[0];
			toolStripProgressBar1.PerformStep();

			dataGridViewAttachments.DataSource = attachmentList;
			dataGridViewAttachments.Columns.Add("xfiledesc", "Description");
			dataGridViewAttachments.Columns["xfiledesc"].DataPropertyName = "XFileRefXFileDesc";
			toolStripProgressBar1.PerformStep();

			dataGridViewAttachments.Columns.Add("xfilename", "Filename");
			dataGridViewAttachments.Columns["xfilename"].DataPropertyName = "XFileRefXFileName";
			toolStripProgressBar1.PerformStep();

			toolStripProgressBar1.Visible = false;
		}

		private void buttonOpenFileDialog_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			listBoxStatusUpdates.Items.Add("initializing...");

			string partNumber = textBoxPartNumber.Text.ToString();
			string revisionLevel = comboBox1.SelectedValue.ToString();
			string whereClause = "key1 = '" + partNumber + "' AND key2 = '" + revisionLevel + "'";
			string filePath = textBoxNewAttachmentPath.Text.ToString();
			string fileDesc = textBoxFileDesc.Text.ToString();
			string fileName = System.IO.Path.GetFileName(filePath);
			bool morePages = false;

			listBoxStatusUpdates.Items.Add("creating new XFileRefDataSet");
			XFileRefDataSet newAttachmentFileRef = new XFileRefDataSet();
			epicor.XFileRefBO.GetNewXFileRef(newAttachmentFileRef);

			listBoxStatusUpdates.Items.Add("inserted new row into dataset");
			DataTable newAttachmentFileRefDataTable = newAttachmentFileRef.Tables[0];
			DataRow newAttachmentFileRefRow = newAttachmentFileRefDataTable.Rows[newAttachmentFileRefDataTable.Rows.Count - 1];

			newAttachmentFileRefRow.BeginEdit();
			newAttachmentFileRefRow.SetField("Company", "Mass");
			newAttachmentFileRefRow.SetField("XFileName", filePath);
			newAttachmentFileRefRow.SetField("XFileDesc", fileDesc);
			newAttachmentFileRefRow.SetField("BaseFileName", fileName);
			newAttachmentFileRefRow.EndEdit();

			listBoxStatusUpdates.Items.Add("finished populating fields in new row - calling Update() method!");
			try	{
				epicor.XFileRefBO.Update(newAttachmentFileRef);
			} catch (Exception ex) {
				listBoxStatusUpdates.Items.Add("EXCEPTION:" + ex.Message.ToString());
			}

			listBoxStatusUpdates.Items.Add("XFileRefNum of new row is: " + newAttachmentFileRefRow.Field<Int32>("XFileRefNum").ToString());
			// we need to count the number of attachments since the BO won't do that for us. 
			int nrows = epicor.AttachmentBO.GetRows(whereClause, 0, 0, out morePages).Tables[0].Rows.Count;
			AttachmentDataSet newAttachmentDataSet = new AttachmentDataSet();

			listBoxStatusUpdates.Items.Add("inserting new row in AttachmentDataSet");
			epicor.AttachmentBO.GetNewXFileAttch(newAttachmentDataSet, "PartRev", partNumber, revisionLevel, "", "", "", "");
			DataTable newAttachmentDataTable = newAttachmentDataSet.Tables[0];
			DataRow lastrow = newAttachmentDataTable.Rows[newAttachmentDataTable.Rows.Count - 1];
			// tested – this works, adds new attachment using XFileRefNum
			lastrow.BeginEdit();
			lastrow.SetField("Company", "Mass");
			lastrow.SetField("AttachNum", nrows + 1);
			lastrow.SetField("XFileRefNum", newAttachmentFileRefRow.Field<Int32>("XFileRefNum").ToString());
			lastrow.EndEdit();

			listBoxStatusUpdates.Items.Add("calling Update() method!");

			try {
				epicor.AttachmentBO.Update(newAttachmentDataSet);
			} catch (Exception ex) {
				listBoxStatusUpdates.Items.Add("EXCEPTION:" + ex.Message.ToString());
			}
		}

		private void textBoxPartNumberValidated(object sender, EventArgs e)
		{
			string partNumber = textBoxPartNumber.Text.ToString();
			bool morePages = false;
			// this bite of spaghetti is converting a column in the table returned by GetRows to a List<string>
			DataTable dataTable = epicor.PartRevSearchBO.GetRows("PartNum='" + partNumber + "'", 0, 1, out morePages).Tables[0];
			List<string> revisionList = dataTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("RevisionNum")).ToList<string>();
			comboBox1.DataSource = revisionList;
			// if the combobox's text field had a value from a previous list, it will need to be cleared if the new list has no items
			if (revisionList.Count == 0)
				comboBox1.Text = "";
		}
	}
}
