using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2.GUIs
{
    public partial class AddGun_GUI : Form
    {
        public AddGun_GUI()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new AddGunHelp_Gui().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (typebox.SelectedItem == null)
            {
                MessageBox.Show("Must select a type", "No type selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (Regex.IsMatch(t, "[^a-zA-Z 0-9-]+"))
            {
                MessageBox.Show("Name can only contain A-Z 0-9 Space and -", "Illegal characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (t.Length < 3)
            {
                MessageBox.Show("Name must be longer than 2 characters", "Too short", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (!StaticItemData.GetGunClassByName(t).Name.Equals("NONE"))
            {
                MessageBox.Show("Gun already exists by that name", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (fname == "")
            {
                MessageBox.Show("Must select an image file", "No Image Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StaticItemData.GunClass gunClass = new StaticItemData.GunClass(t, Image.FromFile(fname));
            int i = 0;
            switch (typebox.SelectedItem)
            {
                case "Assault Rifle":
                    StaticItemData.AssaultRiflesList.Add(gunClass);
                    i = 0;
                    break;
                case "Submachine Gun":
                    StaticItemData.SMGList.Add(gunClass);
                    i = 1;
                    break;
                case "Tactical Rifle":
                    StaticItemData.TacticalRiflesList.Add(gunClass);
                    i = 2;
                    break;
                case "Light Machine Gun":
                    StaticItemData.LMGList.Add(gunClass);
                    i = 3;
                    break;
                case "Sniper Rifle":
                    StaticItemData.SniperRiflesList.Add(gunClass);
                    i = 4;
                    break;
                case "Secondary":
                    StaticItemData.SecondaryList.Add(gunClass);
                    i = 5;
                    break;
            }
            StaticItemData.GunsToAdd.Add(new Tuple<StaticItemData.GunClass, int>(gunClass, i));
            MessageBox.Show("Successfully added " + t + " to " + typebox.SelectedItem,"Added",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();

        }
        private string fname = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fname = ofd.FileName;
                Filename.Text = Path.GetFileName(fname);
            }
            
        }
    }
}
