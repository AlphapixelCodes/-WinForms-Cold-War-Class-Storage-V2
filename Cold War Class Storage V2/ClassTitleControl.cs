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
    public partial class ClassTitleControl : UserControl
    {
        public ClassBuild build;
        private string titleText;
        public string TitleText { 
            get { return titleText; } 
            set 
            {
                titleText = value;
                NameLabel.Text = value;
            } 
        }
        private bool selected;
        public bool Selected { 
            get 
            {
                return selected; 
            }
            set
            {
                selected = value;
                
                hover();
                if (selected)
                    SelectedEvent?.Invoke(this, new EventArgs());
            }
        }
        
        private bool favorite;
        
        public ClassTitleControl()
        {
            InitializeComponent();
        }
        public ClassTitleControl(ClassBuild x)
        {
            InitializeComponent();
            build = x;
            TitleText = x.Name;
            favorite = x.isFavorite;
           /* if (!favorite)
                pictureBox1.Visible = false;*/
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Toggle Favorite").Click += ContextMenuClick;
            this.ContextMenu = cm;
            cm.MenuItems.Add("Rename").Click += ContextMenuClick;
            cm.MenuItems.Add("Duplicate").Click += ContextMenuClick;
            cm.MenuItems.Add("Delete").Click += ContextMenuClick;
            cm.MenuItems.Add("Change Group");
            MenuItem men = new MenuItem("None");
            men.Click += ContextMenuChangeGroupClick;
            cm.MenuItems[4].MenuItems.Add(men);
            foreach (var item in StaticItemData.GroupColors)
            {
                MenuItem mi = new MenuItem(item.Name);
                mi.Click += ContextMenuChangeGroupClick;
                
                cm.MenuItems[4].MenuItems.Add(mi);
            }
            
            
        }
        private void ContextMenuChangeGroupClick(object sender,EventArgs e)
        {
            Console.WriteLine();
            string s = ((MenuItem)sender).Text;
            build.Group =StaticItemData.GetGroupColorByName(s);
            hover();
        }

       
        private void ContextMenuClick(object sender,EventArgs e)
        {
            MenuItem s = (MenuItem)sender;
            switch (s.Text)
            {
                case "Toggle Favorite":
                    build.isFavorite = !build.isFavorite;
                    favorite = build.isFavorite;
                    hover();
                    break;
                case "Duplicate":
                    ChangeEvent?.Invoke(new Tuple<ClassTitleControl,string>(this,"Duplicate"), e);
                    break;
                case "Rename":
                    ChangeEvent?.Invoke(new Tuple<ClassTitleControl, string>(this, "Rename"), e);
                    break;
                case "Delete":
                    ChangeEvent?.Invoke(new Tuple<ClassTitleControl, string>(this, "Delete"), e);
                    break;
            }
        }

        public event EventHandler click,ChangeEvent, SelectedEvent;
        private void ClickEvent(object sender, EventArgs e)
        {
            
            MouseEventArgs a = ((MouseEventArgs)e);
            //Console.WriteLine("Click: "+a.Button);
            if (a.Button == MouseButtons.Left)
            {
                click?.Invoke(sender, e);
                this.Selected = true;
            }
            
        }
        private bool ClassTitleControlHover, pictureBox1Hover, NameLabelHover, panel2Hover, panel1Hover;
        private void MouseEnterEvent(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "ClassTitleControl":
                    ClassTitleControlHover = true;
                    break;
                case "pictureBox1":
                    pictureBox1Hover = true;
                    break;
                case "NameLabel":
                    NameLabelHover = true;
                    break;
                case "panel2":
                    panel2Hover = true;
                    break;
                case "panel1":
                    panel1Hover = true;
                    break;
            }
            hover();
        }
        private void MouseLeaveEvent(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "ClassTitleControl":
                    ClassTitleControlHover = false;
                    break;
                case "pictureBox1":
                    pictureBox1Hover = false;
                    break;
                case "NameLabel":
                    NameLabelHover = false;
                    break;
                case "panel1":
                    panel1Hover = false;
                    break;
                case "panel2":
                    panel2Hover = false;
                    break;
            }
            hover();
        }
        private void hover()
        {
            //pictureBox1.Visible = favorite;
            if(ClassTitleControlHover || pictureBox1Hover || NameLabelHover || panel2Hover || panel1Hover || selected)
            {
                panel1.BackColor = Color.WhiteSmoke;
                NameLabel.ForeColor = Color.Black;
                if (favorite)
                {
                    if (build.Group == null)
                        pictureBox1.Image = Properties.Resources.black_star;
                    else
                    {
                        pictureBox1.Image = build.Group.Star;
                    }
                }
                else
                {
                    if (build.Group == null)
                        pictureBox1.Image = Properties.Resources.blank_image;
                    else
                    {
                        pictureBox1.Image = build.Group.Dot;
                    }
                }
            }
            else
            {
                NameLabel.ForeColor = Color.WhiteSmoke;
                panel1.BackColor = Color.Transparent;
                //pictureBox1.Image = Properties.Resources.star;
                if (favorite)
                {
                    if (build.Group == null)
                        pictureBox1.Image = Properties.Resources.star;
                    else
                    {
                        pictureBox1.Image = build.Group.Star;
                    }
                }
                else
                {
                    if (build.Group == null)
                        pictureBox1.Image = Properties.Resources.blank_image;
                    else
                    {
                        pictureBox1.Image = build.Group.Dot;
                    }
                }
            }
        }

    }
}
