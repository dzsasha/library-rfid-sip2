using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Marc.SIP2
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
					new ServiceSIP2()
				};
				ServiceBase.Run(servicesToRun);
			}
			else
			{
				
			}
		}
	}
}
