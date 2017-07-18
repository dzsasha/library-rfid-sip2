using System.Configuration;
using System.ServiceProcess;

namespace IS.SIP2.CS
{
	public partial class ServiceSip2 : ServiceBase
	{
		private Sip2Server _server = null;
		public ServiceSip2(ServiceSection config)
		{
			_server = new Sip2Server(config);
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			_server.Start();
		}

		protected override void OnStop()
		{
			_server.Stop();
		}
	}
}
