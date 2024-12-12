using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGMT;

namespace ShrimpCounter
{
    public class ShrimpYolo
    {
        public static Segmented Count(Bitmap bmp) 
        {
            Segmented result = Program.segmentor.Segment(bmp);

            result.count = result.polygons.Length;

            return result;
        }

    }
}
