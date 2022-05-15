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
    public partial class TextImageControl : UserControl
    {
        public IconClass icon = new IconClass("", null);
        public TextImageControl()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(255, 214, 209, 196);
            Cursor = Cursors.Hand;
        }
        public TextImageControl(IconClass x)
        {
            InitializeComponent();
            update(x);
            BackColor = Color.FromArgb(255, 214, 209, 196);
            Cursor = Cursors.Hand;

        }
        private void hover()
        {
            if (Texthover || ImageHover)
            {
                BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                BorderStyle = BorderStyle.None;   
            }

        }
        bool Texthover, ImageHover;
        private void Control_MouseHover(object sender, EventArgs e)
        {
            string n = ((Control)sender).Name;
            if (n.Equals("label1"))
                Texthover = true;
            else if (n.Equals("pictureBox1"))
                ImageHover = true;
            hover();
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            string n = ((Control)sender).Name;
            if (n.Equals("label1"))
                Texthover = false;
            else if (n.Equals("pictureBox1"))
                ImageHover = false;
            hover();

        }
        public event EventHandler ControlSelected;
        private void click(object sender, EventArgs e)
        {
            ControlSelected?.Invoke(this, e);
        }
        public void update(IconClass x)
        {
            if (x.Name.Equals("NONE"))
                this.Enabled = false;
            icon = x;
            label1.Text = x.Name;
            pictureBox1.Image = x.Image;
        }
    }
}
