using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cold_War_Class_Storage_V2
{
    public static class StaticItemData
    {
        public static List<IconClass> LethalList,TechnicalList,FieldUpgradeList,WildCardList;
        public static List<Perk> PerkList;
        public static List<GunClass> AssaultRiflesList, SMGList, TacticalRiflesList, LMGList, SniperRiflesList,SecondaryList;
        public static List<string> OpticList, MuzzleList, BarrelList, BodyList, UnderbarrelList, MagazineList, HandleList, StockList;
        public static List<GroupColor> GroupColors;
        //save data
        //Optic, Muzzle, Barrel, Body, Underbarrel, Magazine, GunHandle, Stock for the second int
        public static List<Tuple<string, int>> AttachmentsToAdd = new List<Tuple<string, int>>();
        public static List<Tuple<StaticItemData.GunClass, int>> GunsToAdd = new List<Tuple<StaticItemData.GunClass, int>>();
        public static List<GunBuildSave> SavedGunBuilds = new List<GunBuildSave>();
        public static void ClearAllData()
        {
            Console.WriteLine("StaticItemData.ClearAllData: maybe make a method on form 1 to clear its data too");
            AttachmentsToAdd.Clear();
            GunsToAdd.Clear();

            LethalList.Clear();
            TechnicalList.Clear();
            FieldUpgradeList.Clear();
            WildCardList.Clear();
            PerkList.Clear();

            AssaultRiflesList.Clear();
            SMGList.Clear();
            TacticalRiflesList.Clear();
            LMGList.Clear();
            SniperRiflesList.Clear();
            SecondaryList.Clear();

            OpticList.Clear();
            MuzzleList.Clear();
            BarrelList.Clear();
            BodyList.Clear();
            UnderbarrelList.Clear();
            MagazineList.Clear();
            HandleList.Clear();
            StockList.Clear();

            BuildManager.CurrentBuild = null;
            BuildManager.builds.Clear();
            SavedGunBuilds.Clear();
        }
        
        
        //save stuff
        public static string GenerateSaveFile()
        {
            string ret = "^^Attachments\n";
            AttachmentsToAdd.ForEach(e => ret += e.Item1 + "," + e.Item2 + "\n");
            ret += "^^Guns\n";
            GunsToAdd.ForEach(e => ret += e.Item2+"," +e.Item1.ToString());
            ret += "^^Builds\n";
            BuildManager.builds.ForEach(e => ret += e.ToString() + "\n");
            ret += "^^SavedGuns\n";
            SavedGunBuilds.ForEach(e => ret +=e.ToString()+"\n");
            return ret;
        }
        public static void LoadFromFile(string filename,Form1 form)
        {
            ClearAllData();
            Loaded = false;
            load();
            string v = File.ReadAllText(filename);
            //attachments
            Match mat = Regex.Match(v, @"\^\^Attachments[^\^]+");
            string[] vs = mat.Value.Split('\n');
            foreach (string s in vs)
            {
                if (s != "^^Attachments" && s.Length>1)
                {
                    Console.WriteLine("load from file: " + s);
                    string[] nameType = s.Split(',');
                    AttachmentsToAdd.Add(new Tuple<string, int>(nameType[0], int.Parse(nameType[1])));
                    switch (nameType[1])
                    {
                        case "0":
                            OpticList.Add(nameType[0]);
                            break;
                        case "1":
                            MuzzleList.Add(nameType[0]);
                            break;
                        case "2":
                            BarrelList.Add(nameType[0]);
                            break;
                        case "3":
                            BodyList.Add(nameType[0]);
                            break;
                        case "4":
                            UnderbarrelList.Add(nameType[0]);
                            break;
                        case "5":
                            MagazineList.Add(nameType[0]);
                            break;
                        case "6":
                            HandleList.Add(nameType[0]);
                            break;
                        case "7":
                            StockList.Add(nameType[0]);
                            break;
                    }
                }
            }
            //guns
            mat = Regex.Match(v, @"\^\^Guns[^\^]+");
            vs = mat.Value.Split('\n');
            foreach (string s in vs)
            {
                if (s != "^^Guns" && s.Length > 1)
                {
                    //Name+","+StaticItemData.ImageToBase64(this.Image);
                    string[] typeName64 = s.Split(',');
                    GunClass gunClass = new GunClass(typeName64[1], Base64ToImage(typeName64[2]));
                    switch (typeName64[0])
                    {
                        case "0":
                            AssaultRiflesList.Add(gunClass);
                            break;
                        case "1":
                            SMGList.Add(gunClass);
                            break;
                        case "2":
                            TacticalRiflesList.Add(gunClass);
                            break;
                        case "3":
                            LMGList.Add(gunClass);
                            break;
                        case "4":
                            SniperRiflesList.Add(gunClass);
                            break;
                        case "5":
                            SecondaryList.Add(gunClass);
                            break;
                    }
                    GunsToAdd.Add(new Tuple<GunClass, int>(gunClass, int.Parse(typeName64[0])));
                }
            }
            //builds
            mat = Regex.Match(v, @"\^\^Builds[^\^]+");
            vs = mat.Value.Split('\n');
            foreach (string s in vs)
            {
                if (s != "^^Builds" && s.Length > 1)
                {
                    BuildManager.builds.Add(ClassBuild.loadFromSaveString(s));
                }
            }
            //saved guns
            mat = Regex.Match(v, @"\^\^SavedGuns[^\^]+");
            vs = mat.Value.Split('\n');
            foreach (string s in vs)
            {
                if (s != "^^SavedGuns" && s.Length > 1)
                    SavedGunBuilds.Add(GunBuildSave.LoadFromString(s));
            }
            form.RefreshBuildList();
        }
        public static string ImageToBase64(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        public static Image Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public static GroupColor GetGroupColorByName(String name)
        {
            if (GroupColors.Any(e => e.Name == name))
                return GroupColors.First(e => e.Name == name);
            return null;
        }
        public static GunBuildSave GetSavedGunBuildByName(string name)
        {
            return SavedGunBuilds.First(e => e.BuildName == name);
        }
        public static List<GunClass> getPrimaries()
        {
            List<GunClass> guns = new List<GunClass>();
            guns.AddRange(AssaultRiflesList);
            guns.AddRange(SMGList);
            guns.AddRange(TacticalRiflesList);
            guns.AddRange(LMGList);
            guns.AddRange(SniperRiflesList);
            return guns;
        }
        public static IconClass GetIconByName(string name, List<IconClass> l)
        {
            IconClass ret = l.First(e => e.Name.Equals(name));
            if(ret==null)
                return new IconClass("None", Properties.Resources.Blank_Perk);
            return ret;
            
        }
        public static Perk GetPerkByName(String name)
        {
            if(name=="None" || name == "NONE")
                return new Perk("NONE", Properties.Resources.Blank_Perk, 1);
            Console.WriteLine("StaticItemData.GetPerkByName: " + name);
            Perk ret = PerkList.First(e => e.Name.Equals(name));
            if (ret == null)
                return new Perk("None", Properties.Resources.Blank_Perk,1);
            return ret;
        }
        public static GunClass GetGunClassByName(string name)
        {
            Console.WriteLine("StaticItemData.GetGunClassByName: " + name);
            List<GunClass> guns = new List<GunClass>();
            guns.AddRange(AssaultRiflesList);
            guns.AddRange(SMGList);
            guns.AddRange(TacticalRiflesList);
            guns.AddRange(LMGList);
            guns.AddRange(SniperRiflesList);
            guns.AddRange(SecondaryList);
            if(!guns.Any(e=>e.Name.Equals(name)))
                return new GunClass("NONE", Properties.Resources.Blank_Perk);
            return guns.First(e => e.Name.Equals(name));
        }
        public static bool HasAttachment(string name)
        {
            List<String> c = new List<string>();
            c.AddRange(OpticList);
            c.AddRange(MuzzleList);
            c.AddRange(BarrelList);
            c.AddRange(BodyList);
            c.AddRange(UnderbarrelList);
            c.AddRange(MagazineList);
            c.AddRange(HandleList);
            c.AddRange(StockList);
            return c.Contains(name);
        }
        public static bool Loaded;
        public static void load()
        {
            if (Loaded)
                return;
            perks();
            lethals();
            technicals(); 
            fieldupgrades();
            wildcards();
            groupcolors();
            guns();
            attachments();
             Loaded = true;
        }
        //preloaded data that I decided to put in different methods
        private static void attachments()
        {
            //optic
            OpticList = new List<string>();
            OpticList.Add("Quickdot LED");
            OpticList.Add("Millstop Reflex");
            OpticList.Add("Kobra Reddot Sight");
            OpticList.Add("Silex Holoscout");
            OpticList.Add("Visiontech 2x");
            OpticList.Add("Axial Arms 3x");
            OpticList.Add("Royal  Kross 4x");
            OpticList.Add("Iron Sights");
            OpticList.Add("Microflex LED");
            OpticList.Add("Hawksmoor");
            OpticList.Add("Snappoint");
            OpticList.Add("Diamondback Reflex");
            OpticList.Add("Fastpoint Reflex");
            OpticList.Add("SUSAT Multizoom");
            OpticList.Add("AN/PVS-4 Thermal");
            OpticList.Add("Noch Sova Thermal");
            OpticList.Add("Hangman RF");
            OpticList.Add("Vulture Custom Zoom");
            OpticList.Add("Ultrazoom Custom");
            OpticList.Add("Ottero Mini Reflex");
            OpticList.Add("None");
            //muzzle
            MuzzleList = new List<string>();
            MuzzleList.Add("Silencer");
            MuzzleList.Add("Suppressor");
            MuzzleList.Add("Sound Moderator");
            MuzzleList.Add("Infantry Compensator");
            MuzzleList.Add("Spetsnaz Compensator");
            MuzzleList.Add("Infantry Stabilizer");
            MuzzleList.Add("Infantry V-Choke");
            MuzzleList.Add("SOCOM Elimination");
            MuzzleList.Add("KGB Eliminator");
            MuzzleList.Add("Task Force Shroud");
            MuzzleList.Add("SOCOM Blast Mitigator");
            MuzzleList.Add("Agency Suppressor");
            MuzzleList.Add("GRU Suppressor");
            MuzzleList.Add("Wrapper Suppressor");
            MuzzleList.Add("Agency Choke");
            MuzzleList.Add("Muzzle Break");
            MuzzleList.Add("Duckbill Choke");
            MuzzleList.Add("None");
            //barrel
            BarrelList = new List<string>();
            BarrelList.Add("Extended");
            BarrelList.Add("Cavalry Lancer");
            BarrelList.Add("Rapid Fire");
            BarrelList.Add("Ranger");
            BarrelList.Add("Liberator");
            BarrelList.Add("Reinforced Heavy");
            BarrelList.Add("VDV Reinforced");
            BarrelList.Add("Cortour");
            BarrelList.Add("Ultralight");
            BarrelList.Add("CMV MIL-Spec");
            BarrelList.Add("Spetsnaz RPK Barrel");
            BarrelList.Add("Rifled");
            BarrelList.Add("Titanium");
            BarrelList.Add("Cut Down");
            BarrelList.Add("Division");
            BarrelList.Add("SOR Cut Down");
            BarrelList.Add("GRU Cut Down");
            BarrelList.Add("Combat Recon");
            BarrelList.Add("Tiger Team");
            BarrelList.Add("Hammer Forged");
            BarrelList.Add("Chrome Lines");
            BarrelList.Add("Match Grade");
            BarrelList.Add("Takedown");
            BarrelList.Add("Task Force");
            BarrelList.Add("None");
            //Body
            BodyList = new List<string>();
            BodyList.Add("Steady Aim Laser");
            BodyList.Add("Swat 5mw Laser Sight");
            BodyList.Add("Mounted Flashlight");
            BodyList.Add("SOF Target Designator");
            BodyList.Add("KGB Target Designator");
            BodyList.Add("GRU 5mv Laser Sight");
            BodyList.Add("Tiger Team Spotlight");
            BodyList.Add("Ember Sighting Point");
            BodyList.Add("None");
            //underbarrel
            UnderbarrelList = new List<string>();
            UnderbarrelList.Add("Foregrip");
            UnderbarrelList.Add("Red Cell Foregrip");
            UnderbarrelList.Add("Patrol Grip");
            UnderbarrelList.Add("Front Grip");
            UnderbarrelList.Add("Infiltrator Grip");
            UnderbarrelList.Add("Bruiser Grip");
            UnderbarrelList.Add("Field Agent Grip");
            UnderbarrelList.Add("Spetznaz Grip");
            UnderbarrelList.Add("Field Agent Foregrip");
            UnderbarrelList.Add("Spetsnaz Ergonomic Grip");
            UnderbarrelList.Add("Bipod");
            UnderbarrelList.Add("SFOD Speedgrip");
            UnderbarrelList.Add("Spetsnaz Speedgrip");
            UnderbarrelList.Add("None");
            //Magazine
            MagazineList = new List<string>();
            MagazineList.Add("40 Round mag");
            MagazineList.Add("Fast Mag");
            MagazineList.Add("40 Rd Speed Mag");
            MagazineList.Add("Jungle-Style Mag");
            MagazineList.Add("Taped Mag");
            MagazineList.Add("Fast Loader");
            MagazineList.Add("STANAG Mag");
            MagazineList.Add("Bakelite Mag");
            MagazineList.Add("Spetsnaz Mag");
            MagazineList.Add("SAS Mag Clamp");
            MagazineList.Add("GRU Mag Clamp");
            MagazineList.Add("Vandal Speed Loader");
            MagazineList.Add("Salvo Fast Mag");
            MagazineList.Add("VDV Fast Mag");
            MagazineList.Add("STANAG 18 RND Drum");
            MagazineList.Add("STANAG 12 RND Tube");
            MagazineList.Add("None");
            //handle
            HandleList = new List<string>();
            HandleList.Add("Speed Tape");
            HandleList.Add("Mike Force Rear Grip");
            HandleList.Add("Dropshot Tape");
            HandleList.Add("Field Tape");
            HandleList.Add("SASR Jungle Grip");
            HandleList.Add("Spetsnaz Field Grip");
            HandleList.Add("Serpent Wrap");
            HandleList.Add("Airborne Elastic Wrap");
            HandleList.Add("GRU Elastic Wrap");
            HandleList.Add("None");
            //stock
            StockList = new List<string>();
            StockList.Add("Tactical Stock");
            StockList.Add("Sprint Pad");
            StockList.Add("Wire Stock");
            StockList.Add("Marathon Stock");
            StockList.Add("Collapsed Stock");
            StockList.Add("CQB Stock");
            StockList.Add("Shotgun Stock");
            StockList.Add("Duster Pad");
            StockList.Add("Duster Stock");
            StockList.Add("Buffer Tube");
            StockList.Add("No Stock");
            StockList.Add("SAS Combat stock");
            StockList.Add("Spetsnaz PKM Stock");
            StockList.Add("Raider Pad");
            StockList.Add("Raider Stock");
            StockList.Add("KGB Pad");
            StockList.Add("KGB Skeletal Stock");
            StockList.Add("Dual Wield");
            StockList.Add("None");


        }
        private static void guns()
        {
            //assault rifles
            AssaultRiflesList = new List<GunClass>();
            AssaultRiflesList.Add(new GunClass("xm4",Properties.Resources.XM4));
            AssaultRiflesList.Add(new GunClass("AK-47", Properties.Resources.AK_47));
            AssaultRiflesList.Add(new GunClass("Krig 6", Properties.Resources.Krig_6));
            AssaultRiflesList.Add(new GunClass("qbz-83", Properties.Resources.QBZ_83));
            AssaultRiflesList.Add(new GunClass("FFAR 1", Properties.Resources.FFAR_1));
            AssaultRiflesList.Add(new GunClass("Groza", Properties.Resources.Groza));
            AssaultRiflesList.Add(new GunClass("Fara 83", Properties.Resources.Fara_83));
            //Sub machine guns
            SMGList = new List<GunClass>();
            SMGList.Add(new GunClass("mp5", Properties.Resources.MP5));
            SMGList.Add(new GunClass("Milano 821", Properties.Resources.Milano_821));
            SMGList.Add(new GunClass("AK-74u", Properties.Resources.AK_74u));
            SMGList.Add(new GunClass("KSP 45", Properties.Resources.KSP_45));
            SMGList.Add(new GunClass("Bullfrog", Properties.Resources.Bullfrog));
            SMGList.Add(new GunClass("Mac-10", Properties.Resources.MAC_10));
            SMGList.Add(new GunClass("LC10", Properties.Resources.LC10));
            //Tactical rifles
            TacticalRiflesList = new List<GunClass>();
            TacticalRiflesList.Add(new GunClass("Type 63", Properties.Resources.Type_63));
            TacticalRiflesList.Add(new GunClass("M16", Properties.Resources.M16));
            TacticalRiflesList.Add(new GunClass("AUG", Properties.Resources.AUG));
            TacticalRiflesList.Add(new GunClass("DMR 14", Properties.Resources.DMR_14));
            //Lmgs
            LMGList = new List<GunClass>();
            LMGList.Add(new GunClass("Stoner 63", Properties.Resources.Stoner_63));
            LMGList.Add(new GunClass("RPD", Properties.Resources.RPD));
            LMGList.Add(new GunClass("M60", Properties.Resources.M60));
            //snipers
            SniperRiflesList = new List<GunClass>();
            SniperRiflesList.Add(new GunClass("pelington 703", Properties.Resources.Pelington_703));
            SniperRiflesList.Add(new GunClass("lw3-tundra", Properties.Resources.LW3_Tundra));
            SniperRiflesList.Add(new GunClass("m82", Properties.Resources.M82)); 
            SniperRiflesList.Add(new GunClass("zrg 20mm", Properties.Resources.ZRG_20mm));
            //secondarys
            SecondaryList = new List<GunClass>();
            SecondaryList.Add(new GunClass("1911", Properties.Resources._1911));
            SecondaryList.Add(new GunClass("Magnum", Properties.Resources.Magnum));
            SecondaryList.Add(new GunClass("Diamatti", Properties.Resources.Diamatti));
            SecondaryList.Add(new GunClass("Hauer 77", Properties.Resources.Hauer_77));
            SecondaryList.Add(new GunClass("Gallow sa12", Properties.Resources.Gallo_SA12));
            SecondaryList.Add(new GunClass("streetsweeper", Properties.Resources.Streetsweeper));
            SecondaryList.Add(new GunClass("Cigma 2", Properties.Resources.Cigma_2));
            SecondaryList.Add(new GunClass("RPG-7", Properties.Resources.RPG_7));
            SecondaryList.Add(new GunClass("Knife", Properties.Resources.Knife));
            SecondaryList.Add(new GunClass("Slegehammer", Properties.Resources.Sledgehammer));
            SecondaryList.Add(new GunClass("wakizashi", Properties.Resources.Wakizashi));
            SecondaryList.Add(new GunClass("E-Tool", Properties.Resources.E_Tool));
            SecondaryList.Add(new GunClass("Machete", Properties.Resources.Machete));
            SecondaryList.Add(new GunClass("M79", Properties.Resources.M79));
            SecondaryList.Add(new GunClass("R1 Shadowhunter", Properties.Resources.R1_Shadowhunter));
        }
        private static void wildcards()
        {
            WildCardList = new List<IconClass>();
            WildCardList.Add(new IconClass("Danger close", Properties.Resources.DangerClose));
            WildCardList.Add(new IconClass("Law Breaker", Properties.Resources.Law_Breaker));
            WildCardList.Add(new IconClass("Gunfighter", Properties.Resources.Gunfighter));
            WildCardList.Add(new IconClass("Perk greed", Properties.Resources.Perk_Greed));
        }
        private static void fieldupgrades()
        {
            FieldUpgradeList = new List<IconClass>();
            FieldUpgradeList.Add(new IconClass("pROXIMITY mINE",Properties.Resources.Proximity_Mine));
            FieldUpgradeList.Add(new IconClass("field mic", Properties.Resources.Field_Mic));
            FieldUpgradeList.Add(new IconClass("Trophy system", Properties.Resources.Trophy_System));
            FieldUpgradeList.Add(new IconClass("assault pack", Properties.Resources.Assault_Pack));
            FieldUpgradeList.Add(new IconClass("sam turret", Properties.Resources.Sam_Turret));
            FieldUpgradeList.Add(new IconClass("jammer", Properties.Resources.Jammer));
            FieldUpgradeList.Add(new IconClass("gas mine", Properties.Resources.Gas_Mine));
        }
        private static void technicals()
        {
            TechnicalList = new List<IconClass>();
            TechnicalList.Add(new IconClass("Stun Grenade", Properties.Resources.Stun_Grenade));
            TechnicalList.Add(new IconClass("Stimshot", Properties.Resources.Stimshot));
            TechnicalList.Add(new IconClass("Smoke Grenade", Properties.Resources.Smoke_Grenade));
            TechnicalList.Add(new IconClass("Flashbang", Properties.Resources.Flashbang));
            TechnicalList.Add(new IconClass("Decoy", Properties.Resources.Decoy));
        }
        private static void lethals()
        {
            LethalList = new List<IconClass>();
            LethalList.Add(new IconClass("Frag",Properties.Resources.Frag));
            LethalList.Add(new IconClass("C4", Properties.Resources.C4));
            LethalList.Add(new IconClass("Semtex", Properties.Resources.Semtex));
            LethalList.Add(new IconClass("Molotov", Properties.Resources.Molotov));
            LethalList.Add(new IconClass("Tomahawk", Properties.Resources.Tomahawk));
        }
        private static void perks()
        {
            PerkList = new List<Perk>();
            //type 1
            PerkList.Add(new Perk("Engineer", Properties.Resources.Engineer, 1));
            PerkList.Add(new Perk("Paranoia", Properties.Resources.Paranoia, 1));
            PerkList.Add(new Perk("Flak Jacket", Properties.Resources.Flak_Jacket, 1));
            PerkList.Add(new Perk("Tactical Mask", Properties.Resources.Tactical_Mask, 1));
            PerkList.Add(new Perk("Forward Intel", Properties.Resources.Forward_Intel, 1));
            //type 2
            PerkList.Add(new Perk("Assassin", Properties.Resources.Assassin, 2));
            PerkList.Add(new Perk("Gearhead", Properties.Resources.Gearhead, 2));
            PerkList.Add(new Perk("Quartermaster", Properties.Resources.Quartermaster, 2));
            PerkList.Add(new Perk("Scavenger", Properties.Resources.Scavenger, 2));
            PerkList.Add(new Perk("Tracker", Properties.Resources.Tracker, 2));
            //type 3
            PerkList.Add(new Perk("Cold Blooded", Properties.Resources.Cold_Blooded, 3));
            PerkList.Add(new Perk("ghost", Properties.Resources.Ghost, 3));
            PerkList.Add(new Perk("gung-ho", Properties.Resources.Gung_Ho, 3));
            PerkList.Add(new Perk("ninja", Properties.Resources.Ninja, 3));
            PerkList.Add(new Perk("Spycraft", Properties.Resources.Spycraft, 3));
        }
        private static void groupcolors()
        {
            GroupColors = new List<GroupColor>();
            GroupColors.Add(new GroupColor("Blue",Properties.Resources.blue_star,Properties.Resources.blue_circle));
            GroupColors.Add(new GroupColor("Cyan", Properties.Resources.cyan_star, Properties.Resources.cyan_circle));
            GroupColors.Add(new GroupColor("Green", Properties.Resources.green_star, Properties.Resources.green_circle));
            GroupColors.Add(new GroupColor("Lime", Properties.Resources.lime_star, Properties.Resources.lime_circle));
            GroupColors.Add(new GroupColor("Orange", Properties.Resources.orange_star, Properties.Resources.orange_circle));
            GroupColors.Add(new GroupColor("Pink", Properties.Resources.pink_star, Properties.Resources.pink_circle));
            GroupColors.Add(new GroupColor("Purple", Properties.Resources.purple_star, Properties.Resources.purple_circle));
            GroupColors.Add(new GroupColor("Red", Properties.Resources.red_star, Properties.Resources.red_circle));
            GroupColors.Add(new GroupColor("Yellow", Properties.Resources.yellow_star, Properties.Resources.yellow_circle));
          

        }
        public class Perk : IconClass
        {
            public int PerkType;
            public Perk(String name, Image image, int type) : base(name, image)
            {
                PerkType = type;
            }
        }
        public class GunClass:IconClass
        {
            public AttachmentClass Attachments;
            public GunClass(string name,Image image):base(name,image)
            {

            }
            public GunControl GetGunControl()
            {
                return new GunControl(this);
            }
            public override string ToString()
            {
                return Name+","+StaticItemData.ImageToBase64(this.Image);
            }
            public GunBuildSave GetBuildSave(String buildname)
            {
                GunBuildSave b = new GunBuildSave(buildname,new GunClass(Name, this.Image));
                if(Attachments!=null)
                    b.Attachments = this.Attachments.Clone();
                return b;
            }

            public GunClass Clone()
            {
                return new GunClass(Name, Image); 
            }
        }
        public class GunBuildSave:GunClass
        {
            public String BuildName;
            public GunBuildSave(String buildName,GunClass x) : base(x.Name,x.Image)
            {
                BuildName = buildName.ToUpper() ;
            }
            public override string ToString()
            {
                return BuildName + "," + Name + "," + this.Attachments;
            }
            public static GunBuildSave LoadFromString(string s)
            {
                Console.WriteLine("StaticItemData.GunBuildSave.LoadFromString: " + s);
                string[] vs = s.Split(',');
                GunBuildSave gunBuildSave = GetGunClassByName(vs[1]).GetBuildSave(vs[0]);
                gunBuildSave.Attachments = AttachmentClass.GetAttachmentClassFromString(vs[2]);
                return gunBuildSave;
            }
        }
        public class GroupColor
        {
            public Image Star, Dot;
            public string Name;
            public GroupColor(string name, Image star,Image dot)
            {
                Name = name;
                Star = star;
                Dot = dot;
            }
        }
    }
}
