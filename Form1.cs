using System;

using System.Windows.Forms;
using System.IO;

namespace Subnautica_Mod_Swapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string steamdir = SubTools.SubTools.getFolderText();
            label1.Text = SubTools.SubTools.getFolderState(steamdir);
        }
        public string steamdir = SubTools.SubTools.getFolderText();


        private void button1_Click(object sender, EventArgs e)
        {
            if (steamdir == @"//Replace this line with the path to your Subnautica folder.") {
                MessageBox.Show(@"Please find the file named ""path.txt"" in the same folder as this, and add the path to your Subnautica folder.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            SubTools.SubTools.checkDataFolder(steamdir);
            
            if (SubTools.SubTools.getFolderStateBool(steamdir))
            {
                Directory.Move(steamdir + "/BepInEx", steamdir + "/SMS_DATA/BepInEx");
                Directory.Move(steamdir + "/QMods", steamdir + "/SMS_DATA/QMods");
                File.Move(steamdir + "/doorstop_config.ini", steamdir + "/SMS_DATA/doorstop_config.ini");
                File.Move(steamdir + "/winhttp.dll", steamdir + "/SMS_DATA/winhttp.dll");
            }
            else
            {
                Directory.Move(steamdir + "/SMS_DATA/BepInEx", steamdir + "/BepInEx");
                Directory.Move(steamdir + "/SMS_DATA/QMods", steamdir + "/QMods");
                File.Move(steamdir + "/SMS_DATA/doorstop_config.ini", steamdir + "/doorstop_config.ini");
                File.Move(steamdir + "/SMS_DATA/winhttp.dll", steamdir + "/winhttp.dll");
            }

            if (Directory.Exists(steamdir + "/SMS_DATA/SNAppData"))
                {
                    Directory.Move(steamdir + "/SNAppData", steamdir + "/SMS_DATA/SNAppData-temp");
                    Directory.Move(steamdir + "/SMS_DATA/SNAppData", steamdir + "/SNAppData");
                    Directory.Move(steamdir + "/SMS_DATA/SNAppData-temp", steamdir + "/SMS_DATA/SNAppData");
                }
                else
                {
                    Directory.Move(steamdir + "/SNAppData", steamdir + "/SMS_DATA/SNAppData");
                    Directory.CreateDirectory(steamdir + "/SNAppData");
                    Directory.CreateDirectory(steamdir + "/SNAppData/SavedGames");
                }
            MessageBox.Show("Operation completed!");
            this.Close();
        }
        private void no_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e){}
    }
}
