using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SubTools
{
    public class SubTools
    {
        public static void checkDataFolder(string steamdir)
        {
            if (Directory.Exists(steamdir + @"/SMS_DATA"))
            {
                return;
            }

            Directory.CreateDirectory(steamdir + @"/SMS_DATA");
        }
        public static string getFolderState(string steamdir)
        {
            if (Directory.Exists(steamdir + @"/QMods"))
            {
                return @"Mods are currently enabled.";
            }
            return @"Mods are currently disabled.";
        }
        public static bool getFolderStateBool(string steamdir)
        {
            if (Directory.Exists(steamdir + @"/QMods"))
            {
                return true;
            }
            return false;
        }

        public static string getFolderText() {
            try {
                System.IO.File.ReadAllText(@"./path.txt");
            } catch {
                using (FileStream fs = File.Create(@"./path.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("//Replace this line with the path to your Subnautica folder.");
                    fs.Write(info, 0, info.Length);
                    MessageBox.Show(@"Please find the file named ""path.txt"" in the same folder as this, and add the path to your Subnautica folder.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return System.IO.File.ReadAllText(@"./path.txt");
        }
        public static Icon getIcon() {
        byte[] imagebytes = Convert.FromBase64String("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");
        Image img;
        using (MemoryStream msimage = new MemoryStream(imagebytes))
        {
            img = Image.FromStream(msimage);
        }
        var ms = new System.IO.MemoryStream();
        var bw = new System.IO.BinaryWriter(ms);
        // Header
        bw.Write((short)0);   // 0 : reserved
        bw.Write((short)1);   // 2 : 1=ico, 2=cur
        bw.Write((short)1);   // 4 : number of images
        // Image directory
        var w = img.Width;
        if (w >= 256) w = 0;
        bw.Write((byte)w);    // 0 : width of image
        var h = img.Height;
        if (h >= 256) h = 0;
        bw.Write((byte)h);    // 1 : height of image
        bw.Write((byte)0);    // 2 : number of colors in palette
        bw.Write((byte)0);    // 3 : reserved
        bw.Write((short)0);   // 4 : number of color planes
        bw.Write((short)0);   // 6 : bits per pixel
        var sizeHere = ms.Position;
        bw.Write((int)0);     // 8 : image size
        var start = (int)ms.Position + 4;
        bw.Write(start);      // 12: offset of image data
        // Image data
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        var imageSize = (int)ms.Position - start;
        ms.Seek(sizeHere, System.IO.SeekOrigin.Begin);
        bw.Write(imageSize);
        ms.Seek(0, System.IO.SeekOrigin.Begin);

        // And load it
        return new Icon(ms);
    }
    }
}
