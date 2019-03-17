using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS {
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer {
        public ProjectInstaller() {
            InitializeComponent();
        }
        protected override void OnBeforeInstall(IDictionary savedState) {
            StringBuilder path = new StringBuilder(Context.Parameters["assemblypath"]);
            if (path[0] != '"') {
                path.Insert(0, '"');
                path.Append('"');
            }
            path.Append(" /service");
            Context.Parameters["assemblypath"] = path.ToString();
            base.OnBeforeInstall(savedState);
        }
    }
}
