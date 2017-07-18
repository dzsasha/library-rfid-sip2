using System;
using System.IO;
using System.Windows.Forms;
using IS.Interface.RFID;
using IS.RFID.Service;

namespace IS.RFID.CS
{
	public partial class ModelFrm : Form
	{
		public ModelFrm()
		{
			InitializeComponent();
			foreach (ReaderImpl reader in ServiceImpl.Readers)
			{
				reader.InitReader(reader.Params);
				reader.OnError += new ErrorEventHandler(reader_OnError);
				TabPage tabPage = new TabPage(reader.Name);
				tabPage.Controls.Add(new TypeCtrl(reader as IReader) { Dock = DockStyle.Fill });
				tabControl.TabPages.Add(tabPage);
			}
		}

		void reader_OnError(object sender, ErrorEventArgs e)
		{
			MessageBox.Show(e.GetException().Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
				MessageBoxOptions.DefaultDesktopOnly);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void notifyIcon1_Click(object sender, EventArgs e)
		{
			Show();
		}
	}
}
