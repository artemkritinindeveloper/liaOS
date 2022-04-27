using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosDrawString;
using CosmosKernel8.Drivers;
using resolution;
using resolution.Applications;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Text;
using Kernel = CrystalOS.Kernel;

namespace CosmosKernel1
{
    class DrawMenu
    {
        public static bool textedit;
        public static bool menu = false;
        public static uint x = 600;
        public static uint y = 0;
        public static string menutitle = "menu";

        public static void update(System.Drawing.Point CurMouse, VBECanvas vbe)
        {
            if (menu == true)
            {
                if (Mouse.Click())
                {
                    if ((CurMouse.X > 5) && (CurMouse.X < 45))
                    {
                        if ((CurMouse.Y > 743) && (CurMouse.Y < 763))
                        {
                            menu = false;
                            return;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 703 && MouseManager.Y < 733)
                        {
                            Cosmos.System.Power.Shutdown();
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 673 && MouseManager.Y < 703)
                        {
                            Cosmos.System.Power.Reboot();
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 638 && MouseManager.Y < 668)
                        {
                            Booleans.settings_open = true;
                            menu = false;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 608 && MouseManager.Y < 638)
                        {
                            Booleans.text = string.Empty;
                            Booleans.secnum = string.Empty;
                            Booleans.action = string.Empty;
                            Booleans.resutment = 0;
                            Booleans.calc = true;
                            Booleans.num1 = true;
                            Booleans.num2 = false;
                            Booleans.result = false;
                            Booleans.calculator_opened = true;
                            menu = false;
                            //calculator.calculator(vbe, Kernel.calcx, Kernel.calcy, Kernel.calcwidth, Kernel.calcheight, Kernel.calc, Kernel.minimise2, Kernel.text, Kernel.secnum, Kernel.num1, Kernel.num2, Kernel.result);
                        }
                    }
                    // geting different options from opened menu bar.
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 578 && MouseManager.Y < 608)
                        {
                            Booleans.calendar_opened = true;
                            menu = false;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 548 && MouseManager.Y < 578)
                        {
                            Booleans.clock_opened = true;
                            menu = false;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 518 && MouseManager.Y < 548)
                        {
                            Booleans.minesweeper_opened = true;
                            menu = false;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 488 && MouseManager.Y < 518)
                        {
                            Booleans.computeri_opened = true;
                            //Booleans.explorer_opened = true;
                            //FolderExplorer.parentdir = @"0:\";
                            menu = false;
                        }
                    }
                    /*
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 458 && MouseManager.Y < 488)
                        {
                            Booleans.minesweeper_opened = true;
                            menu = false;
                        }
                    }
                    if (MouseManager.X > 0 && MouseManager.X < 169)
                    {
                        if (MouseManager.Y > 428 && MouseManager.Y < 458)
                        {
                            Booleans.computeri_opened = true;
                            menu = false;
                        }
                    }
                    */
                    // option selector in opened menu bar ends here.
                    //

                    else
                    {
                        menu = false;
                        return;
                    }
                }
                else
                {
                    menus(vbe);
                }
            }
            if (menu == false)
            {
                if (Mouse.Click())
                {
                    if ((CurMouse.X > 5) && (CurMouse.X < 45))
                    {
                        if ((CurMouse.Y > 743) && (CurMouse.Y < 763))
                        {
                            menu = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public static void menus(VBECanvas vbe)
        {
            //400, 338
            vbe.DrawFilledRectangle(new Pen(Color.Gray), 0, 487, 169, 251);
            vbe.DrawRectangle(new Pen(Color.White), 0, 487, 169, 251);
            ASC16.DrawACSIIString(vbe, "Shutdown", Color.Black, 10, 718);
            ASC16.DrawACSIIString(vbe, "Reboot", Color.Black, 10, 683);
            ASC16.DrawACSIIString(vbe, "Settings", Color.Black, 10, 648);
            //Calcicon.normalcalc(vbe, 10, 608);//decreasing by 35
            ASC16.DrawACSIIString(vbe, "Calculator", Color.Black, 10, 618);
            ASC16.DrawACSIIString(vbe, "Calendar", Color.Black, 10, 588);
            ASC16.DrawACSIIString(vbe, "Clock", Color.Black, 10, 558);
            ASC16.DrawACSIIString(vbe, "Minesweeper", Color.Black, 10, 528);
            //ASC16.DrawACSIIString(vbe, "CMD", Color.Black, 10, 528);
            //ASC16.DrawACSIIString(vbe, "Explorer", Color.Black, 10, 498);
            ASC16.DrawACSIIString(vbe, "About", Color.Black, 10, 498);
            //ASC16.DrawACSIIString(vbe, "Minesweeper", Color.Black, 10, 468);
            //ASC16.DrawACSIIString(vbe, "About", Color.Black, 10, 438);
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 703 && MouseManager.Y < 733)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 708, 169, 30);
                    ASC16.DrawACSIIString(vbe, "Shutdown", Color.White, 10, 718);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 673 && MouseManager.Y < 703)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 673, 169, 30);
                    ASC16.DrawACSIIString(vbe, "Reboot", Color.White, 10, 683);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 638 && MouseManager.Y < 668)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 638, 169, 30);
                    ASC16.DrawACSIIString(vbe, "Settings", Color.White, 10, 648);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 608 && MouseManager.Y < 638)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 608, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "Calculator", Color.White, 10, 618);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 578 && MouseManager.Y < 608)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 578, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "Calendar", Color.White, 10, 588);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 548 && MouseManager.Y < 578)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 548, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "Clock", Color.White, 10, 558);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 518 && MouseManager.Y < 548)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 518, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "Minesweeper", Color.White, 10, 528);
                    //ASC16.DrawACSIIString(vbe, "CMD", Color.Black, 10, 528);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 488 && MouseManager.Y < 518)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 488, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "About", Color.White, 10, 498);
                    //ASC16.DrawACSIIString(vbe, "Explorer", Color.Black, 10, 498);
                }
            }
            /*
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 458 && MouseManager.Y < 488)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 458, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "Minesweeper", Color.Black, 10, 468);
                }
            }
            if (MouseManager.X > 0 && MouseManager.X < 169)
            {
                if (MouseManager.Y > 428 && MouseManager.Y < 458)
                {
                    vbe.DrawFilledRectangle(new Pen(Color.MediumBlue), 0, 428, 169, 30);
                    //Calcicon.normalcalc(vbe, 10, 608);
                    ASC16.DrawACSIIString(vbe, "About", Color.Black, 10, 438);
                }
            }
            */
        }
    }
}
