using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Forms;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
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
					new ServiceSip2((ServiceSection) ConfigurationManager.GetSection(ServiceSection.SectionName))
				};
				ServiceBase.Run(servicesToRun);
			}
			else if (args.Length > 0 && args[0] == "/server")
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ServerLog((ServiceSection) ConfigurationManager.GetSection(ServiceSection.SectionName)));
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new ClientSIP());
			}
		}
	}
}
