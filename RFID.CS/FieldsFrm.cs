using IS.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS.RFID.CS
{
    public partial class FieldsFrm : Form
    {
        public FieldsFrm(IField[] fields)
        {
            _fields = fields;
            InitializeComponent();
            clmnKey.DataPropertyName = "Name";
            clmnValue.DataPropertyName = "Value";
            dataGrid.DataSource = _fields;
        }
        private IField[] _fields = null;
    }
}
