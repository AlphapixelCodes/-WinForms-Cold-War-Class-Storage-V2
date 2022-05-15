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
    public partial class SelectControl : UserControl
    {
        public StaticItemData.GunClass gunClass;
        public IconClass getIcon = new IconClass("", null);
        public bool Selectable = true;
        private bool selected;
        public bool Selected {
            get { return selected; }
            set {
                SelectedBoxImage.Image = (value)? Properties.Resources.Selected_dot : Properties.Resources.blank_image;
                selected = value;
            }
        }
        
        public IconClass PC { get { return getIcon; } set {
                getIcon = value;
                label1.Text = value.Name;
                pictureBox1.Image = value.Image;
            } }
        public SelectControl()
        {
            InitializeComponent();
            Cursor = Cursors.Hand;
            
            hover();
        }
        public SelectControl(IconClass pcc)
        {
            Cursor = Cursors.Hand;
            InitializeComponent();
            PC = pcc;
            label1.Text = getIcon.Name;
            hover();
            pictureBox1.Image = getIcon.Image;
            pictureBox1.BackColor = Color.FromArgb(255, 18, 18, 18);
        }
        protected override Size DefaultSize
        {
            get {
                return new Size(192,65);
            }
        }
        bool Texthover,ImageHover, SelectedBox;
        private void hover()
        {
            if(Texthover || ImageHover || SelectedBox)
            {
                this.BackColor = Color.FromArgb(255, 200, 200, 200);
                label1.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 88, 79, 74);
                label1.ForeColor = Color.FromArgb(255, 222, 218, 218);
            }
        }

        public event EventHandler ControlSelected,DoubleClickHappened;
        private void label1_Click(object sender, EventArgs e)
        {
            if (Selectable)
                Selected = !selected;            
            ControlSelected?.Invoke(this, e);
        }

        private void DoubleClickEvent(object sender, EventArgs e)
        {
            DoubleClickHappened?.Invoke(this, e);
        }

        private void PerkControl_MouseHover(object sender, EventArgs e)
        {
            string n = ((Control)sender).Name;
            if (n.Equals("label1"))
                Texthover = true;
            else if (n.Equals("pictureBox1"))
                ImageHover = true;
            else if (n.Equals("SelectedBoxImage"))
                SelectedBox = true;
            hover();
            
        }

        private void PerkControl_MouseLeave(object sender, EventArgs e)
        {
            string n = ((Control)sender).Name;
            if (n.Equals("label1"))
                Texthover = false;
            else if (n.Equals("pictureBox1"))
                ImageHover = false;
            else if (n.Equals("SelectedBoxImage"))
                SelectedBox = false;
            hover();
            
        }
        public void setTitle(string text)
        {
            label1.Text = text;
        }
        public string getTitle()
        {
            return label1.Text;
        }
    }
}
