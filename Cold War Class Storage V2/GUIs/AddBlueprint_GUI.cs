using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2.GUIs
{
    public partial class AddBlueprint_GUI : Form
    {
        public AddBlueprint_GUI()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gun==null)
            {
                MessageBox.Show("Must select a gun", "No gun selected");
                return;
            }

            string t = textBox1.Text.ToUpper();
            if (t.Length > 40 || t.Length < 3)
            {
                MessageBox.Show("Must be between 3 and 40 characters", "Character limit");
                return;
            }
            else if (Regex.IsMatch(t, "[^A-Z 0-9-]+"))
            {
                MessageBox.Show("Name can only contain A-Z 0-9 Space and -", "Illegal characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (StaticItemData.SavedGunBuilds.Any(a => a.BuildName == t))
            {
                MessageBox.Show("Build already exists by that name", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            gun.Attachments = attachments?? new AttachmentClass();
            StaticItemData.SavedGunBuilds.Add(gun.GetBuildSave(t));
            MessageBox.Show("Blueprint for: " + gun.Name + " Saved as \"" + t + "\"");
            Close();
        }
        private StaticItemData.GunClass gun;
        private AttachmentClass attachments;
        private void button1_Click(object sender, EventArgs e)
        {
            GunSelect_GUI gui = new GunSelect_GUI();
           gui.ShowDialog();
           if (gui.returnValue == null)
               return;
            gun = gui.returnValue.Clone();
            GunLabel.Text = gun.Name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Attachment_GUI2 gui = new Attachment_GUI2(null);
            gui.ShowDialog();
            if(gui.returnValue!=null)
            attachments = gui.returnValue;
            //Console.WriteLine(gui.returnValue.ToString());
        }
    }
}
