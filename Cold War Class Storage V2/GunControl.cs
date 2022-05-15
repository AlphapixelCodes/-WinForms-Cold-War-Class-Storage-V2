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
    public partial class GunControl : UserControl
    {
        public void setAttachmentBlocks(int numberofattachments)
        {
            PictureBox[] boxes=GetBoxArray();
            for (var i = 0; i < boxes.Length; i++)
            {
                boxes[i].Image = Properties.Resources.unselected_attachment_icon;
            }
                for (var i=0;i< numberofattachments; i++)
            {
                boxes[i].Image = Properties.Resources.selected_attachment_icon;
            }
        }
        public void ShowHideExtraThreeBoxes(bool hide)
        {
                pictureBox7.Visible = !hide;
                pictureBox8.Visible = !hide;
                pictureBox9.Visible = !hide;
           
        }
        private PictureBox[] GetBoxArray()
        {
            return new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9 };
        }
        public void hideAllBlocks(bool hide)
        {
            PictureBox[] boxes = GetBoxArray();
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Visible = !hide;
            }
        }
        public GunControl()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(255, 18, 18, 18);
            setAttachmentBlocks(0);
            Cursor = Cursors.Hand;
            ShowHideExtraThreeBoxes(true);
        }

        public GunControl(StaticItemData.GunClass gunClass)
        {
            InitializeComponent();
            setAttachmentBlocks(0);
            BackColor = Color.FromArgb(255, 18, 18, 18);
            Cursor = Cursors.Hand;
            this.gunClass = gunClass;
            update(gunClass,true);
            if (gunClass.Attachments != null)
                loadAttachments(gunClass.Attachments);
            else
                hideAllBlocks(true);
        }
        public void loadAttachments(AttachmentClass x)
        {
            gunClass.Attachments = x;
            if(x!=null)
                setAttachmentBlocks(x.getAttachmentCount());

        }
        public void update(StaticItemData.GunClass gun, bool updateAttachments)
        {
            if (gun.Name != GunName.Text)
            {
                gunClass=gun;
                GunName.Text = gun.Name;
                pictureBox1.Image = gun.Image;
            }
            if (updateAttachments)
            {
                loadAttachments(gun.Attachments);
            }
        }

        public event EventHandler ControlClicked;
        private void click(object sender, EventArgs e)
        {
            ControlClicked?.Invoke(this, e);
        }

        bool pichover, texthover, controlhover;
        public StaticItemData.GunClass gunClass = new StaticItemData.GunClass("", null);
        private void MouseEnterEvent(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "GunName":
                    texthover = true;
                    break;
                case "pictureBox1":
                    pichover = true;
                    break;
                case "GunControl":
                    controlhover = true;
                    break;
            }
            hover();
        }
        private void MouseLeaveEvent(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "GunName":
                    texthover = false;
                    break;
                case "pictureBox1":
                    pichover = false;
                    break;
                case "GunControl":
                    controlhover = false;
                    break;
            }
            hover();
        }
        private void hover()
        {
            if(pichover || texthover || controlhover)
            {
                //BackColor = Color.FromArgb(255,30,30,30);
                BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                BorderStyle = BorderStyle.FixedSingle;
                //BackColor = Color.FromArgb(255, 18, 18, 18);
            }
        }
    }
}
