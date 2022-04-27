using Cosmos.Core;
using Cosmos.Core.IOGroup;
using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using CosmosKernel1;
using CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Timers;
using Cosmos.System.Graphics;
using Kernel = CrystalOS.Kernel;

namespace resolution
{
    class Setup
    {
        string filename;
        string dayofweek;
        public string currentfile = "";
        public string timecontainer = "";
        public int willwork = 15;
        public static string passw = "";
        public static string passw2 = "";
        public static string choosencolor = "The choosen color:";
        public static string colorforfile = "";
        public static Cosmos.HAL.PIT p = new Cosmos.HAL.PIT();
        public void setup(VBECanvas vbe)
        {
            vbe.DrawFilledRectangle(new Pen(Color.RoyalBlue), 0, 0, 1280, 768);
            vbe.DrawFilledRectangle(new Pen(Color.Black), 0, 0, 255, 768);
            int x = 400;
            int y = 250;
            int width = 400;
            int height = 200;
            //
            ASC16.DrawACSIIString(vbe, "liaOS-Operating-\nSystem", Color.White, 50, 20);
            DriveInfo driveInfo = new DriveInfo("0:\\");
            int driverspace = (int)driveInfo.TotalSize / 1048576;
            //ASC16.DrawACSIIString(vbe, driverspace.ToString(), (uint)Color.Black.ToArgb(), 350, 100);
            if (Kernel.checkrequirements == true)
            {
                //ASC16.DrawACSIIString(vbe, "Checking system requirements", (uint)Color.White.ToArgb(), 30, 755);
                filename = "Checking system requirements";
                int RAM = (int)CPU.GetAmountOfRAM();
                if (RAM > 255)
                {
                    if (driverspace > 10)
                    {
                        Kernel.ramok = true;
                        Kernel.checkrequirements = false;
                    }
                }

            }
            if (Kernel.checkrequirements == false) { }
            if (Kernel.ramok == true)
            {
                filename = "Installing files...";
                Kernel.personalinfo = true;
                Kernel.ramok = false;
                //ASC16.DrawACSIIString(vbe, "Getting things ready...", (uint)Color.White.ToArgb(), 30, 755);
            }
            if (Kernel.ramok == false) { }
            if (Kernel.personalinfo == true)
            {
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Welcome!", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, "Welcome! You entered to liaOS 10 setup wizard.\nIn the next few step you will going to set up\nyour own operating system.\nTo continue click ok.", Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 60, (y + height) - 25, 50, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 60, (y + height) - 25, 50, 20);
                ASC16.DrawACSIIString(vbe, "Cancel", Color.Black, (uint)(x + width) - 56, (uint)(y + height) - 23);
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 120, (y + height) - 25, 50, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 120, (y + height) - 25, 50, 20);
                ASC16.DrawACSIIString(vbe, "Ok", Color.Black, (uint)(x + width) - 112, (uint)(y + height) - 23);
                if (CosmosKernel8.Drivers.Mouse.Click())
                {
                    if (MouseManager.X > (x + width) - 120 && MouseManager.X < (x + width) - 70)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            Kernel.getuserdata = true;
                            Kernel.personalinfo = false;
                        }
                    }
                    if (MouseManager.X > (x + width) - 60 && MouseManager.X < (x + width) - 10)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            Kernel.getuserdata = true;
                            Kernel.personalinfo = false;
                        }
                    }
                    //
                }
            }
            if (Kernel.personalinfo == false)
            {

            }
            if (Kernel.getuserdata == true)
            {
                x = 350;
                y = 80;
                width = 750;
                height = 600;
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Personal data", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, "Setup has suggested a name for your computer, but you can modify\nit if you want to.", Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                ASC16.DrawACSIIString(vbe, "computer name: ", Color.Black, (uint)(x + 5), (uint)y + 100);
                vbe.DrawFilledRectangle(new Pen(Color.White), x + 120, y + 95, 150, 25);
                vbe.DrawRectangle(new Pen(Color.Black), x + 120, y + 95, 150, 25);
                ASC16.DrawACSIIString(vbe, Kernel.computername, Color.Black, (uint)x + 123, (uint)y + 97);
                ASC16.DrawACSIIString(vbe, "To secure your computer and protect your data we give you the\nability to set up a password. (This part of the setup isn't important\nbut if you want you can do that later)", Color.Black, (uint)x + 5, (uint)y + 180);
                ASC16.DrawACSIIString(vbe, "Administrator password: ", Color.Black, (uint)(x + 5), (uint)y + 240);
                vbe.DrawFilledRectangle(new Pen(Color.White), x + 200, y + 230, 150, 25);
                vbe.DrawRectangle(new Pen(Color.Black), x + 200, y + 230, 150, 25);
                ASC16.DrawACSIIString(vbe, passw, Color.Black, (uint)x + 203, (uint)y + 232);
                ASC16.DrawACSIIString(vbe, "Confirm password: ", Color.Black, (uint)(x + 5), (uint)y + 280);
                vbe.DrawFilledRectangle(new Pen(Color.White), x + 200, y + 275, 150, 25);
                vbe.DrawRectangle(new Pen(Color.Black), x + 200, y + 275, 150, 25);
                ASC16.DrawACSIIString(vbe, passw2, Color.Black, (uint)x + 203, (uint)y + 277);
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 100, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 100, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "Next ->", Color.Black, (uint)(x + width) - 96, (uint)(y + height) - 23);
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 200, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 200, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "<- Back", Color.Black, (uint)(x + width) - 196, (uint)(y + height) - 23);
                if (CosmosKernel8.Drivers.Mouse.Click())
                {
                    if (MouseManager.X > (x + width) - 100 && MouseManager.X < (x + width) - 10)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            Kernel.computernamebox = false;
                            Kernel.password = false;
                            Kernel.password2 = false;
                            Kernel.background = true;
                            Kernel.getuserdata = false;
                            Cosmos.HAL.PIT pit = new Cosmos.HAL.PIT();
                            pit.Wait(200);
                        }
                    }
                    if (MouseManager.X > (x + width) - 200 && MouseManager.X < (x + width) - 110)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {

                        }
                    }
                    //
                    if (MouseManager.X > (uint)x + 120 && MouseManager.X < (uint)x + 270)
                    {
                        if (MouseManager.Y > (uint)y + 95 && MouseManager.Y < (uint)y + 120)
                        {
                            Kernel.computernamebox = true;
                            Kernel.password = false;
                            Kernel.password2 = false;
                        }
                    }
                    if (MouseManager.X > (uint)x + 200 && MouseManager.X < (uint)x + 350)
                    {
                        if (MouseManager.Y > (uint)y + 230 && MouseManager.Y < (uint)y + 255)
                        {
                            Kernel.password = true;
                            Kernel.computernamebox = false;
                            Kernel.password2 = false;
                        }
                    }
                    if (MouseManager.X > (uint)x + 200 && MouseManager.X < (uint)x + 350)
                    {
                        if (MouseManager.Y > (uint)y + 275 && MouseManager.Y < (uint)y + 300)
                        {
                            Kernel.password2 = true;
                            Kernel.computernamebox = false;
                            Kernel.password = false;
                        }
                    }
                }
            }
            if (Kernel.background == true)
            {
                x = 350;
                y = 80;
                width = 750;
                height = 600;
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Setting up desktop", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, "Now you can set up your desktop color and the type of the cursor layout.\nThe setup has an auto-selected green color as background color. If you want you can\nmodify it later.", Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                ASC16.DrawACSIIString(vbe, "Available background colors:", Color.Black, (uint)(x + 5), (uint)y + 100);
                //
                vbe.DrawFilledRectangle(new Pen(Color.Green), x + 20, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 20, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Green", Color.Black, (uint)x + 33, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Blue), x + 100, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 100, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Blue", Color.Black, (uint)x + 113, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Yellow), x + 180, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 180, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Yellow", Color.Black, (uint)x + 190, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Red), x + 260, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 260, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Red", Color.Black, (uint)x + 278, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Orange), x + 340, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 340, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Orange", Color.Black, (uint)x + 350, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Black), x + 420, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 420, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Black", Color.Black, (uint)x + 430, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Pink), x + 500, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 500, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Pink", Color.Black, (uint)x + 510, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Purple), x + 580, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 580, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Purple", Color.Black, (uint)x + 590, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.Aqua), x + 660, y + 135, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 660, y + 135, 60, 60);
                ASC16.DrawACSIIString(vbe, "Aqua", Color.Black, (uint)x + 670, (uint)y + 200);

                vbe.DrawFilledRectangle(new Pen(Color.White), x + 20, y + 230, 60, 60);
                vbe.DrawRectangle(new Pen(Color.White), x + 20, y + 230, 60, 60);
                ASC16.DrawACSIIString(vbe, "White", Color.Black, (uint)x + 33, (uint)y + 295);

                ASC16.DrawACSIIString(vbe, choosencolor, Color.Black, (uint)x + 20, (uint)y + 315);
                //*Later (brown), turquoise and lime color will be added(=13 colour)
                //Note: Three more fits next to Orange
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 100, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 100, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "Next ->", Color.Black, (uint)(x + width) - 96, (uint)(y + height) - 23);
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 200, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 200, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "<- Back", Color.Black, (uint)(x + width) - 196, (uint)(y + height) - 23);
                if (CosmosKernel8.Drivers.Mouse.Click())
                {
                    if (MouseManager.X > (x + width) - 100 && MouseManager.X < (x + width) - 10)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            if (CosmosKernel8.Drivers.Mouse.Click())
                            {
                                if (MouseManager.X > (x + width) - 100 && MouseManager.X < (x + width) - 10)
                                {
                                    if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                                    {
                                        Kernel.createfile = true;
                                        Kernel.background = false;
                                    }
                                }
                            }
                        }
                    }
                    if (MouseManager.X > (x + width) - 200 && MouseManager.X < (x + width) - 110)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            Kernel.getuserdata = true;
                            Kernel.personalinfo = false;
                        }
                    }
                    //Selecting a colour by clicking on it
                    if (MouseManager.X > x + 20 && MouseManager.X < x + 80)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Green";
                            colorforfile = "Green";
                        }
                    }
                    if (MouseManager.X > x + 100 && MouseManager.X < x + 160)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Blue";
                            colorforfile = "Blue";
                        }
                    }
                    if (MouseManager.X > x + 180 && MouseManager.X < x + 240)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Yellow";
                            colorforfile = "Yellow";
                        }
                    }
                    if (MouseManager.X > x + 260 && MouseManager.X < x + 320)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Red";
                            colorforfile = "Red";
                        }
                    }
                    if (MouseManager.X > x + 340 && MouseManager.X < x + 400)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Orange";
                            colorforfile = "Orange";
                        }
                    }
                    if (MouseManager.X > x + 420 && MouseManager.X < x + 480)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Black";
                            colorforfile = "Black";
                        }
                    }
                    if (MouseManager.X > x + 500 && MouseManager.X < x + 560)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Pink";
                            colorforfile = "Pink";
                        }
                    }
                    if (MouseManager.X > x + 580 && MouseManager.X < x + 640)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Purple";
                            colorforfile = "Purple";
                        }
                    }
                    if (MouseManager.X > x + 660 && MouseManager.X < x + 720)
                    {
                        if (MouseManager.Y > y + 135 && MouseManager.Y < y + 195)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "Aqua";
                            colorforfile = "Aqua";
                        }
                    }
                    if (MouseManager.X > x + 20 && MouseManager.X < x + 80)
                    {
                        if (MouseManager.Y > y + 230 && MouseManager.Y < y + 290)
                        {
                            choosencolor = "The choosen color:";
                            choosencolor += "White";
                            colorforfile = "White";
                        }
                    }
                    //The only thing I have to do is to just store these datas in files and later recall them in the bootup process.
                    //Hurray!!! I've reached this milestone too!!!
                }
            }
            if(Kernel.background == false) { }
            if (Kernel.recordtime == true)
            {
                x = 350;
                y = 80;
                width = 750;
                height = 600;
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Setting up time & date", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, "Now you can set up your current time & date to match it to your time zone. Important that\nyou can skip this part of the setup, because the BIOS automaticly sets up the current\ndate & time.", Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                ASC16.DrawACSIIString(vbe, $"Your current time is: {DateTime.UtcNow}", Color.Black, (uint)(x + 5), (uint)y + 100);
                ASC16.DrawACSIIString(vbe, $"New time & date(MM.DD.YYYY, Hour):", Color.Black, (uint)(x + 5), (uint)y + 120);
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), x + 290, y + 116, 150, 20);
                ASC16.DrawACSIIString(vbe, timecontainer, Color.Black, (uint)x + 295, (uint)y + 120);
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 100, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 100, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "Next ->", Color.Black, (uint)(x + width) - 96, (uint)(y + height) - 23);
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 200, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 200, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "<- Back", Color.Black, (uint)(x + width) - 196, (uint)(y + height) - 23);
                
                if (CosmosKernel8.Drivers.Mouse.Click())
                {
                    if (MouseManager.X > (x + width) - 100 && MouseManager.X < (x + width) - 10)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            Kernel.createfile = true;
                            Kernel.timebool = false;
                            Kernel.recordtime = false;
                        }
                    }
                    //
                    if (MouseManager.X > x + 240 && MouseManager.X < x + 390)
                    {
                        if (MouseManager.Y > y + 116 && MouseManager.Y < y + 136)
                        {
                            Kernel.timebool = true;
                        }
                    }
                }
            }
            if (Kernel.createfile == true)
            {
                x = 500;
                y = 80;
                width = 750;
                height = 300;
                string currentfile = "";
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Creating files and finishing up", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, currentfile, Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                //ASC16.DrawACSIIString(vbe, $"Your current time is: {DateTime.UtcNow}", (uint)Color.Black.ToArgb(), (uint)(x + 5), (uint)y + 100);
                //ASC16.DrawACSIIString(vbe, $"New time & date(MM.DD.YYYY, Hour):", (uint)Color.Black.ToArgb(), (uint)(x + 5), (uint)y + 120);
                //
                //vbe.DrawFilledRectangle((uint)x + 240, (uint)y + 116, 150, 20, (uint)Color.White.ToArgb());
                //ASC16.DrawACSIIString(vbe, timecontainer, (uint)Color.Black.ToArgb(), (uint)x + 425, (uint)y + 120);
                //
                /*
                vbe.DrawFilledRectangle((uint)(x + width) - 100, (uint)(y + height) - 25, 90, 20, (uint)Color.White.ToArgb());
                vbe.DrawRectangle((uint)Color.Black.ToArgb(), (x + width) - 100, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "Next ->", (uint)Color.Black.ToArgb(), (uint)(x + width) - 96, (uint)(y + height) - 23);
                vbe.DrawFilledRectangle((uint)(x + width) - 200, (uint)(y + height) - 25, 90, 20, (uint)Color.White.ToArgb());
                vbe.DrawRectangle((uint)Color.Black.ToArgb(), (x + width) - 200, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "<- Back", (uint)Color.Black.ToArgb(), (uint)(x + width) - 196, (uint)(y + height) - 23);
                */
                currentfile = @"Creating folder: 0:\SystemFolder";
                Directory.CreateDirectory(@"0:\SystemFolder");
                ASC16.DrawACSIIString(vbe, currentfile, Color.White, 510, 110);
                //Cosmos.HAL.PIT p = new Cosmos.HAL.PIT();
                //p.Wait(500);
                //
                currentfile = @"Creating file: 0:\SystemFolder\Screen.sdf";
                File.Create(@"0:\SystemFolder\Screen.sdf");
                File.WriteAllText(@"0:\SystemFolder\Screen.sdf", "vbe \n" + colorforfile);
                ASC16.DrawACSIIString(vbe, currentfile, Color.White, 510, 110);
                //p.Wait(500);
                //
                currentfile = @"Creating file: 0:\SystemFolder\Password.sdf";
                File.Create(@"0:\SystemFolder\Password.sdf");
                File.WriteAllText(@"0:\SystemFolder\Password.sdf", passw + "\n" + passw2);
                ASC16.DrawACSIIString(vbe, currentfile, Color.White, 510, 110);
                //p.Wait(500);
                //
                currentfile = @"Creating file: 0:\SystemFolder\UserData.sdf";
                File.Create(@"0:\SystemFolder\UserData.sdf");
                File.WriteAllText(@"0:\SystemFolder\UserData.sdf", Kernel.computername);
                ASC16.DrawACSIIString(vbe, currentfile, Color.White, 510, 110);
                //p.Wait(500);
                //
                //
                currentfile = @"Creating file: 0:\SystemFolder\DateTime.sdf";
                File.Create(@"0:\SystemFolder\DateTime.sdf");
                File.WriteAllText(@"0:\SystemFolder\DateTime.sdf", timecontainer);
                ASC16.DrawACSIIString(vbe, currentfile, Color.White, 510, 110);
                //p.Wait(500);

                Kernel.finished = true;
                Kernel.createfile = false;
            }
            if (Kernel.finished == true)
            {
                Kernel.personalinfo = false;
                x = 400;
                y = 200;
                width = 750;
                height = 300;
                //string currentfile = "";
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                ASC16.DrawACSIIString(vbe, "Finished!", Color.White, (uint)x + 5, (uint)y + 3);
                ASC16.DrawACSIIString(vbe, "Congratulations!\nYou have successfuly installed liaOS 10 on your PC.\nNow you have to restart your computer.", Color.Black, (uint)x + 5, (uint)y + 30);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                //
                vbe.DrawFilledRectangle(new Pen(Color.White), (x + width) - 100, (y + height) - 25, 90, 20);
                vbe.DrawRectangle(new Pen(Color.Black), (x + width) - 100, (y + height) - 25, 90, 20);
                ASC16.DrawACSIIString(vbe, "Restart now", Color.Black, (uint)(x + width) - 96, (uint)(y + height) - 23);
                if (CosmosKernel8.Drivers.Mouse.Click())
                {
                    if (MouseManager.X > (x + width) - 100 && MouseManager.X < (x + width) - 10)
                    {
                        if (MouseManager.Y > (y + height) - 25 && MouseManager.Y < (y + height) - 5)
                        {
                            File.Create(@"0:\SystemFolder\setupa.sdf");
                            File.WriteAllText(@"0:\SystemFolder\setupa.sdf", "finished");
                            Cosmos.System.Power.Reboot();
                        }
                    }
                }
            }

            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Friday)
            {
                dayofweek = "Friday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Monday)
            {
                dayofweek = "Monday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Tuesday)
            {
                dayofweek = "Tuesday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Wednesday)
            {
                dayofweek = "Wednesday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Thursday)
            {
                dayofweek = "Thursday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday)
            {
                dayofweek = "Saturday";
            }
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Sunday)
            {
                dayofweek = "Sunday";
            }
            //ASC16.DrawACSIIString(vbe, filename, (uint)Color.White.ToArgb(), 30, 755);
            ASC16.DrawACSIIString(vbe, DateTime.UtcNow.Day.ToString() + "." + dayofweek + "." + DateTime.UtcNow.Hour.ToString() + ":" + DateTime.UtcNow.Minute.ToString() + ":" + DateTime.UtcNow.Second, Color.White, 1140, 753);
        }
    }
}