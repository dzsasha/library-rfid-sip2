using System;
using System.Diagnostics;
using System.Resources;
using System.ServiceProcess;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using IS.RFID.Service;

namespace IS.RFID.CS
{
	public partial class ServiceRfid : ServiceBase
	{
		public ServiceRfid()
		{
			InitializeComponent();
		}

		private static ServiceHost _myServiceHost	 = null;

		protected override void OnStart(string[] args)
		{
			if (_myServiceHost != null)
			{
				if (_myServiceHost.State == CommunicationState.Opened) _myServiceHost.Close();
			}

			try
			{
				_myServiceHost = new ServiceHost(typeof(ServiceImpl));
				_myServiceHost.Open();
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry(this.ServiceName, String.Format("Error: {0}!!!", ex.Message));
			}
		}

		protected override void OnStop()
		{
			if (_myServiceHost != null)
			{
				_myServiceHost.Close();
				_myServiceHost = null;
			}
		}
	}
}
