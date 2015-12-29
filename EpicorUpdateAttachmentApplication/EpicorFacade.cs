using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Epicor.Mfg.Common;
using Epicor.Mfg.Core;
using Epicor.Mfg.BO;
using Epicor.Mfg.Lib;

namespace EpicorUpdateAttachmentApplication
{
	/**
	 * this class should have implemented methods for UpdateAttachmentForm to use to create/manipulate the attachment datasets
	 */
	public class EpicorFacade
	{
		private Session session;
		private SessionMod sessionMod;
		private Attachment attachmentBO;
		private PartRevSearch partRevSearchBO;
		private XFileRef xFileRefBO;

		public static string user = "winslow";
		public static string pass = "yourfancypasswordgoeshere";
		public static string uncpath = "AppServerDC://E9:9421";

		public Session Session
		{
			get
			{
				return session;
			}

			set
			{
				session = value;
			}
		}

		public SessionMod SessionMod
		{
			get
			{
				return sessionMod;
			}

			set
			{
				sessionMod = value;
			}
		}

		public Attachment AttachmentBO
		{
			get
			{
				return attachmentBO;
			}

			set
			{
				attachmentBO = value;
			}
		}

		public PartRevSearch PartRevSearchBO
		{
			get
			{
				return partRevSearchBO;
			}

			set
			{
				partRevSearchBO = value;
			}
		}

		public XFileRef XFileRefBO
		{
			get
			{
				return xFileRefBO;
			}

			set
			{
				xFileRefBO = value;
			}
		}

		public EpicorFacade()
		{
			this.Session	= EpicorFacade.createEpicorSession();
			this.SessionMod = new SessionMod(this.Session.ConnectionPool);
			this.PartRevSearchBO = new PartRevSearch(this.Session.ConnectionPool);
			this.AttachmentBO = new Attachment(this.Session.ConnectionPool);
			this.XFileRefBO = new XFileRef(this.Session.ConnectionPool);
		}

		public static Session createEpicorSession()
		{
			return new Session(EpicorFacade.user, EpicorFacade.pass, EpicorFacade.uncpath, Session.LicenseType.Default);
		}

		// return a human readable string with user credentials
		public static string sessionCredentials()
		{
			return EpicorFacade.uncpath + "/?user=" + EpicorFacade.user;
		}

		public void OnApplicationExit(object sender, EventArgs e)
		{
			this.Session.Dispose();
		}
	}
}
