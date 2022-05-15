using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2
{
    public static class ClassUIControl
    {
        public static void WildCardClickEvent(object sender,EventArgs a)
        {
            TextImageControl b = (TextImageControl)sender;
            ItemPick_GUI gui = new ItemPick_GUI("Wildcards", StaticItemData.WildCardList, b);
            gui.StartPosition = FormStartPosition.CenterParent;
            gui.ShowDialog();
            
            Form1 form1 = ((Form1)(b.FindForm()));
            bool isPerkGreed = b.icon.Name.Equals("PERK GREED");
            form1.PerkRow2Reference.Controls.OfType<TextImageControl>().ToList().ForEach(e =>
            {
                e.Enabled = isPerkGreed;
                if (!e.Enabled)
                    e.update(new IconClass("None", Properties.Resources.Blank_Perk));
            });
            form1.Gunfighter(b.icon.Name.Equals("GUNFIGHTER"));
            form1.Law_Breaker(b.icon.Name.Equals("LAW BREAKER"));
            BuildManager.CurrentBuild.Wildcard = b.icon.Name;
            //set entire perk row 2 to none and disable them if it isnt perk greed
        }
        public static void TacticalClickEvent(object sender, EventArgs a)
        {
            ItemPick_GUI gui = new ItemPick_GUI("Tactical", StaticItemData.TechnicalList, (TextImageControl)sender);
            gui.StartPosition = FormStartPosition.CenterParent;
            gui.ShowDialog();
            BuildManager.CurrentBuild.Tactical = ((TextImageControl)sender).icon.Name;
        }
        public static void LethalClickEvent(object sender, EventArgs a)
        {
            new ItemPick_GUI("Lethal", StaticItemData.LethalList, (TextImageControl)sender).ShowDialog();
            BuildManager.CurrentBuild.Lethal = ((TextImageControl)sender).icon.Name;
        }
        public static void FieldUpgradeClickEvent(object sender, EventArgs a)
        {
            new ItemPick_GUI("Field Upgrade", StaticItemData.FieldUpgradeList, (TextImageControl)sender).ShowDialog();
            BuildManager.CurrentBuild.FieldUpgrade = ((TextImageControl)sender).icon.Name;
        }
        public static void PerkClickEvent(object sender,EventArgs a)
        {
            
            TextImageControl p = (TextImageControl)sender;
            new Perk_GUI(p.Parent.Controls.OfType<TextImageControl>().ToList()).ShowDialog();
            ((Form1)p.ParentForm).UpdateBuildPerks();
           
            }
            //
        }
}
