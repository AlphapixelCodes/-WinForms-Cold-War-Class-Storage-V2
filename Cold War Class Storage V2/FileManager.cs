using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2
{
    public static class FileManager
    {
        public static string LastSaveLocation="";
        private static string tempSavePath = Path.GetTempPath() + "ColdWarSaveLocation.txt";
        private static string filter = "Cold War Files (*.cw)|";
        public static string OpenFile(Form1 form)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenFile(ofd.FileName, form);
                
            }
            return Path.GetFileName(LastSaveLocation);
        }
        public static void OpenFile(string v,Form1 form)
        {
            UpdateTempFile(v);
            StaticItemData.LoadFromFile(v,form);
        }
        
        private static bool hasTempFile()
        {
           return File.Exists(tempSavePath);
        }
        private static string getLastSavePath()
        {
            if (LastSaveLocation != "")
                return LastSaveLocation;
            if (hasTempFile())
            {
                string path = File.ReadAllText(tempSavePath);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            return "";
        }
        public static void LoadFromTempFile(Form1 form)
        {
            string p = getLastSavePath();
            if (p != "")
            {
                UpdateTempFile(p);
                StaticItemData.LoadFromFile(p, form);
            }
        }
        private static void UpdateTempFile(string newpath)
        {
            LastSaveLocation = newpath;
            Console.WriteLine("FileManager.UpdateTempFile: " + LastSaveLocation);
            File.WriteAllText(tempSavePath, newpath);
        }
        public static string SaveAsFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = filter;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                UpdateTempFile(sfd.FileName);
                SaveFile(sfd.FileName,false);
                Console.WriteLine("FileManager.SaveAsFile: " + sfd.FileName);
            }
            return Path.GetFileName(LastSaveLocation);
        }
        public static string SaveFile(string v,bool showDialog)
        {
            if (v == "")
            {
                SaveAsFile();
                return Path.GetFileName(LastSaveLocation);
            }
            UpdateTempFile(LastSaveLocation);
            File.WriteAllText(v, StaticItemData.GenerateSaveFile());
            if (showDialog)
                MessageBox.Show("Saved to: " + Path.GetFileName(LastSaveLocation));
            return Path.GetFileName(LastSaveLocation);
        }
    }
}
