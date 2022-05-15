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
    public partial class AddGunHelp_Gui : Form
    {
        public AddGunHelp_Gui()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SocialLinks.AddGunTutorial();
        }
    }
}
