using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Network;
using CosmosDrawString;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using windows_95;
using Kernel = CrystalOS.Kernel;

namespace resolution.Applications
{
    class Calendar
    {
        public static bool moove_enabled = false;
        public void File_Explorer(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Calend..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("Calend...");
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
                            Int_Manager.calendar_x = (int)MouseManager.X;
                            Int_Manager.calendar_y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        ASC16.DrawACSIIString(vbe, "Calendar", Color.White, (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        int firstdayx = x + 15;
                        int firstdayy = y + 70;
                        //
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 5, y + 27, width - 10, 15);
                        ASC16.DrawACSIIString(vbe, "File", Color.Black, (uint)x + 8, (uint)y + 28);
                        KeyEvent keyEvent;
                        #region design
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 5, y + 45, width - 10, height - 48);
                        ASC16.DrawACSIIString(vbe, "Monday  Tuesday  Wednesday  Thursday  Friday  Saturday  Sunday", Color.Black, (uint)x + 10, (uint)y + 50);
                        #endregion design
                        #region funcionalities
                        int daysinmonth = DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month);
                        int dateoftoday = DateTime.UtcNow.Day;
                        string dayofweek = "";
                        int test = 0;
                        if (daysinmonth == 28)
                        {
                            if (dateoftoday != 1)
                            {
                                test = DateTime.UtcNow.Day;
                                DateTime.UtcNow.AddDays(-(dateoftoday - 1));
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Friday)
                                {
                                    dayofweek = "Friday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Monday)
                                {
                                    dayofweek = "Monday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Tuesday)
                                {
                                    dayofweek = "Tuesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Wednesday)
                                {
                                    dayofweek = "Wednesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Thursday)
                                {
                                    dayofweek = "Thursday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Saturday)
                                {
                                    dayofweek = "Saturday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dayofweek = "Sunday";
                                }

                                if (dayofweek == "Monday")
                                {
                                    firstdayx = x + 5;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //to be continued from here
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Tuesday")
                                {
                                    firstdayx = x + 95;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 165, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Wednesday")
                                {
                                    firstdayx = x + 105;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 110, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 165, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 220, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 275, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 330, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Thursday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Friday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 320;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Saturday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Sunday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                            }
                        }
                        if (daysinmonth == 29)
                        {
                            if (dateoftoday != 1)
                            {
                                test = DateTime.UtcNow.Day;
                                DateTime.UtcNow.AddDays(-(dateoftoday - 1));
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Friday)
                                {
                                    dayofweek = "Friday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Monday)
                                {
                                    dayofweek = "Monday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Tuesday)
                                {
                                    dayofweek = "Tuesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Wednesday)
                                {
                                    dayofweek = "Wednesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Thursday)
                                {
                                    dayofweek = "Thursday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Saturday)
                                {
                                    dayofweek = "Saturday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dayofweek = "Sunday";
                                }

                                if (dayofweek == "Monday")
                                {
                                    firstdayx = x + 5;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Tuesday")
                                {
                                    firstdayx = x + 95;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 165, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Wednesday")
                                {
                                    firstdayx = x + 105;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 110, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 165, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 220, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 275, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 330, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Thursday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Friday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 320;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }

                                if (dayofweek == "Saturday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Sunday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }

                            }
                        }
                        if (daysinmonth == 30)
                        {
                            if (dateoftoday != 1)
                            {
                                test = DateTime.UtcNow.Day;
                                DateTime.UtcNow.AddDays(-(dateoftoday - 1));
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Friday)
                                {
                                    dayofweek = "Friday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Monday)
                                {
                                    dayofweek = "Monday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Tuesday)
                                {
                                    dayofweek = "Tuesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Wednesday)
                                {
                                    dayofweek = "Wednesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Thursday)
                                {
                                    dayofweek = "Thursday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Saturday)
                                {
                                    dayofweek = "Saturday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dayofweek = "Sunday";
                                }

                                if (dayofweek == "Monday")
                                {
                                    firstdayx = x + 5;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Tuesday")
                                {
                                    firstdayx = x + 95;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 165, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Wednesday")
                                {
                                    firstdayx = x + 105;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 110, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 165, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 220, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 275, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 330, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Thursday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Friday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 320;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }

                                if (dayofweek == "Saturday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Sunday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                            }
                        }
                        if(daysinmonth == 31)
                        {
                            if (dateoftoday != 1)
                            {
                                test = DateTime.UtcNow.Day;
                                
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Friday)
                                {
                                    dayofweek = "Friday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Monday)
                                {
                                    dayofweek = "Monday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Tuesday)
                                {
                                    dayofweek = "Tuesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Wednesday)
                                {
                                    dayofweek = "Wednesday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Thursday)
                                {
                                    dayofweek = "Thursday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Saturday)
                                {
                                    dayofweek = "Saturday";
                                }
                                if (DateTime.UtcNow.AddDays(-(dateoftoday - 1)).DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dayofweek = "Sunday";
                                }

                                if (dayofweek == "Monday")
                                {
                                    firstdayx = x + 15;
                                    firstdayy = y + 65;
                                    //DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Tuesday")
                                {
                                    firstdayx = x + 95;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 165, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Wednesday")
                                {
                                    firstdayx = x + 115;
                                    firstdayy = y + 65;
                                    //DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 285, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 340, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 395, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 450, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 65, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 120, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 175, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 230, y + 230, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Thursday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 245;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Friday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 320;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }

                                if (dayofweek == "Saturday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 380;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 65;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                                if (dayofweek == "Sunday")
                                {
                                    //firstdayx = x + 170;
                                    //firstdayx = 0;
                                    firstdayx = x + 463;
                                    //firstdayx = x + 155;
                                    firstdayy = y + 70;
                                    DateTime.UtcNow.AddDays(test - 1);
                                    #region dateoftoday
                                    if (dateoftoday == 1)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 2)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 3)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 4)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 65, 50, 50);
                                    }
                                    if (dateoftoday == 5)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 6)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 7)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 8)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 9)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 10)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 11)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 120, 50, 50);
                                    }
                                    if (dateoftoday == 12)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 10, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 13)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 85, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 14)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 160, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 15)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 235, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 16)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 175, 50, 50);
                                    }
                                    if (dateoftoday == 17)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 175, 50, 50);
                                    }
                                    //vbe.DrawFilledRectangle((uint)x + 385, (uint)y + 175, 50, 50m);
                                    if (dateoftoday == 18)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 175, 50, 50);
                                    }
                                    //itt tartottál haver
                                    if (dateoftoday == 19)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 20)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 21)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 22)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 23)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 24)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 25)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 160, y + 230, 50, 50);
                                    }
                                    if (dateoftoday == 26)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 235, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 27)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 310, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 28)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 385, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 29)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 460, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 30)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 10, y + 285, 50, 50);
                                    }
                                    if (dateoftoday == 31)
                                    {
                                        vbe.DrawFilledRectangle(new Pen(Color.BlueViolet), x + 85, y + 285, 50, 50);
                                    }
                                    #endregion dateoftoday
                                }
                            }
                        }
                        bool days = true;
                        for (int i = 1; i < DateTime.DaysInMonth(DateTime.UtcNow.Year, DateTime.UtcNow.Month) + 1; i++)
                        {
                            //int X = x + 3;
                            //vbe.DrawRectangle((uint)Color.Black.ToArgb(), X + 3, )
                            ASC16.DrawACSIIString(vbe, i.ToString(), Color.Black, (uint)firstdayx, (uint)firstdayy);
                            if (firstdayx > (x + width) - 67)
                            {
                                firstdayx = x + 15;
                                firstdayy += 55;
                            }
                            else
                            {
                                firstdayx += 75;
                            }
                            /*
                            if (i == daysinmonth)
                            {

                            }
                            else
                            {
                                
                            }
                            */
                        }
                        #endregion funciounalities
                        //ASC16.DrawACSIIString(vbe, text2, (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 55);
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.calendar_opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.calendar_minimised = true;
                            }
                        }
                        if (Kernel.filepage == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 3, y + 45, 70, 140);
                            ASC16.DrawACSIIString(vbe, "New event", Color.Black, (uint)x + 5, (uint)y + 48);
                            ASC16.DrawACSIIString(vbe, "View event", Color.Black, (uint)x + 5, (uint)y + 68);
                            ASC16.DrawACSIIString(vbe, "Delete event", Color.Black, (uint)x + 5, (uint)y + 88);
                            if (Mouse.Click())
                            {
                                if (CurMouse.X > x + 5 && CurMouse.X < x + 20)
                                {
                                    if (CurMouse.Y > y + 27 && CurMouse.Y < y + 42)
                                    {
                                        Kernel.filepage = false;
                                    }
                                }
                            }
                        }
                        if (Kernel.filepage == false)
                        {
                            if (Mouse.Click())
                            {
                                if (CurMouse.X > x + 5 && CurMouse.X < x + 20)
                                {
                                    if (CurMouse.Y > y + 27 && CurMouse.Y < y + 42)
                                    {
                                        Kernel.filepage = true;
                                    }
                                }
                            }
                        }
                    }
                    if (Booleans.calendar_opened == false)
                    {

                    }
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Calend..."))
                    {
                        TaskManager.apps.Remove("Calend...");
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
                        if (z.Item1 == "Calend...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.calendar_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
