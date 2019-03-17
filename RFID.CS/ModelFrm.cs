using System;
using System.IO;
using System.Windows.Forms;
using IS.Interface.RFID;
using IS.RFID.Service;
using System.Reflection;
using IS.Interface;
using System.Configuration;

namespace IS.RFID.CS {
    public partial class ModelFrm : Form {
        public ModelFrm(Boolean isDebug) {
            InitializeComponent();
            try {
                foreach (ReaderImpl reader in ServiceImpl.Readers) {
                    if (reader.InitReader(reader.Params)) {
                        reader.OnError += new ErrorEventHandler(reader_OnError);
                        TabPage tabPage = new TabPage(reader.Name);
                        try {
                            tabPage.Controls.Add(new TypeCtrl(reader as IReader) { Dock = DockStyle.Fill });
                        } catch (Exception) {
                            // ignored
                        }
                        tabControl.TabPages.Add(tabPage);
                    }
                }

                if (isDebug) {
                    TabPage tabPage = new TabPage("Debug");
                    try {
                        tabPage.Controls.Add(new DebugControl() { Dock = DockStyle.Fill });
                    } catch (Exception) {
                        // ignored
                    }

                    tabControl.TabPages.Add(tabPage);
                }
            } catch (Exception) {
                // ignored
            }
        }

        void reader_OnError(object sender, ErrorEventArgs e) {
            MessageBox.Show(e.GetException().Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void notifyIcon1_Click(object sender, EventArgs e) {
            Show();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            using (OpenFileDialog openDllFile = new OpenFileDialog()) {
                openDllFile.Filter = "dll files (*.dll)|*.dll";
                if (openDllFile.ShowDialog() == DialogResult.OK) {
                    Assembly dlls = Assembly.LoadFrom(openDllFile.FileName);
                    foreach (Type type1 in dlls.GetTypes()) {
                        if (type1.GetInterface("IConfig") != null) {
                            IConfig config = dlls.CreateInstance(type1.FullName) as IConfig;
                            if (config != null) {
                                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                                ServiceSection tmp = (ServiceSection)configuration.GetSection(ServiceSection.SectionName);
                                if (tmp == null) {
                                    configuration.Sections.Add("rfid.service", new ServiceSection());
                                    tmp = (ServiceSection)configuration.GetSection(ServiceSection.SectionName);
                                }
                                ParamsCollection paramCollection = new ParamsCollection();
                                using (FieldsFrm frm = new FieldsFrm(config.Fields)) {
                                    if (frm.ShowDialog() == DialogResult.OK) {
                                        foreach (IField field in config.Fields) {
                                            paramCollection.Add(new ParamElement() { Description = field.Description, Name = field.Name, Type = field.Type, Value = field.Value });
                                        }
                                        tmp.Readers.Add(new ReaderImpl() { Name = config.ProgId, ParamsReader = paramCollection });

                                        configuration.Save(ConfigurationSaveMode.Modified, false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
