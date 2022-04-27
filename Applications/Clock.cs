using Cosmos.System;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Cosmos.System.Graphics;
using windows_95;
using Kernel = CrystalOS.Kernel;

namespace resolution.Applications
{
    class Clock
    {
        Booleans booleans = new Booleans();
        public static bool moove_enabled = false;
        public void init(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                        TaskManager tmg = new TaskManager();
                        if (TaskManager.apps.Contains("Clock"))
                        {

                        }
                        else
                        {
                            TaskManager.apps.Add("Clock");
                        }
                    if (Mouse.Click())
                    {
                        if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 53)
                        {
                            if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                            {
                                moove_enabled = true;
                            }
                        }
                        /*
                        if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 30)
                        {
                            if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                            {
                                Int_Manager.dialogbox_x = (int)MouseManager.X - 20;
                                Int_Manager.dialogbox_y = (int)MouseManager.Y - 10;
                            }
                        }
                        */
                    }
                    if (moove_enabled == true)
                    {
                        Int_Manager.clock_x = (int)MouseManager.X;
                        Int_Manager.clock_y = (int)MouseManager.Y;
                        if (Mouse.RightClick())
                        {
                            moove_enabled = false;
                        }
                    }
                    int heigh = y + 64;
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        ASC16.DrawACSIIString(vbe, "Clock", Color.White, (uint)x + 5, (uint)y + 3);
                        //vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 21, width - 6, height - 23);
                        
                        ASC16.DrawACSIIString(vbe, "12", Color.Black, (uint)x + 91, (uint)y + 28);//((x + width)/2) - 4
                        ASC16.DrawACSIIString(vbe, "3", Color.Black, (uint)(x + width) - 28, (uint)y + 100);//20
                        ASC16.DrawACSIIString(vbe, "6", Color.Black, (uint)x + 95, (uint)y + 172);//26
                        ASC16.DrawACSIIString(vbe, "9", Color.Black, (uint)x + 20, (uint)y + 100);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 128, y + 33, 15, 15); 
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 162, y + 68, 15, 15);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 162, y + 134, 15, 15);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 135, y + 169, 15, 15);
                        //
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 52, y + 33, 15, 15);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 18, y + 68, 15, 15);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 18, y + 134, 15, 15);
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 52, y + 169, 15, 15);
                        //drawHand(vbe, (uint)Color.Black.ToArgb(), (int)(x + width / 2), (int)(y + height / 2) + 8, 15, 15);
                        drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, DateTime.UtcNow.Minute, 35);
                        drawHand(vbe, Color.Red, (int)(x + width / 2), (int)(y + height / 2) + 8, DateTime.UtcNow.Second, 55);
                        if(DateTime.UtcNow.Second == 0 || DateTime.UtcNow.Second == 00)
                        {
                            vbe.DrawLine(new Pen(Color.Red), (int)(x + width / 2), (int)(y + height / 2) - 47, (int)(x + width / 2), (int)(y + height / 2) + 8);//55
                        }
                        if (DateTime.UtcNow.Second == 45)
                        {
                            vbe.DrawLine(new Pen(Color.Red), (int)(x + width / 2) - 55, (int)(y + height / 2) + 8, (int)(x + width / 2), (int)(y + height / 2) + 8);
                        }
                        #region hourhand
                        if(DateTime.UtcNow.Hour == 1 || DateTime.UtcNow.Hour == 13)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 5, 15);
                        }
                        if (DateTime.UtcNow.Hour == 2 || DateTime.UtcNow.Hour == 14)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 10, 15);
                        }
                        if (DateTime.UtcNow.Hour == 3 || DateTime.UtcNow.Hour == 15)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 15, 15);
                        }
                        if (DateTime.UtcNow.Hour == 4 || DateTime.UtcNow.Hour == 16)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 20, 15);
                        }
                        if (DateTime.UtcNow.Hour == 5 || DateTime.UtcNow.Hour == 17)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 25, 15);
                        }
                        if (DateTime.UtcNow.Hour == 6 || DateTime.UtcNow.Hour == 18)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 30, 15);
                        }
                        if (DateTime.UtcNow.Hour == 7 || DateTime.UtcNow.Hour == 19)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 35, 15);
                        }
                        if (DateTime.UtcNow.Hour == 8 || DateTime.UtcNow.Hour == 20)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 40, 15);
                        }
                        if (DateTime.UtcNow.Hour == 9 || DateTime.UtcNow.Hour == 21 || DateTime.UtcNow.Minute == 45)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 45, 15);
                        }
                        if (DateTime.UtcNow.Hour == 10 || DateTime.UtcNow.Hour == 22)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 50, 15);
                        }
                        if (DateTime.UtcNow.Hour == 11 || DateTime.UtcNow.Hour == 23)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 55, 15);
                        }
                        if (DateTime.UtcNow.Hour == 0 || DateTime.UtcNow.Minute == 0)
                        {
                            drawHand(vbe, Color.Black, (int)(x + width / 2), (int)(y + height / 2) + 8, 0, 15);
                        }
                        #endregion hourhand
                        //
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.clock_opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.clock_minimised = true;
                            }
                        }
                    if (Mouse.Click())
                    {
                        if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 30)
                        {
                            if (MouseManager.Y > y + 3 && MouseManager.Y < y + 20)
                            {
                                Int_Manager.clock_x = (int)MouseManager.X - 20;
                                Int_Manager.clock_y = (int)MouseManager.Y - 10;
                            }
                        }
                    }
                    #region fullscreen
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
                    #endregion fullscreen
                    if (Booleans.clock_opened == false)
                    {

                    }
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Clock"))
                    {
                        TaskManager.apps.Remove("Clock");
                    }
                    else
                    {
                        //TaskManager.apps.Add("Clock");
                    }
                }
            }
            if (minimise == true)
            {
                if (Mouse.Click())
                {
                    foreach (Tuple<string, int, int, int, int> z in Kernel.applist)
                    {
                        if (z.Item1 == "Clock")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.clock_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void drawHand(VBECanvas vbe, Color color2, int xStart, int yStart, int angle, int radius)
        {
            Pen color = new Pen(color2);
            int[] sine = new int[16] { 0, 27, 54, 79, 104, 128, 150, 171, 190, 201, 221, 233, 243, 250, 254, 255 };
            int xEnd, yEnd, quadrant, x_flip, y_flip;

            quadrant = angle / 15;

            switch (quadrant)
            {
                case 0: x_flip = 1; y_flip = -1; break;
                case 1: angle = Math.Abs(angle - 30); x_flip = y_flip = 1; break;
                case 2: angle = angle - 30; x_flip = -1; y_flip = 1; break;
                case 3: angle = Math.Abs(angle - 60); x_flip = y_flip = -1; break;
                default: x_flip = y_flip = 1; break;
            }

            xEnd = xStart;
            yEnd = yStart;

            if (angle > sine.Length) return;

            xEnd += (x_flip * ((sine[angle] * radius) >> 8));
            yEnd += (y_flip * ((sine[15 - angle] * radius) >> 8));

            vbe.DrawLine(color, xStart, yStart, xEnd, yEnd);
        }
    }
}