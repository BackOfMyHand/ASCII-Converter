using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASCII_Converter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.jpg; *.JPEG; *.png"
            };

            while (true)
            {
                Console.ReadLine();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = Resize(bitmap);
                bitmap.ToGray();

                var convert = new Converter(bitmap);
                var rows = convert.Convert();

                foreach (var row in rows)
                    Console.WriteLine(row);

                Console.SetCursorPosition(0, 0);
            }
        }

        private static Bitmap Resize(Bitmap bitmap)
        {
            var maxWidth = 350;
            var newHeight = bitmap.Height / 1.5 * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(maxWidth, (int)newHeight));
            return bitmap;
        }
    }
}
