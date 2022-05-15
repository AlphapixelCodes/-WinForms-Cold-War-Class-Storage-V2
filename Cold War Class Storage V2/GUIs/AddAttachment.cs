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

namespace Cold_War_Class_Storage_V2
{
    public partial class AddAttachment : Form
    {
        public AddAttachment(Attachment_GUI2 gui)
        {
            InitializeComponent();
            Gui = gui;
        }

        private Attachment_GUI2 Gui;

        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            if (t.Length < 3)
            {
                MessageBox.Show("Name must be longer than 2 characters", "Too short", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (Regex.IsMatch(t, "[^a-zA-Z 0-9-]+"))
            {
                MessageBox.Show("Name can only contain A-Z 0-9 Space and -", "Illegal characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (StaticItemData.HasAttachment(t))
            {
                MessageBox.Show("This Attachment already exists", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (typebox.SelectedItem == null)
            {
                MessageBox.Show("Must select a type", "No type selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (typebox.SelectedItem+"")
            {
                case "Optic":
                    Gui.AddAttachment(t, 0);
                    StaticItemData.OpticList.Add(t);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 0));
                    break;
                case "Muzzle":
                    Gui.AddAttachment(t, 1);
                    StaticItemData.MuzzleList.Add(t);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 1));
                    break;
                case "Barrel":
                    Gui.AddAttachment(t, 2);
                    StaticItemData.BarrelList.Add(t);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 2));
                    break;
                case "Body":
                    Gui.AddAttachment(t, 3);
                    StaticItemData.BodyList.Add(t);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 3));
                    break;
                case "Underbarrel":
                    Gui.AddAttachment(t, 4);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 4));
                    StaticItemData.UnderbarrelList.Add(t);
                    break;
                case "Magazine":
                    Gui.AddAttachment(t, 5);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 5));
                    StaticItemData.MagazineList.Add(t);
                    break;
                case "Handle":
                    Gui.AddAttachment(t, 6);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 6));
                    StaticItemData.HandleList.Add(t);
                    break;
                case " Stock":
                    Gui.AddAttachment(t, 7);
                    StaticItemData.AttachmentsToAdd.Add(new Tuple<string, int>(t, 7));
                    StaticItemData.StockList.Add(t);
                    break;

            }
            Close();
        }

        private void AddAttachment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
