using Cosmos.System;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Cosmos.System.Graphics;

namespace resolution
{
    class Window
    {
        public bool fwd;
        public bool msgtrue = false;
        public bool boolean = true;
        public void graphical_executable(VBECanvas vbe,string ok)
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            string title = "";
            //
            int buttonx = 0;
            int buttony = 0;
            int buttonwidth = 0;
            int buttonheight = 0;
            string buttontitle = "";
            //
            int msgx = 0;
            int msgy = 0;
            int msgwidth = 0;
            int msgheight = 0;
            //
            if (ok.StartsWith("x = "))
            {
                x = int.Parse(ok.Remove(0, 4));
            }
            if (ok.StartsWith("y = "))
            {
                y = int.Parse(ok.Remove(0, 4));
            }
            if (ok.StartsWith("width = "))
            {
                width = int.Parse(ok.Remove(0, 8));
            }
            if (ok.StartsWith("height = "))
            {
                height = int.Parse(ok.Remove(0, 9));
            }
            if (ok.StartsWith("title = "))
            {
                title = ok.Remove(0, 8);
            }
            //
            if (ok.StartsWith("buttonx = "))
            {
                buttonx = int.Parse(ok.Remove(0, 10));
            }
            if (ok.StartsWith("buttony = "))
            {
                buttony = int.Parse(ok.Remove(0, 10));
            }
            if (ok.StartsWith("buttonwidth = "))
            {
                buttonwidth = int.Parse(ok.Remove(0, 14));
            }
            if (ok.StartsWith("buttonheight = "))
            {
                buttonheight = int.Parse(ok.Remove(0, 15));
            }
            if (ok.StartsWith("buttontitle = "))
            {
                buttontitle = ok.Remove(0, 14);
            }
            if (Mouse.Click())
            {
                if (MouseManager.X > buttonx && MouseManager.X < buttonx + buttonwidth)
                {
                    if (MouseManager.Y > buttony && MouseManager.X < buttony + buttonheight)
                    {
                        if (ok.StartsWith("buttonfunction(") && ok.EndsWith(")"))
                        {
                            ok.Remove(0, 15);
                            string buttonfunc = ok.Remove(ok.Length - 1);
                            if (buttonfunc.StartsWith("msgbox," + "\"") && buttonfunc.EndsWith("\""))
                            {
                                string message0 = buttonfunc.Remove(0, 8);
                                string message = message0.Remove(buttonfunc.Length - 1);
                                msgtrue = true;
                                msgbox(vbe, 400, 400, 200, 100, message, "warning!", msgtrue);
                            }
                        }
                    }
                }
            }
            /*
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            if (ok.StartsWith("newbutton\n{\n"))
            {
                if(ok.StartsWith("x = "))
                {
                    string a = ok.Remove(0, 16);
                    x = int.Parse(a.Remove(2, a.Length - 2));
                }
                if (ok.StartsWith("y = "))
                {
                    string a = ok.Remove(0, 23);
                    y = int.Parse(a.Remove(2, a.Length - 2));
                }
                if (ok.StartsWith("width = "))
                {
                    string a = ok.Remove(0, 34);
                    width = int.Parse(a.Remove(2, a.Length - 2));
                }
                if (ok.StartsWith("height = "))
                {
                    string a = ok.Remove(0, 45);
                    height = int.Parse(a.Remove(2, a.Length - 2));
                }
                vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.Blue.ToArgb());
            }
            */
            if (ok.StartsWith("//"))
            {
                
            }
            window(vbe, x, y, width, height, title, boolean);
            button(vbe, buttonx, buttony, buttonwidth, buttonheight, buttontitle);
        }
        public void window(VBECanvas vbe, int x, int y, int width, int height, string title, bool opened)
        {
            if (opened == true)
            {
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, title, Color.White, (uint)x + 5, (uint)y + 3);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //buttons
                foreach(Tuple<int, int, int, int, string> h in Lexer.buttontcontainer)
                {
                    button(vbe, x + h.Item1, y + 20 + h.Item2, h.Item3, h.Item4, h.Item5);
                    //ASC16.DrawACSIIString(vbe, h.Item5, (uint)Color.White.ToArgb(), (uint)x + 15, (uint)y + 25);
                }
                foreach(Tuple<int, int, string> h2 in Lexer.textcontainer)
                {
                    drawstring(vbe, x + h2.Item1, y + 20 + h2.Item2, h2.Item3);
                }
                //close button
                vbe.DrawFilledRectangle(new Pen(Color.Gray), (x + width) - 26, y + 5, 20, 12);
                System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                if (Mouse.Click())
                {
                    if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                    {
                        if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                        {
                            Booleans.openwindow = false;
                            //ASC16.DrawACSIIString(vbe, "You clicked the close button", (uint)Color.Black.ToArgb(), 10, 10);
                        }
                    }
                }
            }
            if(opened == false)
            {

            }
        }
        public void msgbox(VBECanvas vbe, int x, int y, int width, int height, string message, string msgboxtitle, bool opened)
        {
            if(opened == true)
            {
                vbe.DrawFilledRectangle(new Pen(Color.Gray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.White), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.Green), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, msgboxtitle, Color.White, (uint)x + 5, (uint)y + 3);
                vbe.DrawFilledRectangle(new Pen(Color.Gray), (x + width) - 51, y + 5, 20, 12);
                //
                ASC16.DrawACSIIString(vbe, message, Color.Black, (uint)x + 10, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen (Color.White), (x + width) - 30, (y + height) - 20, 20, 15);
                ASC16.DrawACSIIString(vbe, "Ok", Color.Black, (uint)(x + width) - 30, (uint)(y + height) - 18);
                if (Mouse.Click())
                {
                    if (MouseManager.X > (uint)((x + width) / 2) - 10 && MouseManager.X < (uint)((x + width) / 2) + 10)
                    {
                        if (MouseManager.Y > (uint)(y + height) - 20 && MouseManager.Y < (uint)(y + height) - 5)
                        {
                            msgtrue = false;
                        }
                    }
                }
            }
        }
        public void button(VBECanvas vbe, int x, int y, int width, int height, string title)
        {
            vbe.DrawFilledRectangle(new Pen(Color.White), x, y, width, height);
            vbe.DrawRectangle(new Pen(Color.Black), x, y, width, height);
            string a = "";
            if(title.Length > 5)
            {
                a = title.Remove(5);
            }
            else
            {
                a = title;
            }
            int why = (height / 2) - 6;
            int damn = (width / 2) - ((a.Length * 8) / 2);
            ASC16.DrawACSIIString(vbe, a, Color.Black, (uint)(x + damn), (uint)y + (uint)why);
            //ASC16.DrawACSIIString(vbe, title, (uint)Color.Black.ToArgb(), (uint)((x + width) / 2) - (uint)((title.Length * 8) / 2), (uint)y + (uint)why);
            //ASC16.DrawACSIIString(vbe, title, (uint)Color.Black.ToArgb(), (uint)x, (uint)y);
        }
        public void drawstring(VBECanvas vbe, int x, int y, string content)
        {
            ASC16.DrawACSIIString(vbe, content, Color.Black, (uint)x, (uint)y);
        }
        /*
        public void update(DoubleBufferedvbe vbe, int x, int y, int width, int height, string title)
        {
            System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
            if (fwd == false)
            {
                if (Mouse.Click())
                {
                    if ((CurMouse.X > (uint)(x + width) - 51) && (CurMouse.X < (uint)(x + width) - 31))
                    {
                        if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                        {
                            fwd = true;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            if(fwd == true)
            {
                if (Mouse.Click())
                {
                    if ((CurMouse.X > (uint)(x + width) - 51) && (CurMouse.X < (uint)(x + width) - 31))
                    {
                        if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                        {
                            fwd = false;
                        }
                    }
                }
                else
                {
                    window(vbe, 0, 0, 1280, 738, title);
                }
            }
        }
        */
    }
}