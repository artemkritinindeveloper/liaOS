/*
using Cosmos.System;
using Cosmos.System.FileSystem.Listing;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using nifanfa.CosmosDrawString;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;

namespace resolution.Applications
{
    class CommandPrompt
    {
        
        public void init(DoubleBufferedvbe vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise, string command)
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
                        int heigh = y + 64;
                        vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                        ASC16.DrawACSIIString(vbe, "Command-prompt", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        //
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 22, (uint)width - 6, (uint)height - 25, (uint)Color.Black.ToArgb());
                        ASC16.DrawACSIIString(vbe, "Command Prompt v1.01\nprerelease in 2020", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 24);
                        ASC16.DrawACSIIString(vbe, "C:>", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 64);
                        ASC16.DrawACSIIString(vbe, command, (uint)Color.White.ToArgb(), (uint)x + 28, (uint)heigh);
                        //
                        //
                        KeyEvent keyEvent;
                        if (KeyboardManager.TryReadKey(out keyEvent))
                        {
                            switch (keyEvent.Key)
                            {
                                case ConsoleKeyEx.Enter:

                                    break;
                                case ConsoleKeyEx.Backspace:
                                    if (Kernel.command.Length != 0)
                                    {
                                        Kernel.command = Kernel.command.Remove(Kernel.command.Length - 1);
                                    }
                                    break;
                                default:
                                    Kernel.command += keyEvent.KeyChar;
                                    break;
                            }
                        }
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Kernel.opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.cmdp = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.cmdpmin = true;
                            }
                        }
                    }
                        if (fullscreen == true)
                        {
                            x = 0;
                            y = 0;
                            width = 1280;
                            height = 738;
                            vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawRectangle((uint)Color.White.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                            ASC16.DrawACSIIString(vbe, "Settings", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                            vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            //
                            //
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 50, (uint)width - 6, (uint)height - 53, (uint)Color.White.ToArgb());
                            vbe.DrawRectangle((uint)Color.Black.ToArgb(), x + 3, y + 50, width - 6, height - 53);
                            vbe.DoubleBuffer_DrawLine((uint)Color.Blue.ToArgb(), x + 100, y + 50, x + 100, (y + height) - 3);
                            vbe.DrawACSIIString("display", (uint)Color.Black.ToArgb(), (uint)x + 10, (uint)y + 80);
                            if (MouseManager.X > x + 3 && MouseManager.X < x + 103)
                            {
                                if (MouseManager.Y > y + 55 && MouseManager.Y < y + 85)
                                {
                                    vbe.DrawFilledRectangle((uint)x + 4, (uint)y + 55, (uint)100, (uint)30, (uint)Color.Aqua.ToArgb());
                                    vbe.DrawACSIIString("display", (uint)Color.Black.ToArgb(), (uint)x + 30, (uint)y + 45);
                                }
                            }
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > x + 3 && MouseManager.X < x + 103)
                                {
                                    if (MouseManager.Y > y + 55 && MouseManager.Y < y + 85)
                                    {

                                    }
                                }
                            }
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
                                    Kernel.fullscreen = false;
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
                    if (Kernel.opened == false)
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
}
*/