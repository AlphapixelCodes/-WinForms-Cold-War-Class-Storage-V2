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
    public partial class Attachment_GUI2 : Form
    {
        private GunControl gunControl;
        private StaticItemData.GunClass gunClass;
        private bool giveReturnValue;
        public Attachment_GUI2(AttachmentClass n)
        {
            InitializeComponent();
            loadAttachments();
            loadGunAttachments(n);
            giveReturnValue = true;
            MaxAttachments = 20;
            
        }
        private int MaxAttachments;
        public Attachment_GUI2(GunControl guncontrol,int max)
        {
            MaxAttachments = max;
            InitializeComponent();
            loadAttachments();
            this.gunControl = guncontrol;
            loadGunAttachments(guncontrol);
        }
        public Attachment_GUI2(StaticItemData.GunClass gunclass, int max)
        {
            MaxAttachments = max;
            InitializeComponent();
            loadAttachments();
            this.gunControl = null;
            gunClass = gunclass;
            loadGunAttachments(gunClass);
        }
        private void loadGunAttachments(AttachmentClass a)
        {
            if (a == null)
            {
                a = new AttachmentClass();
                if(gunClass!=null)
                    gunClass.Attachments = a;
            }
            OpticCombo.SelectedItem = a.Optic;
            MuzzleCombo.SelectedItem = a.Muzzle;
            BarrelCombo.SelectedItem = a.Barrel;
            BodyCombo.SelectedItem = a.Body;
            UnderbarrelCombo.SelectedItem = a.Underbarrel;
            MagazineCombo.SelectedItem = a.Magazine;
            HandleCombo.SelectedItem = a.GunHandle;
            StockCombo.SelectedItem = a.Stock;
        }
        private void loadGunAttachments(StaticItemData.GunClass gunClass)
        {
            loadGunAttachments(gunClass.Attachments);         
        }

        public void AddAttachment(String name, int type)
        {
            ComboBox b = OpticCombo;
            switch (type)
            {
                case 0:
                    b = OpticCombo;
                    break;
                case 1:
                    b = MuzzleCombo;
                    break;
                case 2:
                    b = BarrelCombo;
                    break;
                case 3:
                    b = BodyCombo;
                    break;
                case 4:
                    b = UnderbarrelCombo;
                    break;
                case 5:
                    b = MagazineCombo;
                    break;
                case 6:
                    b = HandleCombo;
                    break;
                case 7:
                    b = StockCombo;
                    break;
                default:
                    return;
            }
            b.Items.Add(name);
        }
        private void loadGunAttachments(GunControl guncontrol)
        {
            AttachmentClass a = guncontrol.gunClass.Attachments;
            loadGunAttachments(a);
        }

        private void Attachment_GUI2_Load(object sender, EventArgs e)
        {
            
        }
        private void AddToCombo(ComboBox x, List<string> items)
        {
            x.Items.Clear();
            x.Items.AddRange(items.ToArray());
        }
        public void loadAttachments()
        {
            AddToCombo(OpticCombo, StaticItemData.OpticList);
            AddToCombo(MuzzleCombo, StaticItemData.MuzzleList);
            AddToCombo(BarrelCombo, StaticItemData.BarrelList);
            AddToCombo(BodyCombo, StaticItemData.BodyList);
            AddToCombo(UnderbarrelCombo, StaticItemData.UnderbarrelList);
            AddToCombo(MagazineCombo, StaticItemData.MagazineList);
            AddToCombo(HandleCombo, StaticItemData.HandleList);
            AddToCombo(StockCombo, StaticItemData.StockList);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            OpticCombo.SelectedItem = "None";
            MuzzleCombo.SelectedItem = "None";
            BarrelCombo.SelectedItem = "None";
            BodyCombo.SelectedItem = "None";
            UnderbarrelCombo.SelectedItem = "None";
            MagazineCombo.SelectedItem = "None";
            HandleCombo.SelectedItem = "None";
            StockCombo.SelectedItem = "None";
        }

        public AttachmentClass returnValue;
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            AttachmentClass a= new AttachmentClass(OpticCombo.SelectedItem + "", MuzzleCombo.SelectedItem + "", BarrelCombo.SelectedItem + "", BodyCombo.SelectedItem + "", UnderbarrelCombo.SelectedItem + "", MagazineCombo.SelectedItem + "", HandleCombo.SelectedItem + "", StockCombo.SelectedItem + "");
            if (a.getAttachmentCount() > MaxAttachments)
            {
                MessageBox.Show("Too many attachments selected, Max: 5","Too Many Attachments",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (gunControl == null)
            {
                if (giveReturnValue)
                {
                    returnValue = a;
                }
                else
                {
                    gunClass.Attachments = a;
                }
            }
            else
            {
                gunControl.gunClass.Attachments = a;
                gunControl.loadAttachments(gunControl.gunClass.Attachments);
            }
          //  Console.WriteLine(gunControl.gunClass.Attachments.getConsoleString());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddAttachment(this).ShowDialog();
        }
    }
}
