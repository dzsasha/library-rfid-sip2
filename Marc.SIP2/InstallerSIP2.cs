using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace Marc.SIP2
{
	[RunInstaller(true)]
	public partial class InstallerSIP2 : System.Configuration.Install.Installer
	{
		public InstallerSIP2()
		{
			InitializeComponent();
		}
	}
}
