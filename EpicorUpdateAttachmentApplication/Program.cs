using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpicorUpdateAttachmentApplication
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// instantiate Epicor Facade class 
			EpicorFacade epicor = new EpicorFacade();

			// application template stuff
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UpdateAttachmentForm(epicor));

			// revise Application.ApplicationExit event to make sure we kill our licensed session before the program exits (for any reason)
			Application.ApplicationExit += new EventHandler(epicor.OnApplicationExit);
		}

	}
}
