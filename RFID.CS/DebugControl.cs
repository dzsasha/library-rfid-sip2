using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IS.Interface;
using IS.RFID.Service;

namespace IS.RFID.CS {
    public partial class DebugControl : UserControl {
        private static ServiceHost _myServiceHost = null;
        public DebugControl() {
            InitializeComponent();
            try {
                _myServiceHost = new ServiceHost(typeof(ServiceImpl));
                _myServiceHost.Open();
            } catch (Exception ex) {
                Log.For(this).Error(ex);
            }

        }

        public new void Dispose()
        {
            _myServiceHost.Close();
            base.Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e) {

        }
    }
}
