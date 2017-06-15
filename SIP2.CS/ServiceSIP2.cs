using System.Configuration;
using System.ServiceProcess;

namespace InformSystema.SIP2.CS
{
	public partial class ServiceSip2 : ServiceBase
	{
		public ServiceSip2(ServiceSection config)
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
		}

		protected override void OnStop()
		{
		}
	}
}
