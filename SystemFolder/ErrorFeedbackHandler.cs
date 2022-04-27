using Cosmos.System.Graphics;
using CosmosKernel1;
using CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace resolution.SystemFolder
{
    class ErrorFeedbackHandler
    {
        //Searching for the source code huh?!
        //I'm really sorry to tell you that it's not implemented yet.
        public void EFH(VBECanvas vbe, int x, int y, string message)
        {
            int width = 250;
            int height = 150;
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
            vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
            vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
            ASC16.DrawACSIIString(vbe, "Error!", Color.White, (uint)x + 5, (uint)y + 3);
            //vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 21, width - 6, height - 23);
            ASC16.DrawACSIIString(vbe, message, Color.Black, (uint)x + 20, (uint)y + 22);
        }
    }
}
