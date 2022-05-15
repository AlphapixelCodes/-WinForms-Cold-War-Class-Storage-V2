using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2
{
    public partial class Perk_GUI : Form
    {
        public List<TextImageControl> PerksToChange { get; }

        public Perk_GUI()
        {
            InitializeComponent();
        }

        public Perk_GUI(List<TextImageControl> perkstochange)
        {
            PerksToChange = perkstochange;
            InitializeComponent();
            
        }

        private void Perk_GUI_Load(object sender, EventArgs e)
        {
            StaticItemData.load();
            string p1 = PerksToChange[0].icon.Name;
            string p2 = PerksToChange[1].icon.Name;
            string p3 = PerksToChange[2].icon.Name;
            StaticItemData.PerkList.ForEach(a => {
                SelectControl b = a.getSelectControl();
                if (b.PC.Name.Equals(p1) || b.PC.Name.Equals(p2) || b.PC.Name.Equals(p3))
                    b.Selected = true;
                switch (a.PerkType)
                {
                    case 1:
                        Type1Panel.Controls.Add(b);
                        break;
                    case 2:
                        Type2Panel.Controls.Add(b);
                        break;
                    case 3:
                        Type3Panel.Controls.Add(b);
                        break;
                }
            });
        }
        //clear
        private void button2_Click(object sender, EventArgs e)
        {
            List<SelectControl> l1 = Type1Panel.Controls.OfType<SelectControl>().ToList();
            List<SelectControl> l2 = Type2Panel.Controls.OfType<SelectControl>().ToList();
            List<SelectControl> l3 = Type3Panel.Controls.OfType<SelectControl>().ToList();
            l1.ForEach(a => {
                a.Selected = false;
            });
            l2.ForEach(a => {
                a.Selected = false;
            });
            l3.ForEach(a => {
                a.Selected = false;
            });
        }

        private List<SelectControl> GetSelected()
        {
            List<SelectControl> l1 = Type1Panel.Controls.OfType<SelectControl>().ToList().FindAll(e => e.Selected);
            List<SelectControl> l2 = Type2Panel.Controls.OfType<SelectControl>().ToList().FindAll(e => e.Selected);
            List<SelectControl> l3 = Type3Panel.Controls.OfType<SelectControl>().ToList().FindAll(e => e.Selected);
            l1.AddRange(l2);
            l3.AddRange(l1);
            return l3;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<SelectControl> cs = GetSelected();
            if (cs.Count > 3)
            {
                MessageBox.Show("More Than 3 Perks Are Selected","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }else if (cs.Count < 3)
            {
                MessageBox.Show("Must Select 3 Perks", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for(var i=0;i< PerksToChange.Count; i++)
            {
                PerksToChange[i].update(cs[i].PC);
            }
            this.Close();
            //check to make sure 3 are selected

        }

        private void Perk_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData ==Keys.Escape)
                this.Close();
        }
    }
}
