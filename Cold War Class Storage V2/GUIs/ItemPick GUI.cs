using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2
{
    public partial class ItemPick_GUI : Form
    {
        List<IconClass> Items;
        TextImageControl Ret;
        public ItemPick_GUI(String name,List<IconClass> items,TextImageControl ret)
        {
            InitializeComponent();
            Ret = ret;
            Text = name;
            label1.Text = name.ToUpper();
            Items = items;
        }
        private List<SelectControl> selecs = new List<SelectControl>();
        private void Lethal_GUI_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            
            Items.ForEach(a =>
            {
                SelectControl b = a.getSelectControl();
                b.ControlSelected += subControlSelected;
                b.DoubleClickHappened += subControlDoubleClick;
                flowLayoutPanel1.Controls.Add(b);
                selecs.Add(b);
            });
        }
        private void subControlSelected(object sender, EventArgs e)
        {
            Ret.update(GetSelected().PC);
            Close();
        }
        private void subControlDoubleClick(object sender,EventArgs e)
        {
            Ret.update(((SelectControl)sender).PC);
            Close();
        }

        private SelectControl GetSelected()
        {
            SelectControl ret = null;
            selecs.ForEach(e =>
            {
                if (e.Selected)
                    ret=e;
            });
            return ret;
        }

        private void ItemPick_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
