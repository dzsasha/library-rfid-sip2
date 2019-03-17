using System;
using System.Windows.Forms;
using IS.Interface.RFID;

namespace IS.RFID.CS {
    public partial class ModelCtrl : UserControl {
        public string Id = "";
        private IModel _model = null;
        public IModel Model {
            get { return _model; }
            internal set {
                _model = value;
                IModelEx modelEx = Model as IModelEx;
                if (modelEx != null) {
                    dataGrid.DataSource = modelEx.Fields;
                    cbType.SelectedItem = (Model as IModelEx).Type;
                } else {
                    dataGrid.DataSource = null;
                }
                btnWrite.Enabled = cbType.Enabled = (Model is IModelEx);
            }
        }

        public ModelCtrl() {
            InitializeComponent();
            cbType.SelectedIndexChanged += new EventHandler(cbType_SelectedIndexChanged);
            cbType.DataSource = Enum.GetValues(typeof(TypeItem));
            clmnKey.DataPropertyName = "Name";
            clmnValue.DataPropertyName = "Value";
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e) {
            if (sender is ComboBox && Model is IModelEx) {
                (Model as IModelEx).Type = (TypeItem)(sender as ComboBox).SelectedItem;
            }
        }

        private void btnRead_Click(object sender, EventArgs e) {
            if (_model is ModelImpl) {
                try {
                    (_model as ModelImpl).Read(Id);
                } catch (Exception) {
                    _model = null;
                }
                IModelEx modelEx = _model as IModelEx;
                dataGrid.DataSource = (modelEx != null) ? modelEx.Fields : null;
            }
        }

        private void btnWrite_Click(object sender, EventArgs e) {
            if (_model is ModelImpl) {
                _model.Write();
            }
        }
    }
}
