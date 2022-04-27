using Cosmos.Core;
using Cosmos.System;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.Applications;
using resolution.iconmanager;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using Cosmos.System.Graphics;
using Kernel = CrystalOS.Kernel;

namespace resolution.NewFolder
{
    class settings
    {
        //booleans
        public bool menu = true;
        public static List<string> wieved = new List<string>();
        public static List<string> tophiden = new List<string>();
        public static List<string> bottomhiden = new List<string>();

        public static List<string> rightwieved = new List<string>();
        public static List<string> righttophiden = new List<string>();
        public static List<string> rightbottomhiden = new List<string>();

        public static List<string> leftwieved = new List<string>();
        public static List<string> lefttophiden = new List<string>();
        public static List<string> leftbottomhiden = new List<string>();

        //public static string cd = "";

        public static uint previousy = 300;
        public static uint newposx = 300;
        public static uint newposy = 300;
        public uint x1 = 150;
        public uint y1 = 150;
        public static bool moove_enabled = false;
        //
        public void Settings(VBECanvas vbe, int x, int y, int width, int height, bool fullscreen, bool display, bool SandA, bool settings, bool minimise, bool lost)
        {
            if (minimise == false)
            {
                if (settings == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Settin..."))
                    {
                        
                    }
                    else
                    {
                        TaskManager.apps.Add("Settin...");
                    }
                    if (fullscreen == false)
                    {
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 30)
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
                            Kernel.x = (int)MouseManager.X;
                            Kernel.y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        Cogwheel.drawcogwheel(vbe, (uint)x + 5, (uint)y + 5);
                        ASC16.DrawACSIIString(vbe, "Settings", Color.White, (uint)x + 15, (uint)y + 3);
                        //vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        //
                        //vbe.DrawFilledRectangle(newposx, newposy, 20, 150, (uint)Color.White.ToArgb());
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 50, width - 6, height - 53);
                        vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 50, width - 6, height - 53);
                        vbe.DrawLine(new Pen(Color.Blue), x + 100, y + 50, x + 100, (y + height) - 3);
                        ASC16.DrawACSIIString(vbe, "Display", Color.Black, (uint)x + 20, (uint)y + 65);
                        if (MouseManager.X > x + 3 && MouseManager.X < x + 99)
                        {
                            if (MouseManager.Y > y + 55 && MouseManager.Y < y + 85)
                            {
                                vbe.DrawFilledRectangle(new Pen(Color.Aqua), x + 4, y + 55, 95, 30);
                                ASC16.DrawACSIIString(vbe, "Display", Color.Black, (uint)x + 20, (uint)y + 65);
                            }
                        }
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < x + 99)
                            {
                                if (MouseManager.Y > y + 55 && MouseManager.Y < y + 85)
                                {
                                    Booleans.display = true;
                                    //SandA = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if(MouseManager.X > newposx && MouseManager.X < newposx + 20)
                            {
                                if (MouseManager.Y > newposy && MouseManager.Y < newposy + 150)
                                {
                                    previousy = newposy;
                                    //newposx = MouseManager.X;
                                    newposy = MouseManager.Y - 15;
                                }
                            }
                        }
                        if (display == true)
                        {
                            /*
                            #region scrollbar
                            if (menu == true)
                            {
                                //cd = File.ReadAllText(@"0:\image.txt");
                                foreach (string line in File.ReadAllLines(@"0:\longdoc.txt"))
                                {
                                    if (line.Length > 15)
                                    {

                                    }
                                    if (wieved.Count < 5)
                                    {
                                        wieved.Add(line);
                                    }
                                    else
                                    {
                                        bottomhiden.Add(line);
                                    }
                                }
                            }
                            if (newposy < previousy)
                            {
                                int f = (int)previousy - (int)newposy;
                                if (f > 3)
                                {
                                    if (f > 6)
                                    {
                                        foreach (string line in tophiden.GetRange(tophiden.Count - 2, 2))
                                        {
                                            wieved.Insert(0, line);
                                            tophiden.Remove(line);
                                        }
                                        //string xd = "";
                                        foreach (string line in wieved.GetRange(wieved.Count - 2, 2))
                                        {
                                            bottomhiden.Insert(0, line);
                                            wieved.Remove(line);
                                        }
                                    }
                                    else
                                    {
                                        foreach (string line in tophiden.GetRange(tophiden.Count - 1, 1))
                                        {
                                            wieved.Insert(0, line);
                                            tophiden.Remove(line);
                                        }
                                        //string xd = "";
                                        foreach (string line in wieved.GetRange(wieved.Count - 1, 1))
                                        {
                                            bottomhiden.Insert(0, line);
                                            wieved.Remove(line);
                                        }
                                    }

                                }
                                previousy = newposy;
                                f = 0;
                            }
                            if (newposy > previousy)
                            {
                                int f = (int)newposy - (int)previousy;
                                if (f > 3)
                                {
                                    if (f > 6)
                                    {
                                        foreach (string line in wieved.GetRange(0, 2))
                                        {
                                            tophiden.Add(line);
                                            wieved.Remove(line);
                                        }
                                        //string xd = "";
                                        foreach (string line in bottomhiden.GetRange(0, 2))
                                        {
                                            wieved.Add(line);
                                            bottomhiden.Remove(line);
                                        }
                                    }
                                    else
                                    {
                                        foreach (string line in wieved.GetRange(0, 1))
                                        {
                                            tophiden.Add(line);
                                            wieved.Remove(line);
                                        }
                                        //string xd = "";
                                        foreach (string line in bottomhiden.GetRange(0, 1))
                                        {
                                            wieved.Add(line);
                                            bottomhiden.Remove(line);
                                        }
                                    }
                                    
                                }
                                previousy = newposy;
                                f = 0;
                            }
                            menu = false;
                            KeyEvent keyEvent;
                            if (KeyboardManager.TryReadKey(out keyEvent))
                            {

                                if (keyEvent.Key == ConsoleKeyEx.DownArrow)
                                {
                                    string newline = "";
                                    foreach (string line in wieved.GetRange(0, 1))
                                    {
                                        tophiden.Add(line);
                                        wieved.Remove(line);
                                        //previousy = newposy;
                                    }

                                    string xd = "";
                                    foreach (string line in bottomhiden.GetRange(0, 1))
                                    {
                                        wieved.Add(line);
                                        bottomhiden.Remove(line);
                                        //previousy = newposy;
                                    }
                                    //string xd = bottomhiden.GetRange(0, 1).ToString();

                                }
                                else
                                {
                                    string s = "";
                                    string t = "";
                                    foreach (string line in wieved.GetRange(0, 1))
                                    {
                                        s = line;
                                        t = line;
                                    }
                                    t += keyEvent.KeyChar;
                                    wieved.Remove(s);
                                    wieved.Insert(0, t);
                                }
                            }
                            foreach(string c in wieved)
                            {
                                ASC16.DrawACSIIString(vbe, c, (uint)Color.Black.ToArgb(), x1, y1);
                                y1 += 15;
                            }
                            //ASC16.DrawACSIIString(vbe, cd, (uint)Color.Black.ToArgb(), 600, 150);
                            //string[] linesoftext = File.ReadAllLines(@"0:\longdoc.txt");
                            #endregion scrollbar
                            */
                            ASC16.DrawACSIIString(vbe, "Display settings", Color.Black, (uint)x + 130, (uint)y + 60);
                            //Here you can choose the colour of the desktop
                            //x + 500 is the max
                            vbe.DrawFilledRectangle(new Pen(Color.Green), x + 110, y + 85, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Green", Color.Black, (uint)x + 120, (uint)y + 148);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 110, y + 85, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Blue), x + 180, y + 85, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Blue", Color.Black, (uint)x + 197, (uint)y + 148);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 180, y + 85, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Yellow), x + 250, y + 85, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Yellow", Color.Black, (uint)x + 257, (uint)y + 148);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 250, y + 85, 60, 60);
                            
                            vbe.DrawFilledRectangle(new Pen(Color.Red), x + 320, y + 85, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Red", Color.Black, (uint)x + 340, (uint)y + 148);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 320, y + 85, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Orange), x + 390, y + 85, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Orange", Color.Black, (uint)x + 397, (uint)y + 148);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 390, y + 85, 60, 60);
                            //
                            vbe.DrawFilledRectangle(new Pen(Color.Black), x + 110, y + 175, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Black", Color.Black, (uint)x + 115, (uint)y + 238);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 110, y + 175, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Pink), x + 180, y + 175, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Pink", Color.Black, (uint)x + 188, (uint)y + 238);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 180, y + 175, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Purple), x + 250, y + 175, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Purple", Color.Black, (uint)x + 255, (uint)y + 238);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 250, y + 175, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.Aqua), x + 320, y + 175, 60, 60);
                            ASC16.DrawACSIIString(vbe, "Aqua", Color.Black, (uint)x + 328, (uint)y + 238);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 320, y + 175, 60, 60);

                            vbe.DrawFilledRectangle(new Pen(Color.White), x + 390, y + 175, 60, 60);
                            ASC16.DrawACSIIString(vbe, "White", Color.Black, (uint)x + 395, (uint)y + 238);
                            vbe.DrawRectangle(new Pen(Color.Black), x + 390, y + 175, 60, 60);
                            #region color chooser handler
                            //Kernel k = new windows_95.Kernel();
                            if (Mouse.Click())
                            {
                                uint X = MouseManager.X;
                                uint Y = MouseManager.Y;
                                if (X > x + 110 && X < x + 170 && Y > y + 85 && Y < y + 155)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Green");
                                    Kernel.background1 = Color.Green;
                                }
                                if (X > x + 180 && X < x + 240 && Y > y + 85 && Y < y + 155)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Blue");
                                    Kernel.background1 = Color.Blue;
                                }
                                if (X > x + 250 && X < x + 310 && Y > y + 85 && Y < y + 155)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Yellow");
                                    Kernel.background1 = Color.Yellow;
                                }
                                if (X > x + 320 && X < x + 380 && Y > y + 85 && Y < y + 155)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Red");
                                    Kernel.background1 = Color.Red;
                                }
                                if (X > x + 390 && X < x + 450 && Y > y + 85 && Y < y + 155)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Orange");
                                    Kernel.background1 = Color.Orange;
                                }
                                //Second line
                                if (X > x + 110 && X < x + 170 && Y > y + 175 && Y < y + 245)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Black");
                                    Kernel.background1 = Color.Black;
                                }
                                if (X > x + 180 && X < x + 240 && Y > y + 175 && Y < y + 245)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Pink");
                                    Kernel.background1 = Color.Pink;
                                }
                                if (X > x + 250 && X < x + 310 && Y > y + 175 && Y < y + 245)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Purple");
                                    Kernel.background1 = Color.Purple;
                                }
                                if (X > x + 320 && X < x + 380 && Y > y + 175 && Y < y + 245)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "Aqua");
                                    Kernel.background1 = Color.Aqua;
                                }
                                if (X > x + 390 && X < x + 450 && Y > y + 175 && Y < y + 245)
                                {
                                    //File.Delete(@"0:\SystemFolder\Screen.sdf");
                                    //File.Create(@"0:\SystemFolder\Screen.sdf");
                                    //File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "White");
                                    Kernel.background1 = Color.White;
                                }
                            }
                            #endregion color chooser handler
                        }
                        if (display == false)
                        {

                        }
                        //
                        //
                        #region sound
                        /*
                        ASC16.DrawACSIIString(vbe, "Audio", Color.Black, (uint)x + 20, (uint)y + 105);
                        if (MouseManager.X > x + 3 && MouseManager.X < x + 99)
                        {
                            if (MouseManager.Y > y + 95 && MouseManager.Y < y + 125)
                            {
                                vbe.DrawFilledRectangle(new Pen(Color.Aqua), x + 4, y + 95, 95, 30);
                                ASC16.DrawACSIIString(vbe, "Audio", Color.Black, (uint)x + 20, (uint)y + 105);
                            }
                        }
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 3 && MouseManager.X < x + 99)
                            {
                                if (MouseManager.Y > y + 95 && MouseManager.Y < y + 125)
                                {
                                    //Kernel.SandA = true;
                                    //Kernel.display = false;
                                }
                            }
                        }
                        if (SandA == true)
                        {
                            ASC16.DrawACSIIString(vbe, "Audio setup", Color.Black, (uint)x + 130, (uint)y + 60);
                        }
                        if (SandA == false)
                        {

                        }
                        */
                        #endregion sound
                        //
                        //
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.settings_open = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17) && !menu)
                            {
                                //Kernel.fullscreen = true;
                                Booleans.settings_minimised = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17) && !menu)
                            {
                                //Kernel.minimise = true;
                            }
                        }
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
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17) && !menu)
                            {
                                Kernel.fullscreen = false;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17) && !menu)
                            {
                                Kernel.minimise = true;
                            }
                        }
                    }
                    */
                }
                if (settings == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Settin..."))
                    {
                        TaskManager.apps.Remove("Settin...");
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
                    foreach (Tuple<string, int, int, int, int> z in CrystalOS.Kernel.applist)
                    {
                        if (z.Item1 == "Settin...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.settings_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}