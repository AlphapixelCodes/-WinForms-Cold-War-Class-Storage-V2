using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cold_War_Class_Storage_V2.GUIs
{
    public partial class Rename_GUI : Form
    {
        public Rename_GUI()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        public string returnValue = "";
        private void Rename_GUI_Load(object sender, EventArgs e)
        {
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string t= textBox1.Text.ToUpper();
            if (t.Length > 23 || t.Length < 3)
            {
                MessageBox.Show("Must be between 3 and 23 characters", "Character limit");
                return;
            } else if (Regex.IsMatch(t, "[^A-Z 0-9-]+"))
            {
                MessageBox.Show("Name can only contain A-Z 0-9 Space and -", "Illegal characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (BuildManager.hasBuild(t))
            {
                MessageBox.Show("Class already exists by that name", "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            returnValue = t;
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    button1_Click("", new EventArgs());
                    break;
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
    }
}
