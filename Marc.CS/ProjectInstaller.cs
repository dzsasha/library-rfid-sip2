using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Management;
using System.Text;


namespace Marc.CS
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
		}

		protected override void OnBeforeInstall(IDictionary savedState)
		{
			StringBuilder path = new StringBuilder(Context.Parameters["assemblypath"]);
			if (path[0] != '"')
			{
				path.Insert(0, '"');
				path.Append('"');
			}
			path.Append(" /service");
			Context.Parameters["assemblypath"] = path.ToString();
			base.OnBeforeInstall(savedState);
		}
	}
}
