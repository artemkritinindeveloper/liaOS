using Cosmos.Core;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using windows_95;
using Kernel = CrystalOS.Kernel;

namespace resolution.Applications
{
    class Computer_information
    {
        public static bool moove_enabled = false;
        public void init(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise, bool basic, bool hardware, bool software)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("About_..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("About_...");
                    }
                    if (fullscreen == false)
                    {
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 53)
                            {
                                if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                                {
                                    moove_enabled = true;
                                }
                            }
                        }
                        if (moove_enabled == true)
                        {
                            Int_Manager.compiteri_x = (int)MouseManager.X;
                            Int_Manager.computeri_y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        int heigh = y + 64;
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        ASC16.DrawACSIIString(vbe, "About computer", Color.White, (uint)x + 5, (uint)y + 3);
                        //vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 3, y + 25, width - 6, 20);
                        ASC16.DrawACSIIString(vbe, "Basic", Color.Black, (uint)x + 8, (uint)y + 28);
                        ASC16.DrawACSIIString(vbe, "Hardware", Color.Black, (uint)x + 61, (uint)y + 28);
                        ASC16.DrawACSIIString(vbe, "Software", Color.Black, (uint)x + 135, (uint)y + 28);
                        if(MouseManager.X > x + 3 && MouseManager.X < x + 55)
                        {
                            if(MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                            {
                                vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 25, 52, 20);
                            }
                        }
                        if (MouseManager.X > x + 58 && MouseManager.X < x + 129)
                        {
                            if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                            {
                                vbe.DrawRectangle(new Pen(Color.Black), x + 58, y + 25, 71, 20);
                            }
                        }
                        if (MouseManager.X > x + 132 && MouseManager.X < x + 203)
                        {
                            if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                            {
                                vbe.DrawRectangle(new Pen(Color.Black), x + 132, y + 25, 71, 20);
                            }
                        }
                        if(Kernel.basic == true)
                        {
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > x + 3 && MouseManager.X < x + 55)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        
                                    }
                                }
                                if (MouseManager.X > x + 58 && MouseManager.X < x + 129)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.hardware = true;
                                        Kernel.basic = false;
                                    }
                                }
                                if (MouseManager.X > x + 132 && MouseManager.X < x + 203)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.sofware = true;
                                        Kernel.basic = false;
                                    }
                                }
                            }
                            ASC16.DrawACSIIString(vbe, "System:", Color.Black, (uint)x + 5, (uint)y + 55);
                            ASC16.DrawACSIIString(vbe, "liaOS 10\nBuild: 1H26 \nCopyright: LIARTANIUM CORPORATION", Color.Black, (uint)x + 15, (uint)y + 70);
                            ASC16.DrawACSIIString(vbe, "User information:", Color.Black, (uint)x + 5, (uint)y + 120);
                            ASC16.DrawACSIIString(vbe, "Username: My-PC\nPassword protection: NO\nComputer name: Unknown", Color.Black, (uint)x + 15, (uint)y + 135);
                        }
                        if(Kernel.basic == false)
                        {

                        }
                        if(Kernel.hardware == true)
                        {
                            //DriveInfo d = new DriveInfo("0:\\");
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > x + 3 && MouseManager.X < x + 55)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.basic = true;
                                        Kernel.hardware = false;
                                    }
                                }
                                if (MouseManager.X > x + 58 && MouseManager.X < x + 129)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {

                                    }
                                }
                                if (MouseManager.X > x + 132 && MouseManager.X < x + 203)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.sofware = true;
                                        Kernel.hardware = false;
                                    }
                                }
                            }
                            ASC16.DrawACSIIString(vbe, "Hardware information:", Color.Black, (uint)x + 3, (uint)y + 55);
                            ASC16.DrawACSIIString(vbe, $"Random Access Memory(RAM): {CPU.GetAmountOfRAM()} Megabyte\nRAM in use: {CPU.GetEndOfKernel() / 1048576} Megabyte\nProcessor info: {CPU.GetCPUVendorName()}", Color.Black, (uint)x + 15, (uint)y + 70);
                        }
                        if(Kernel.hardware == false)
                        {

                        }
                        if(Kernel.sofware == true)
                        {
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > x + 3 && MouseManager.X < x + 55)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.basic = true;
                                        Kernel.sofware = false;
                                    }
                                }
                                if (MouseManager.X > x + 58 && MouseManager.X < x + 129)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        Kernel.hardware = true;
                                        Kernel.sofware = false;
                                    }
                                }
                                if (MouseManager.X > x + 132 && MouseManager.X < x + 203)
                                {
                                    if (MouseManager.Y > y + 25 && MouseManager.Y < y + 45)
                                    {
                                        
                                    }
                                }
                            }
                            ASC16.DrawACSIIString(vbe, "liaOS 10 (c)\nAll rights reserved.", Color.Black, (uint)x + 5, (uint)y + 55);
                        }
                        if(Kernel.sofware == false)
                        {
                            //ASC16.DrawACSIIString(vbe, "liaOS 10 (c)\nAll rights reserved.", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 55);
                        }
                        //
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.computeri_opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.computeri_minimised = true;
                            }
                        }
                        /*if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.cmdpmin = true;
                            }
                        }
                        */
                    }
                    /*
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
                    */
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("About_..."))
                    {
                        TaskManager.apps.Remove("About_...");
                    }
                    else
                    {
                        
                    }
                }
            }
            if (minimise == true)
            {
                if (Mouse.Click())
                {
                    foreach (Tuple<string, int, int, int, int> z in Kernel.applist)
                    {
                        if (z.Item1 == "About_...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.computeri_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
