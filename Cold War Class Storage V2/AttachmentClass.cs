using System;
namespace Cold_War_Class_Storage_V2
{
    public class AttachmentClass
    {
        public string Optic, Muzzle, Barrel, Body, Underbarrel, Magazine, GunHandle, Stock;

        public AttachmentClass(string optic, string muzzle, string barrel, string body, string underbarrel, string magazine, string handle, string stock)
        {
            Optic = optic;
            Muzzle = muzzle;
            Barrel = barrel;
            Body = body;
            Underbarrel = underbarrel;
            Magazine = magazine;
            GunHandle = handle;
            Stock = stock;
        }

        public AttachmentClass()
        {
            Optic = "None";
            Muzzle = "None";
            Barrel = "None";
            Body = "None";
            Underbarrel = "None";
            Magazine = "None";
            GunHandle = "None";
            Stock = "None";
        }

        
        public static AttachmentClass GetAttachmentClassFromString(string v)
        {
            string[] vs = v.Split('|');
            Console.WriteLine("AttachmentClass.GetAttachmentClassFromString: "+v);
            AttachmentClass ret = new AttachmentClass();
           /* Console.WriteLine("loading atts:");
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }*/
            
            ret.Optic = vs[0];
            ret.Muzzle = vs[1];
            ret.Barrel = vs[2];
            ret.Body = vs[3];
            ret.Underbarrel = vs[4];
            ret.Magazine = vs[5];
            ret.GunHandle = vs[6];
            ret.Stock = vs[7];
            return ret;
        }

        public int getAttachmentCount()
        {
            int ret = 0;
            string[] vs = new string[] { Optic, Muzzle, Barrel, Body, Underbarrel, Magazine, GunHandle, Stock };
            for (int i = 0; i < vs.Length; i++)
            {
                ret += vs[i] != "None" ? 1 : 0;
            }
            return ret;
        }
        public string getConsoleString()
        {
            return "Attachments: Optic" + Optic + "\nMuzzle" + Muzzle + "\nBarrel" + Barrel + "\nBody" + Body + "\nUnderbarrel" + Underbarrel + "\nMagazine" + Magazine + "\nGunHandle" + GunHandle + "\nStock" + Stock + "\n";
        }
        public void RemoveLastThreeAttachments()
        {
            Stock = "None";
            GunHandle = "None";
            Magazine = "None";
        }
        public AttachmentClass Clone()
        {
            return new AttachmentClass(Optic, Muzzle, Barrel, Body, Underbarrel, Magazine, GunHandle, Stock);
        }
        public override string ToString()
        {
            return string.Join("|",new string[] { Optic, Muzzle, Barrel, Body, Underbarrel, Magazine, GunHandle, Stock });
        }
    }
}