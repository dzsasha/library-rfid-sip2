using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Marc.Interface;

namespace Marc.CS
{
	public partial class TypeCtrl : UserControl
	{
		private ModelCtrl model = new ModelCtrl() {Dock = DockStyle.Fill};
		public IReader Reader { get; set; }

		public TypeCtrl(IReader reader)
		{
			Reader = reader;
			InitializeComponent();
			if (Reader != null)
			{
				reader_OnChange(reader, new EventArgs());
				Reader.OnChange += reader_OnChange;
			}
			cbId.DisplayMember = "Id";
			lbTypes.DisplayMember = "Model";
		}

		void reader_OnChange(object sender, EventArgs e)
		{
			List<IItem> items = new List<IItem>();
			items.AddRange((sender as IReader).Items);
			if (items.Any())
			{
				cbId.DataSource = items;
				cbId.SelectedIndex = 0;
			}
			else
			{
				cbId.DataSource = null;
				cbId.SelectedIndex = -1;
			}
		}

		private void cbId_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender is ComboBox)
			{
				if ((sender as ComboBox).SelectedItem is IItemModel)
				{
					IModel[] tmp = ToModel(((sender as ComboBox).SelectedItem as IItemModel).Models);
					lbTypes.DataSource = ToModel(((sender as ComboBox).SelectedItem as IItemModel).Models);
					if ((lbTypes.DataSource as IModel[]).Any())
					{
						splitCont.Panel2.Controls.Add(model);
					}
					else
					{
						splitCont.Panel2.Controls.Remove(model);
					}
					if (model != null)
					{
						model.Id = ((sender as ComboBox).SelectedItem as IItem).Id;
					}
					contextMenu.Items.Clear();
					foreach (ITypeModel typeModel in ((sender as ComboBox).SelectedItem as IItemModel).Models)
					{
						contextMenu.Items.Add(typeModel.Model.ToString(), null, new EventHandler(model_onClick));
					}
				}
			}
		}

		private void lbTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			model.Model = ((sender as ListBox).SelectedItem as IModelEx);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Reader.OnChange -= reader_OnChange;
			reader_OnChange(Reader, new EventArgs());
			Reader.OnChange += reader_OnChange;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			contextMenu.Show(button2, new Point(0, button2.Height));
		}

		private void model_onClick(object sender, EventArgs e)
		{
			if (cbId.SelectedItem is IItemModel)
			{
				foreach (ITypeModel typeModel in (cbId.SelectedItem as IItemModel).Models.Where(typeModel => typeModel.Model.ToString() == sender.ToString()))
				{
					typeModel.Add(typeModel.Default);
				}
				cbId_SelectedIndexChanged(cbId, new EventArgs());
			}
		}

		private IModel[] ToModel(ITypeModel[] models)
		{
			return models.SelectMany(typeModel => typeModel).ToArray();
		}
	}
}
