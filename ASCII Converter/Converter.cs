using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASCII_Converter
{
    class Converter
    {
        private readonly char[] _asciiTable = { '.', ',', ':', '+', '*', '?', '%', '$', '#', '@' };
        private readonly Bitmap _bitmap;
        public Converter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public char [][] Convert()
        {
            var result = new char[_bitmap.Height][];
            for (int i = 0; i < _bitmap.Height; i++)
            {
                result[i] = new char[_bitmap.Width];
                for (int j = 0; j < _bitmap.Width; j++)
                {
                    int index = (int)ToMap(_bitmap.GetPixel(j, i).R, 0, 255, 0, _asciiTable.Length - 1);
                    result[i][j] = _asciiTable[index];
                }

            }
            return result;
        }

        private float ToMap(float value, float start1, float stop1, float start2, float stop2)
        {
            return ((value - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }
}
