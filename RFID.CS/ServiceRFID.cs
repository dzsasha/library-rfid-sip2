using System;
using System.ServiceProcess;
using System.ServiceModel;
using IS.RFID.Service;
using IS.Interface;

namespace IS.RFID.CS {
    public partial class ServiceRfid : ServiceBase {
        public ServiceRfid() {
            InitializeComponent();
        }

        private static ServiceHost _myServiceHost = null;

        protected override void OnStart(string[] args) {
            if (_myServiceHost != null) {
                if (_myServiceHost.State == CommunicationState.Opened) _myServiceHost.Close();
            }

            try {
                _myServiceHost = new ServiceHost(typeof(ServiceImpl));
                _myServiceHost.Open();
            } catch (Exception ex) {
                Log.For(this).Error(ex);
            }
        }

        protected override void OnStop() {
            try {
                if (_myServiceHost != null) {
                    _myServiceHost.Close();
                    _myServiceHost = null;
                }
            } catch (Exception ex) {
                Log.For(this).Error(ex);
            }
        }
    }
}
