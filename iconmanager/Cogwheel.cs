using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.System.Graphics;
using CosmosKernel1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace resolution.iconmanager
{
    class Cogwheel
    {
        //9x9 version
        public static byte[] cogwheel = new byte[]
        {
            0,0,0,0,0,0,0,0,0,
            0,1,2,0,1,2,0,1,0,
            0,0,1,2,1,2,1,2,0,
            0,2,2,1,1,1,2,0,0,
            0,1,1,1,0,1,1,1,0,
            0,0,2,1,1,1,2,2,0,
            0,2,1,2,1,2,1,0,0,
            0,1,0,2,1,0,2,1,0,
            0,0,0,0,0,0,0,0,0,
        };

        public static void drawcogwheel(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 9; h++)
            {
                for (uint w = 0; w < 9; w++)
                {
                    if (cogwheel[h * 9 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (cogwheel[h * 9 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen (Color.LightGray), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }
    }
}
