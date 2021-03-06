using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SubTools
{
    public class SubTools
    {
        public static string getFolderState(string steamdir)
        {
            if (Directory.Exists(steamdir + @"Subnautica\QMods"))
            {
                return @"Mods are currently enabled.";
            }
            else
            {
                return @"Mods are currently disabled.";
            }
        }
        public static string getFolderText() {
            try {
                System.IO.File.ReadAllText(@"./path.txt");
            } catch {
                using (FileStream fs = File.Create(@"./path.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("//Replace this line with the path to your steamapps folder.");
                    fs.Write(info, 0, info.Length);
                    MessageBox.Show(@"Please find the file named ""path.txt"" in the same folder as this, and add the path to your steamapps folder.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return System.IO.File.ReadAllText(@"./path.txt");
        }
    }
}
