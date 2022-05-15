using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2.GUIs
{
    public partial class ViewGun_GUI : Form
    {
        private StaticItemData.GunClass Gun;
        private void loadAttachments(AttachmentClass a)
        {
            Label[] labs = new Label[] {label2, label3, label4, label5, label6, label7, label8, label9 };
            string[] b = new string[] { a.Optic, a.Muzzle, a.Barrel, a.Body, a.Underbarrel, a.Magazine, a.GunHandle, a.Stock };
            int i = 0;
            foreach (string s in b)
            {
                if (s != "None")
                {
                    labs[i].Text = s;
                    i++;
                }
            }
        }
        public ViewGun_GUI(StaticItemData.GunClass gun)
        {
            InitializeComponent();
            Gun = gun;
        }

        private void ViewGun_GUI_Load(object sender, EventArgs e)
        {
            label1.Text = Gun.Name;
            loadAttachments(Gun.Attachments);
        }

        private void ViewGun_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
