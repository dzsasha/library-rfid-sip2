namespace Marc.SIP2
{
	partial class InstallerSIP2
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceInstallerSIP2 = new System.ServiceProcess.ServiceInstaller();
			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
			// 
			// serviceInstallerSIP2
			// 
			this.serviceInstallerSIP2.Description = "Служба SIP2-сервер";
			this.serviceInstallerSIP2.DisplayName = "SIP2-Server";
			this.serviceInstallerSIP2.ServiceName = "Marc.Service.SIP2";
			this.serviceInstallerSIP2.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// serviceProcessInstaller1
			// 
			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstaller1.Password = null;
			this.serviceProcessInstaller1.Username = null;
			// 
			// InstallerSIP2
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstallerSIP2,
            this.serviceProcessInstaller1});

		}

		#endregion

		private System.ServiceProcess.ServiceInstaller serviceInstallerSIP2;
		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;

	}
}