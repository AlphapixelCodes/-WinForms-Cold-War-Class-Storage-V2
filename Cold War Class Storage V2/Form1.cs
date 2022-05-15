using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Cold_War_Class_Storage_V2
{
    public partial class Form1 : Form
    {
        public enum SearchSettings { Name, Favorite, None,Group};
        private SearchSettings search = SearchSettings.None;
        private StaticItemData.GroupColor searchcolor;
        public Form1()
        {
            InitializeComponent();
            StaticItemData.load();
            BackColor = Color.FromArgb(255, 18, 18, 18);
        }

        public Panel PerkRow2Reference;
        private void Form1_Load(object sender, EventArgs e)
        {
            WildcardControl.ControlSelected += ClassUIControl.WildCardClickEvent;
            FieldUpgradeControl.ControlSelected += ClassUIControl.FieldUpgradeClickEvent;
            LethalControl.ControlSelected += ClassUIControl.LethalClickEvent;
            TacticalControl.ControlSelected += ClassUIControl.TacticalClickEvent;
            PerkRow2.Controls.OfType<TextImageControl>().ToList().ForEach(a => {
                a.ControlSelected += ClassUIControl.PerkClickEvent;
            });
            PerkRow1.Controls.OfType<TextImageControl>().ToList().ForEach(a => {
                a.ControlSelected += ClassUIControl.PerkClickEvent;
            });
            PerkRow2Reference = PerkRow2;
            PrimaryGunControl.ControlClicked += GunControl_ControlClicked;
            SecondaryGunControl.ControlClicked += GunControl_ControlClicked;
            new GunControlContextMenu(PrimaryGunControl, GunControlContextMenuClick);
            new GunControlContextMenu(SecondaryGunControl, GunControlContextMenuClick);

            FileManager.LoadFromTempFile(this);
            if(FileManager.LastSaveLocation!="")
                this.Text = Path.GetFileName(FileManager.LastSaveLocation);
            StaticItemData.load();
            /*BuildManager.CurrentBuild = BuildManager.newBuild();
            loadClassBuild(BuildManager.CurrentBuild);*/
            if (BuildManager.builds.Count == 0)
            {
                BuildManager.CurrentBuild = new ClassBuild();
                BuildManager.builds.Add(BuildManager.CurrentBuild);
                loadClassBuild(BuildManager.CurrentBuild);
            }
            RefreshBuildList();
            //loading group data into filter by groups
            foreach (var item in StaticItemData.GroupColors)
            {
                ToolStripItem tsi = groupToolStripMenuItem.DropDownItems.Add(item.Name);
                tsi.Image = item.Dot;
                tsi.Click += SearchByGroupClick;
            }
        }



        public void loadClassBuild(ClassBuild b)
        {
            BuildManager.CurrentBuild = b;
            StaticItemData.load();
            PrimaryGunControl.update(StaticItemData.GetGunClassByName(b.Primary),false);
            PrimaryGunControl.loadAttachments(b.primaryAtt);
            BuildNameLabel.Text = b.Name;
            SecondaryGunControl.update(StaticItemData.GetGunClassByName(b.Secondary), false);
            SecondaryGunControl.loadAttachments(b.secondaryAtt);

            Perk1Control.update(StaticItemData.GetPerkByName(b.Perk1));
            Perk2Control.update(StaticItemData.GetPerkByName(b.Perk2));
            Perk3Control.update(StaticItemData.GetPerkByName(b.Perk3));
            Perk4Control.update(StaticItemData.GetPerkByName(b.Perk4));
            Perk5Control.update(StaticItemData.GetPerkByName(b.Perk5));
            Perk6Control.update(StaticItemData.GetPerkByName(b.Perk6));

            LethalControl.update(StaticItemData.GetIconByName(b.Lethal, StaticItemData.LethalList));
            TacticalControl.update(StaticItemData.GetIconByName(b.Tactical, StaticItemData.TechnicalList));
            FieldUpgradeControl.update(StaticItemData.GetIconByName(b.FieldUpgrade, StaticItemData.FieldUpgradeList));
            WildcardControl.update(StaticItemData.GetIconByName(b.Wildcard, StaticItemData.WildCardList));
            
            
            PrimaryGunControl.ShowHideExtraThreeBoxes(!(WildcardControl.icon.Name == "GUNFIGHTER"));

            
        }

        private void SearchByGroupClick(object sender, EventArgs e)
        {
            searchcolor = (StaticItemData.GetGroupColorByName(((ToolStripItem)sender).Text));
            search = SearchSettings.Group;
            RefreshBuildList();
        }



        public void UpdateBuildPerks()
        {
            BuildManager.CurrentBuild.Perk1 = Perk1Control.icon.Name;
            BuildManager.CurrentBuild.Perk2 = Perk2Control.icon.Name;
            BuildManager.CurrentBuild.Perk3 = Perk3Control.icon.Name;
            BuildManager.CurrentBuild.Perk4 = Perk4Control.icon.Name;
            BuildManager.CurrentBuild.Perk5 = Perk5Control.icon.Name;
            BuildManager.CurrentBuild.Perk6 = Perk6Control.icon.Name;
        }

        private void GunControl_ControlClicked(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (mouse.Button == MouseButtons.Left)
            {
                String curprime = PrimaryGunControl.gunClass.Name;
                String cursecondary = PrimaryGunControl.gunClass.Name;

                string startingtab = (((GunControl)sender).Name == "PrimaryGunControl") ? "ASSAULT RIFLES" : "SECONDARIES";
                GunSelect_GUI gunSelect_GUI = new GunSelect_GUI(((GunControl)sender), startingtab, WildcardControl.icon.Name == "LAW BREAKER");
                if (gunSelect_GUI.ShowDialog() == DialogResult.Cancel)
                    return;
                if (((GunControl)sender).Name == "PrimaryGunControl")
                {

                    Console.WriteLine("Form1.GunControl_ControlClicked: " + PrimaryGunControl.gunClass.Name);
                    BuildManager.CurrentBuild.Primary = PrimaryGunControl.gunClass.Name;

                    if (!curprime.Equals(PrimaryGunControl.gunClass.Name))
                    {
                        PrimaryGunControl.gunClass.Attachments = new AttachmentClass();
                        BuildManager.CurrentBuild.primaryAtt = new AttachmentClass();
                        PrimaryGunControl.update(PrimaryGunControl.gunClass, false);
                        PrimaryGunControl.setAttachmentBlocks(0);

                    }
                }
                else
                {
                    BuildManager.CurrentBuild.Secondary = SecondaryGunControl.gunClass.Name;
                    if (!cursecondary.Equals(SecondaryGunControl.gunClass.Name))
                    {
                        SecondaryGunControl.gunClass.Attachments = new AttachmentClass();
                        BuildManager.CurrentBuild.secondaryAtt = new AttachmentClass();
                        SecondaryGunControl.update(SecondaryGunControl.gunClass, false);
                        SecondaryGunControl.setAttachmentBlocks(0);
                    }
                }
            }
        }
        


        public void Gunfighter(bool isGunfighter)
        {
            PrimaryGunControl.ShowHideExtraThreeBoxes(!isGunfighter);
           // Console.WriteLine("Form1.Gunfighter: " + PrimaryGunControl.gunClass.Attachments);
            if (PrimaryGunControl.gunClass.Attachments == null)
                PrimaryGunControl.gunClass.Attachments = new AttachmentClass();
            AttachmentClass a = PrimaryGunControl.gunClass.Attachments;
            //Console.WriteLine("Form1.Gunfighter: "+a.getAttachmentCount());
            if (!isGunfighter && a.getAttachmentCount() > 5)
            {
                a.RemoveLastThreeAttachments();
            }
        }
        public void Law_Breaker(bool isLawBreaker)
        {
            if (isLawBreaker)
                return;
            if (StaticItemData.SecondaryList.Any(e=>e.Name==PrimaryGunControl.gunClass.Name))
            {
                PrimaryGunControl.gunClass.Attachments = new AttachmentClass();
                PrimaryGunControl.update(StaticItemData.GetGunClassByName("XM4"),false);
                PrimaryGunControl.setAttachmentBlocks(0);
                BuildManager.CurrentBuild.Primary = PrimaryGunControl.gunClass.Name;
                BuildManager.CurrentBuild.primaryAtt = new AttachmentClass();
            }
            if (StaticItemData.getPrimaries().Any(e => e.Name == SecondaryGunControl.gunClass.Name))
            {
                SecondaryGunControl.gunClass.Attachments = new AttachmentClass();
                SecondaryGunControl.update(StaticItemData.GetGunClassByName("1911"), false);
                SecondaryGunControl.setAttachmentBlocks(0);
                BuildManager.CurrentBuild.Secondary = SecondaryGunControl.gunClass.Name;
                BuildManager.CurrentBuild.secondaryAtt = new AttachmentClass();
            }
        }
        ///gunsmith buttons
        private void PrimaryGunSmith_Click(object sender, EventArgs e)
        {
            new Attachment_GUI2(PrimaryGunControl, (WildcardControl.icon.Name == "GUNFIGHTER")? 9 : 5).ShowDialog();
            
            BuildManager.CurrentBuild.primaryAtt = PrimaryGunControl.gunClass.Attachments.Clone();
        }
        private void SecondaryGunSmith_Click(object sender, EventArgs e)
        {
            new Attachment_GUI2(SecondaryGunControl, 5).ShowDialog();
            BuildManager.CurrentBuild.secondaryAtt = SecondaryGunControl.gunClass.Attachments.Clone();
        }
        private void GunSmith_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.gunsmith_hovered;
        }

        private void GunSmith_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.gunsmith;
        }



        //build stuff
        public void RefreshBuildList()
        {
            List<ClassBuild> bs = new List<ClassBuild>();
            switch (search)
            {
                case SearchSettings.Favorite:
                    bs = BuildManager.builds.FindAll(e => e.isFavorite);
                    break;
                case SearchSettings.Name:
                    bs = BuildManager.builds.FindAll(e => e.Name.Contains(ToolstripNameTextBox.Text.ToUpper()));
                    break;
                case SearchSettings.None:
                    bs = BuildManager.builds;
                    break;
                case SearchSettings.Group:
                    bs = BuildManager.builds.FindAll(e =>e.Group==searchcolor);
                    break;
            }
            ClassListPanel.Controls.Clear();
           
            bs.ForEach(e => {
                ClassTitleControl ctc = e.GetTitleControl();
                ctc.SelectedEvent += ClassTitleControl_SelectedEvent;
                ctc.ChangeEvent += ClassTitleControl_ChangeEvent;
                ctc.Dock = DockStyle.Top;
                ClassListPanel.Controls.Add(ctc);
            });
            int cddc = ClassListPanel.Controls.Count;
            if (cddc > 0)
                ((ClassTitleControl)ClassListPanel.Controls[cddc-1]).Selected = true;
        }

        private void ClassTitleControl_ChangeEvent(object sender, EventArgs e)
        {
            Tuple<ClassTitleControl, string> t = (Tuple<ClassTitleControl, string>)sender;
            switch (t.Item2)
            {
                case "Rename":
                    GUIs.Rename_GUI rename = new GUIs.Rename_GUI();
                    if (rename.ShowDialog() == DialogResult.OK)
                    {
                        t.Item1.build.Name = rename.returnValue;
                        t.Item1.TitleText = rename.returnValue;
                        BuildNameLabel.Text = rename.returnValue;
                    }
                    break;
                case "Delete":
                    if(MessageBox.Show("Are you sure you want to delete " + t.Item1.build.Name + " class?","Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        BuildManager.builds.Remove(t.Item1.build);
                        if (BuildManager.builds.Count == 0)
                            BuildManager.builds.Add(new ClassBuild());
                        RefreshBuildList();
                    }
                    break;
                case "Duplicate":
                    ClassBuild b = t.Item1.build.Clone();
                    ClassTitleControl ctc = b.GetTitleControl();
                    ctc.SelectedEvent += ClassTitleControl_SelectedEvent;
                    ctc.ChangeEvent += ClassTitleControl_ChangeEvent;
                    ctc.Dock = DockStyle.Top;
                    ClassListPanel.Controls.Add(ctc);
                    ctc.Selected = true;
                    break;
            }
        }

        private void ClassTitleControl_SelectedEvent(object sender, EventArgs e)
        {
            foreach (ClassTitleControl item in ClassListPanel.Controls)
            {
                if(!((ClassTitleControl)sender).Equals(item))
                    item.Selected = false;
            }
            loadClassBuild(((ClassTitleControl)sender).build);
        }

        private void newBuild(object sender, EventArgs e)
        {
            BuildManager.CurrentBuild = BuildManager.newBuild();
            loadClassBuild(BuildManager.CurrentBuild);
            RefreshBuildList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("make me hover and make it a popup that displays the gun info like the first version");
        }

        //search toolstrip options
        private void ToolstripNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search = SearchSettings.Name;
                RefreshBuildList();
            }
        }
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search = SearchSettings.None;
            RefreshBuildList();
        }
        private void clearSearchFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search = SearchSettings.Favorite;
            RefreshBuildList();
        }

        private void ViewButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.hover_view;
        }
        private void ViewButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Image = Properties.Resources.view;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = FileManager.SaveFile(FileManager.LastSaveLocation,true);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = FileManager.OpenFile(this);
               
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = FileManager.SaveAsFile();
        }

        private void viewbutton_Click(object sender, EventArgs e)
        {
            Button s = (Button) sender;
            if (s.Name == "viewbuttonprimary")
                new GUIs.ViewGun_GUI(PrimaryGunControl.gunClass).Show();
            else
                new GUIs.ViewGun_GUI(SecondaryGunControl.gunClass).Show();
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new GUIs.SavedGunBuilds_GUI().ShowDialog();
        }

      

        private void GunControlContextMenuClick(object sender,EventArgs e)
        {
            GunControlContextMenu gunControlContextMenu = (GunControlContextMenu)((MenuItem)sender).GetContextMenu();
            Console.WriteLine(gunControlContextMenu.gunControl.gunClass.Name);
            switch (((MenuItem)sender).Text)
            {

                case "Save Blueprint":
                    GUIs.NameSavedBuild_GUI gui = new GUIs.NameSavedBuild_GUI();
                    if (gui.ShowDialog().Equals(DialogResult.OK))
                    {
                        StaticItemData.SavedGunBuilds.Add(gunControlContextMenu.gunControl.gunClass.GetBuildSave(gui.returnValue));
                        MessageBox.Show("Saved Build as: " + gui.returnValue);
                    }
                    break;
                case "Load Blueprint":
                    GUIs.SavedGunBuilds_GUI g = new GUIs.SavedGunBuilds_GUI(true, gunControlContextMenu.gunControl.gunClass.Name);
                    g.ShowDialog();
                    if (g.returnValue != null)
                    {
                        gunControlContextMenu.gunControl.update(g.returnValue, false);
                        gunControlContextMenu.gunControl.gunClass.Attachments = g.returnValue.Attachments;
                        gunControlContextMenu.gunControl.loadAttachments(g.returnValue.Attachments);
                        Gunfighter(WildcardControl.icon.Name == "GUNFIGHTER");
                        switch (gunControlContextMenu.gunControl.Name)
                        {
                            case "PrimaryGunControl":
                                BuildManager.CurrentBuild.primaryAtt = g.returnValue.Attachments.Clone();
                                break;
                            case "SecondaryGunControl":
                                BuildManager.CurrentBuild.secondaryAtt = g.returnValue.Attachments.Clone();
                                break;
                        }
                    }
                    break;
                case "View":
                    new GUIs.ViewGun_GUI(gunControlContextMenu.gunControl.gunClass).Show();
                    break;
        }
    }

        public class GunControlContextMenu:ContextMenu
        {
            public GunControl gunControl;
            public GunControlContextMenu(GunControl c,EventHandler clickEvent)
            {
                c.ContextMenu = this;
                gunControl = c;
                this.MenuItems.Add("View").Click += clickEvent;
                this.MenuItems.Add("Load Blueprint").Click += clickEvent;
                this.MenuItems.Add("Save Blueprint").Click += clickEvent;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to save before exiting?", "Save before exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FileManager.SaveFile(FileManager.LastSaveLocation, true);
            }
        }
        
        private void youtubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocialLinks.YoutubeChannel();
        }

        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
