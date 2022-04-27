using CosmosKernel1;
using CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Cosmos.System.Graphics;

namespace resolution.Graphical_Resource_Pack
{
    class TextBox
    {
        public void textbox(VBECanvas vbe, int x, int y, int width, int height, string content)
        {
            vbe.DrawFilledRectangle(new Pen(Color.White), x, y, width, height);
            vbe.DrawRectangle(new Pen(Color.Black), x, y, width, height);
            int why = (height / 2) - 6;
            ASC16.DrawACSIIString(vbe, content, Color.Black, (uint)x + 3, (uint)y + (uint)why);
        }
    }
}
