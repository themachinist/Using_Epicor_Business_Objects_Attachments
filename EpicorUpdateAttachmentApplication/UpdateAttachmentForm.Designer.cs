namespace EpicorUpdateAttachmentApplication
{
    partial class UpdateAttachmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.textBoxNewAttachmentPath = new System.Windows.Forms.TextBox();
			this.buttonOpenFileDialog = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonListAttachments = new System.Windows.Forms.Button();
			this.textBoxPartNumber = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.dataGridViewAttachments = new System.Windows.Forms.DataGridView();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBoxFileDesc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxStatusUpdates = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttachments)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(7, 71);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(76, 23);
			this.buttonUpdate.TabIndex = 0;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// textBoxNewAttachmentPath
			// 
			this.textBoxNewAttachmentPath.Location = new System.Drawing.Point(7, 45);
			this.textBoxNewAttachmentPath.Name = "textBoxNewAttachmentPath";
			this.textBoxNewAttachmentPath.Size = new System.Drawing.Size(184, 20);
			this.textBoxNewAttachmentPath.TabIndex = 1;
			// 
			// buttonOpenFileDialog
			// 
			this.buttonOpenFileDialog.Location = new System.Drawing.Point(197, 43);
			this.buttonOpenFileDialog.Name = "buttonOpenFileDialog";
			this.buttonOpenFileDialog.Size = new System.Drawing.Size(58, 23);
			this.buttonOpenFileDialog.TabIndex = 2;
			this.buttonOpenFileDialog.Text = "File...";
			this.buttonOpenFileDialog.UseVisualStyleBackColor = true;
			this.buttonOpenFileDialog.Click += new System.EventHandler(this.buttonOpenFileDialog_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.dataGridViewAttachments);
			this.groupBox1.Controls.Add(this.buttonListAttachments);
			this.groupBox1.Controls.Add(this.textBoxPartNumber);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(648, 220);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Attachments";
			// 
			// buttonListAttachments
			// 
			this.buttonListAttachments.Location = new System.Drawing.Point(7, 62);
			this.buttonListAttachments.Name = "buttonListAttachments";
			this.buttonListAttachments.Size = new System.Drawing.Size(103, 23);
			this.buttonListAttachments.TabIndex = 7;
			this.buttonListAttachments.Text = "List Attachments";
			this.buttonListAttachments.UseVisualStyleBackColor = true;
			this.buttonListAttachments.Click += new System.EventHandler(this.buttonListAttachments_Click);
			// 
			// textBoxPartNumber
			// 
			this.textBoxPartNumber.Location = new System.Drawing.Point(7, 36);
			this.textBoxPartNumber.Name = "textBoxPartNumber";
			this.textBoxPartNumber.Size = new System.Drawing.Size(83, 20);
			this.textBoxPartNumber.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Enter a part number:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBoxStatusUpdates);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBoxFileDesc);
			this.groupBox2.Controls.Add(this.textBoxNewAttachmentPath);
			this.groupBox2.Controls.Add(this.buttonOpenFileDialog);
			this.groupBox2.Controls.Add(this.buttonUpdate);
			this.groupBox2.Location = new System.Drawing.Point(12, 239);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(648, 112);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Add Attachment";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 354);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(672, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			this.toolStripProgressBar1.Visible = false;
			// 
			// dataGridViewAttachments
			// 
			this.dataGridViewAttachments.AllowUserToAddRows = false;
			this.dataGridViewAttachments.AllowUserToDeleteRows = false;
			this.dataGridViewAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAttachments.Location = new System.Drawing.Point(149, 19);
			this.dataGridViewAttachments.Name = "dataGridViewAttachments";
			this.dataGridViewAttachments.ReadOnly = true;
			this.dataGridViewAttachments.Size = new System.Drawing.Size(493, 195);
			this.dataGridViewAttachments.TabIndex = 8;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(96, 36);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(47, 21);
			this.comboBox1.TabIndex = 9;
			// 
			// textBoxFileDesc
			// 
			this.textBoxFileDesc.Location = new System.Drawing.Point(75, 19);
			this.textBoxFileDesc.Name = "textBoxFileDesc";
			this.textBoxFileDesc.Size = new System.Drawing.Size(116, 20);
			this.textBoxFileDesc.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Description:";
			// 
			// listBoxStatusUpdates
			// 
			this.listBoxStatusUpdates.FormattingEnabled = true;
			this.listBoxStatusUpdates.Location = new System.Drawing.Point(261, 19);
			this.listBoxStatusUpdates.Name = "listBoxStatusUpdates";
			this.listBoxStatusUpdates.Size = new System.Drawing.Size(381, 82);
			this.listBoxStatusUpdates.TabIndex = 5;
			// 
			// UpdateAttachmentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 376);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "UpdateAttachmentForm";
			this.Text = "Epicor Attachment Tool";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttachments)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxNewAttachmentPath;
        private System.Windows.Forms.Button buttonOpenFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonListAttachments;
        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.DataGridView dataGridViewAttachments;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxFileDesc;
		private System.Windows.Forms.ListBox listBoxStatusUpdates;
	}
}

