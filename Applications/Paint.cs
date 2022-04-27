/*
using Cosmos.System;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using nifanfa.CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace resolution.Applications
{
    class Paint
    {
        public void paint(DoubleBufferedvbe vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise, string filetext)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    if (fullscreen == false)
                    {
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 05)
                            {
                                if (MouseManager.Y > y + 3 && MouseManager.Y < y + 40)
                                {
                                    Kernel.x = (int)MouseManager.X - 40;
                                    Kernel.y = (int)MouseManager.Y - 20;
                                }
                            }
                        }
                        vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                        ASC16.DrawACSIIString(vbe, "WordPad", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        //vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 25, (uint)width - 6, 20, (uint)Color.LightGray.ToArgb());
                        //vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 48, (uint)width - 6, 50, (uint)Color.LightGray.ToArgb());
                        //vbe.DrawRectangle((uint)Color.Black.ToArgb(), x + 5, y + 50, 40, 46);
                        //
                        //
                        Kernel kernel = new Kernel();
                        vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 50, (uint)width - 10, (uint)height - 55, (uint)Color.White.ToArgb());
                        ASC16.DrawACSIIString(vbe, kernel.file, (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 55);
                        //
                        //
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Kernel.setting = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.fullscreen = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.minimise = true;
                            }
                        }
                    }
                    if (fullscreen == true)
                    {
                        x = 0;
                        y = 0;
                        width = 1280;
                        height = 738;
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 05)
                            {
                                if (MouseManager.Y > y + 3 && MouseManager.Y < y + 40)
                                {
                                    Kernel.x = (int)MouseManager.X - 40;
                                    Kernel.y = (int)MouseManager.Y - 20;
                                }
                            }
                        }
                        vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                        ASC16.DrawACSIIString(vbe, "Paint", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        //
                        //
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 25, (uint)width - 6, 20, (uint)Color.LightGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 48, (uint)width - 6, 50, (uint)Color.LightGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), x + 5, y + 50, 40, 46);
                        //
                        //
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Kernel.setting = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.fullscreen = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.minimise = true;
                            }
                        }
                    }
                }
                if (opened == false)
                {

                }
            }
            if (minimise == true)
            {
                if (Mouse.Click())
                {
                    if (MouseManager.X > 70 && MouseManager.X < 150)
                    {
                        if (MouseManager.Y > 743 && MouseManager.Y < 763)
                        {
                            Kernel.minimise = false;
                        }
                    }
                }
            }
        }
    }
}
*/