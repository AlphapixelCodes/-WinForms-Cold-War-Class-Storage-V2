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
    public partial class GunSelect_GUI : Form
    {
        private bool dontupdategunclass;
        public StaticItemData.GunClass returnValue;
        public GunSelect_GUI()
        {
            InitializeComponent();
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 18, 18, 18);
            BackColor = flowLayoutPanel1.BackColor;
            comboBox1.SelectedItem = "ASSAULT RIFLES";
            dontupdategunclass = true;
        }
        public GunControl gunControl;
        public GunSelect_GUI(GunControl x,String startingtab)
        {
            gunControl = x;
            InitializeComponent();
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 18, 18, 18);
            comboBox1.SelectedItem = startingtab;
            BackColor = flowLayoutPanel1.BackColor;
        }
        public GunSelect_GUI(GunControl x, String startingtab,bool isLawBreaker)
        {
            gunControl = x;
            InitializeComponent();
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 18, 18, 18);
            comboBox1.SelectedItem = startingtab;
            if (startingtab == "SECONDARIES"&&!isLawBreaker)
            {
                comboBox1.Items.Remove("ASSAULT RIFLES");
                comboBox1.Items.Remove("SUB MACHINE GUNS");
                comboBox1.Items.Remove("TACTICAL RIFLES");
                comboBox1.Items.Remove("LIGHT MACHINE GUNS");
                comboBox1.Items.Remove("SNIPER RIFLES");
            }else if (startingtab== "ASSAULT RIFLES"&&!isLawBreaker)
            {
                comboBox1.Items.Remove("SECONDARIES");
            }
            BackColor = flowLayoutPanel1.BackColor;
        }
        private void loadGunsIntoFlow(List<StaticItemData.GunClass> guns)
        {
            Console.WriteLine("GunSelect_GUI.loadGunsIntoFlow: fix memory leak");
            foreach (var item in flowLayoutPanel1.Controls.OfType<GunControl>())
            {
                item.Dispose();
            }
            GC.Collect();
            flowLayoutPanel1.Controls.Clear();
            guns.ForEach(e => {
                GunControl c = e.GetGunControl();
                c.hideAllBlocks(true);
                flowLayoutPanel1.Controls.Add(c);
                c.ControlClicked += GunClicked;
            });
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            StaticItemData.load();
            switch (comboBox1.SelectedItem)
            {
                case "ASSAULT RIFLES":
                    loadGunsIntoFlow(StaticItemData.AssaultRiflesList);
                    break;
                case "SUB MACHINE GUNS":
                    loadGunsIntoFlow(StaticItemData.SMGList);
                    break;
                case "TACTICAL RIFLES":
                    loadGunsIntoFlow(StaticItemData.TacticalRiflesList);
                    break;
                case "LIGHT MACHINE GUNS":
                    loadGunsIntoFlow(StaticItemData.LMGList);
                    break;
                case "SNIPER RIFLES":
                    loadGunsIntoFlow(StaticItemData.SniperRiflesList);
                    break;
                case "SECONDARIES":
                    loadGunsIntoFlow(StaticItemData.SecondaryList);
                    break;
                    
            }
        }
        
        private void GunClicked(object sender, EventArgs e)
        {
            GunControl gun = (GunControl)sender;
            if (dontupdategunclass)
            {
                returnValue=gun.gunClass.Clone();
            }
            else
            {
                gunControl.update(gun.gunClass, false);
            }
          /*  foreach (var item in flowLayoutPanel1.Controls.OfType<GunControl>())
            {
                item.Dispose();
            }
            GC.Collect();*/
            //flowLayoutPanel1.Controls.Clear();
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GUIs.AddGun_GUI().ShowDialog();
            comboBox1_SelectedValueChanged("", new EventArgs());
        }

        private void GunSelect_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
