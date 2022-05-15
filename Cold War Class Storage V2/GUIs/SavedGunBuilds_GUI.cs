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
    public partial class SavedGunBuilds_GUI : Form
    {
        private List<StaticItemData.GunBuildSave> guns;

        private bool SelectBuild;
        private bool showButton;
        public SavedGunBuilds_GUI()
        {
            InitializeComponent();
            guns = StaticItemData.SavedGunBuilds;
            showButton = true;
        }
        public void loadAddBlueprintButton()
        {
            Button button = new Button();
            panel1.Controls.Add(button);
            button.Text = "New Blueprint";
            button.BackColor = Color.Black;
            button.ForeColor = Color.WhiteSmoke;
            button.Dock = DockStyle.Top;
            button.Font = new Font("Stencil", 12);
            button.Height = 30;
            button.Click += addBlueprintClick;
            panel1.ScrollControlIntoView(button);
            //panel1.VerticalScroll.Value = 20;
            //Console.WriteLine("Fuck: " + button.AutoScrollOffset);
        }
        public void addBlueprintClick(object sender,EventArgs e)
        {
            Console.WriteLine(panel1.VerticalScroll.Value);
            new AddBlueprint_GUI().ShowDialog();
            LoadGunBuilds(guns);
        }
       /* public SavedGunBuilds_GUI(bool selectBuild)
        {
            InitializeComponent();
            guns = StaticItemData.SavedGunBuilds;
            SelectBuild = selectBuild;
        }*/
        public SavedGunBuilds_GUI(bool selectBuild,string guntype)
        {
            InitializeComponent();
            guns = StaticItemData.SavedGunBuilds.FindAll(e=>e.Name==guntype);
            SelectBuild = selectBuild;
        }
        private void LoadGunBuilds(List<StaticItemData.GunBuildSave> gs)
        {
            
          
            panel1.Controls.Clear();
            FlowLayoutPanel currentPanel = new FlowLayoutPanel();
            String CurrentGun = "";
            gs.OrderBy(e => e.Name).ToList().ForEach(e => {
                if (CurrentGun != e.Name)
                {
                    currentPanel = new FlowLayoutPanel();
                    currentPanel.Dock = DockStyle.Top;
                    currentPanel.AutoSize = true;
                    panel1.Controls.Add(currentPanel);

                    Label a = new Label();
                    a.Text = e.Name;
                    a.Dock = DockStyle.Top;
                    a.TextAlign = ContentAlignment.MiddleCenter;
                    a.Font= new Font("Stencil", 12);
                    a.AutoSize = false;
                    a.ForeColor = Color.WhiteSmoke;
                    panel1.Controls.Add(a);
                    CurrentGun = e.Name;
                }
                SelectControl s = e.getSelectControl();
                s.Selectable = false;
                s.ContextMenu = new ModifiedContextMenu(s);
                s.gunClass = e;
                s.setTitle(e.BuildName);
                s.ContextMenu.MenuItems.Add("View").Click += SelectControlRClickView;
                s.ContextMenu.MenuItems.Add("Delete").Click += SelectControlRClickDelete;
                s.ContextMenu.MenuItems.Add("Edit Attachments").Click += SelectControlRClickEditAttachments;
                s.Click += selectControlClick;
                s.ControlSelected += selectControlClick;
                currentPanel.Controls.Add(s);
            });

            if (showButton)
            {
                loadAddBlueprintButton();
                //Fix the fucking scroll thing idk how https://stackoverflow.com/questions/2607508/how-to-control-docking-order-in-winforms
            }
        }

        private void SelectControlRClickEditAttachments(object sender, EventArgs e)
        {
            ModifiedContextMenu sender1 = (ModifiedContextMenu)((MenuItem)sender).GetContextMenu();
            new Attachment_GUI2(sender1.Owner.gunClass, 20).ShowDialog();
        }

        private void SelectControlRClickDelete(object sender, EventArgs e)
        {
            ModifiedContextMenu sender1 = (ModifiedContextMenu)((MenuItem)sender).GetContextMenu();
            Console.WriteLine("SavedGunBuilds.SelectControlRClickDelete: " + sender1.Owner.getTitle());
            StaticItemData.GunBuildSave gbs = StaticItemData.GetSavedGunBuildByName(sender1.Owner.getTitle());
            StaticItemData.SavedGunBuilds.Remove(gbs);
            panel1.Controls.Remove(sender1.Owner);
            sender1.Owner.Dispose();
            //StaticItemData.SavedGunBuilds.Remove()
        }

        private void SelectControlRClickView(object sender, EventArgs e)
        {
            ModifiedContextMenu sender1 = (ModifiedContextMenu)((MenuItem)sender).GetContextMenu();
            Console.WriteLine("what the fuck "+StaticItemData.GetSavedGunBuildByName(sender1.Owner.getTitle()).Attachments);
            new GUIs.ViewGun_GUI(StaticItemData.GetSavedGunBuildByName(sender1.Owner.getTitle())).Show();
            
            Console.WriteLine();
        }
        public StaticItemData.GunBuildSave returnValue;
        private void selectControlClick(object sender, EventArgs e)
        {
            SelectControl selectC = (SelectControl)sender;
            MouseEventArgs m = (MouseEventArgs)e;
            if (m.Button == MouseButtons.Right)
            {
                selectC.ContextMenu.Show(selectC, Cursor.Position);
            }else if(SelectBuild && m.Button == MouseButtons.Left)
            {
                
                returnValue = (StaticItemData.GunBuildSave)selectC.gunClass;
                this.Close();
            }else if(m.Button == MouseButtons.Left)
            {
                new ViewGun_GUI(selectC.gunClass).Show();
            }
            //Console.WriteLine("SavedGunBuilds.selectControlClick: "+SelectBuild);
        }

        private void SavedGunBuilds_GUI_Load(object sender, EventArgs e)
        {
            
            LoadGunBuilds(guns);

        }
        private class ModifiedContextMenu : ContextMenu
        {
            public ModifiedContextMenu(SelectControl owner)
            {
                Owner = owner;
            }

            public SelectControl Owner { get; }
        }

        private void SavedGunBuilds_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
