using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cold_War_Class_Storage_V2
{
    public class ClassBuild
    {
        public bool isFavorite;
        public String Name,Primary, Secondary, Perk1, Perk2, Perk3, Perk4, Perk5, Perk6, Wildcard, Tactical, Lethal,FieldUpgrade;
        public StaticItemData.GroupColor Group;
        public AttachmentClass primaryAtt, secondaryAtt;
        public ClassBuild(string name, string primary, string secondary, string perk1, string perk2, string perk3, string perk4, string perk5, string perk6, string wildcard, string tactical, string lethal,string fieldUpgrade,bool isfavorite,AttachmentClass primaryatt,AttachmentClass secondaryatt,StaticItemData.GroupColor group)
        {
            Name = name;
            Primary = primary;
            Secondary = secondary;
            Perk1 = perk1;
            Perk2 = perk2;
            Perk3 = perk3;
            Perk4 = perk4;
            Perk5 = perk5;
            Perk6 = perk6;
            Wildcard = wildcard;
            Tactical = tactical;
            Lethal = lethal;
            FieldUpgrade = fieldUpgrade;
            isFavorite = isfavorite;
            primaryAtt = primaryatt;
            secondaryAtt = secondaryatt;
            Group = group;
        }
        public ClassBuild()
        {
            Name = "Default Build";
            Primary = "XM4";
            Secondary = "1911";
            Perk1 = "ENGINEER";
            Perk2 = "ASSASSIN";
            Perk3 = "GUNG-HO";
            Perk4 = "NONE";
            Perk5 = "NONE";
            Perk6 = "NONE";
            Wildcard = "DANGER CLOSE";
            Tactical = "STUN GRENADE";
            Lethal = "FRAG";
            FieldUpgrade = "PROXIMITY MINE";
            primaryAtt = new AttachmentClass();
            secondaryAtt = new AttachmentClass();
            Group = null;
        }
        public static ClassBuild loadFromSaveString(string s)
        {
            
            String[] vs = s.Split(',');
          /*  Console.WriteLine("Clasbuild.loadFromSaveString: load");
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }*/
            ClassBuild ret = new ClassBuild();
            ret.Name = vs[0];
            ret.Primary = vs[1];
            ret.Secondary = vs[3];
            ret.Perk1 = vs[5];
            ret.Perk2 = vs[6];
            ret.Perk3 = vs[7];
            ret.Perk4 = vs[8];
            ret.Perk5 = vs[9];
            ret.Perk6 = vs[10];
            ret.Wildcard = vs[11];
            ret.Tactical = vs[12];
            ret.Lethal = vs[13];
            ret.FieldUpgrade = vs[14];
            //if (vs.Length >= 16)
                ret.isFavorite = bool.Parse(vs[15]);
            if (vs.Length >= 17)
                ret.Group = StaticItemData.GetGroupColorByName(vs[16]);
            ret.primaryAtt = AttachmentClass.GetAttachmentClassFromString(vs[2]);
            ret.secondaryAtt =AttachmentClass.GetAttachmentClassFromString(vs[4]);
            return ret;
        }
        public ClassTitleControl GetTitleControl()
        {
            return new ClassTitleControl(this);
        }
        public override string ToString()
        {
            string[] ls = new string[] { Name, Primary, primaryAtt.ToString(), Secondary, secondaryAtt.ToString(), Perk1, Perk2, Perk3, Perk4, Perk5, Perk6, Wildcard, Tactical, Lethal, FieldUpgrade, isFavorite.ToString(),(Group!=null)? Group.Name:"" };
            return String.Join(",",ls);
        }

        public ClassBuild Clone()
        {
            return new ClassBuild(BuildManager.getNextAvailableName(Name), Primary, Secondary, Perk1, Perk2, Perk3, Perk4, Perk5, Perk6, Wildcard, Tactical, Lethal, FieldUpgrade, isFavorite, primaryAtt.Clone(), secondaryAtt.Clone(),Group);
        }
       
    }
}
