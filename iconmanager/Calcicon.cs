using Cosmos.System.Graphics;
using CosmosKernel1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace resolution.iconmanager
{
    class Calcicon
    {
        //30(w);
        public static byte[] bigcalc = new byte[]
        {
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            1,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,2,1,
            1,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,2,1,
            1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,
            1,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,3,3,2,1,
            1,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,3,3,2,1,
            1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,3,3,2,1,
            1,3,3,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,0,0,0,3,3,2,1,
            1,3,3,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,0,0,0,3,3,2,1,
            1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,0,0,0,3,3,2,1,
            1,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,3,3,2,1,
            1,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0,3,3,2,1,
            1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2,1,
            1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
        };
        public static void normalcalc(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 15; h++)
            {
                for (uint w = 0; w < 30; w++)
                {
                    if (bigcalc[h * 30 + w] == 0)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.LightSlateGray), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (bigcalc[h * 30 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (bigcalc[h * 30 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.DarkGray), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (bigcalc[h * 30 + w] == 3)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (bigcalc[h * 30 + w] == 4)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.CadetBlue), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }
    }
}
