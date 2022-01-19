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
            if (steamdir == @"//Replace this line with the path to your steamapps folder.") {
                MessageBox.Show(@"Please find the file named ""path.txt"" in the same folder as this, and add the path to your steamapps folder.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Directory.Move(steamdir + "Subnautica", steamdir + "sub");
            Directory.Move(steamdir + "Subnautica_mod", steamdir + "Subnautica");
            Directory.Move(steamdir + "sub", steamdir + "Subnautica_mod");
            MessageBox.Show("Done.", "Message");
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
