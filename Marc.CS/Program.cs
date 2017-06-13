using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace Marc.CS
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			if (args.Length > 0 && args[0] == "/service")
			{
				ServiceBase[] servicesToRun = new ServiceBase[]
				{
					new ServiceRfid()
				};
				ServiceBase.Run(servicesToRun);
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ModelFrm());
			}
		}
	}
}
