using Cosmos.Core;
using Cosmos.Core.IOGroup;
using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Timers;
using Mouse = CosmosKernel8.Drivers.Mouse;
using windows_95;
using Kernel = CrystalOS.Kernel;

namespace resolution.Applications
{
    class Solitare
    {
        //This would be my best implementation EVER!!!
    }
    class Minesweeper
    {
        public static bool timeupdate = true;
        public static int starttime = 0;
        public static int timenow = 0;
        public static int timeellapsed = 0;
        public static int timeresult = 0;
        public static string ret = "";
        #region boolians from 1-50
        public static bool b0 = false;
        public static bool b1 = false;
        public static bool b2 = false;
        public static bool b3 = false;
        public static bool b4 = false;
        public static bool b5 = false;
        public static bool b6 = false;
        public static bool b7 = false;
        public static bool b8 = false;
        public static bool b9 = false;
        public static bool b10 = false;
        public static bool b11 = false;
        public static bool b12 = false;
        public static bool b13 = false;
        public static bool b14 = false;
        public static bool b15 = false;
        public static bool b16 = false;
        public static bool b17 = false;
        public static bool b18 = false;
        public static bool b19 = false;
        public static bool b20 = false;
        public static bool b21 = false;
        public static bool b22 = false;
        public static bool b23 = false;
        public static bool b24 = false;
        public static bool b25 = false;
        public static bool b26 = false;
        public static bool b27 = false;
        public static bool b28 = false;
        public static bool b29 = false;
        public static bool b30 = false;
        public static bool b31 = false;
        public static bool b32 = false;
        public static bool b33 = false;
        public static bool b34 = false;
        public static bool b35 = false;
        public static bool b36 = false;
        public static bool b37 = false;
        public static bool b38 = false;
        public static bool b39 = false;
        public static bool b40 = false;
        public static bool b41 = false;
        public static bool b42 = false;
        public static bool b43 = false;
        public static bool b44 = false;
        public static bool b45 = false;
        public static bool b46 = false;
        public static bool b47 = false;
        #endregion boolians from 1-50
        #region int from 1-10
        public static int a1 = 0;
        public static int a2 = 0;
        public static int a3 = 0;
        public static int a4 = 0;
        public static int a5 = 0;
        public static int a6 = 0;
        public static int a7 = 0;
        public static int a8 = 0;
        public static int a9 = 0;
        public static int a10 = 0;
        #endregion int from 1-10
        #region boolians belonging to int
        public static bool a11 = true;
        public static bool a22 = false;
        public static bool a33 = false;
        public static bool a44 = false;
        public static bool a55 = false;
        public static bool a66 = false;
        public static bool a77 = false;
        public static bool a88 = false;
        public static bool a99 = false;
        public static bool a1010 = false;
        #endregion  boolians belonging to int
        public static Random r = new Random();
        public static int beforenum = 0;
        public static int nownum = 0;
        public static bool gameover = false;
        public static MemoryBlock mb = new MemoryBlock(0x1000, 0x10000);
        public static bool idk = false;
        public static bool idk2 = false;
        #region boolians from 1to50
        public static bool c0 = false;
        public static bool c1 = false;
        public static bool c2 = false;
        public static bool c3 = false;
        public static bool c4 = false;
        public static bool c5 = false;
        public static bool c6 = false;
        public static bool c7 = false;
        public static bool c8 = false;
        public static bool c9 = false;
        public static bool c10 = false;
        public static bool c11 = false;
        public static bool c12 = false;
        public static bool c13 = false;
        public static bool c14 = false;
        public static bool c15 = false;
        public static bool c16 = false;
        public static bool c17 = false;
        public static bool c18 = false;
        public static bool c19 = false;
        public static bool c20 = false;
        public static bool c21 = false;
        public static bool c22 = false;
        public static bool c23 = false;
        public static bool c24 = false;
        public static bool c25 = false;
        public static bool c26 = false;
        public static bool c27 = false;
        public static bool c28 = false;
        public static bool c29 = false;
        public static bool c30 = false;
        public static bool c31 = false;
        public static bool c32 = false;
        public static bool c33 = false;
        public static bool c34 = false;
        public static bool c35 = false;
        public static bool c36 = false;
        public static bool c37 = false;
        public static bool c38 = false;
        public static bool c39 = false;
        public static bool c40 = false;
        public static bool c41 = false;
        public static bool c42 = false;
        public static bool c43 = false;
        public static bool c44 = false;
        public static bool c45 = false;
        public static bool c46 = false;
        public static bool c47 = false;
        #endregion boolians from 1to50
        public static bool moove_enabled = false;
        public void minesweeper(VBECanvas vbe, int x, int y, int width, int height, bool minimise, bool fullscreen, bool opened)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Minesw..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("Minesw...");
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
                            Int_Manager.minesweeper_x = (int)MouseManager.X;
                            Int_Manager.minesweeper_y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        ASC16.DrawACSIIString(vbe, "Minesweeper", Color.White, (uint)x + 5, (uint)y + 3);
                        //vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        //On the left side there will be shown the amount of hiden bombs
                        vbe.DrawFilledRectangle(new Pen(Color.Black), x + 5, y + 20, 30, 25);
                        vbe.DrawRectangle(new Pen(Color.DimGray), x + 5, y + 20, 30, 25);
                        ASC16.DrawACSIIString(vbe, "010", Color.OrangeRed, (uint)x + 8, (uint)y + 27);
                        //On the right side there will be shown the amount of time passed from the starting of the game
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (x + width) - 35, y + 20, 30, 25);
                        vbe.DrawRectangle(new Pen(Color.DimGray), (x + width) - 35, y + 20, 30, 25);
                        game_over(vbe, x, y);
                        #region timer
                        if (timeupdate == true)
                        {
                            starttime = (DateTime.UtcNow.Minute / 60) + DateTime.UtcNow.Second;
                            timeupdate = false;
                        }
                        Cosmos.HAL.PIT p = new Cosmos.HAL.PIT();
                        //p.Wait(250);
                        timenow = (DateTime.UtcNow.Minute / 60) + DateTime.UtcNow.Second;
                        timeellapsed = timenow - starttime;
                        if(timeellapsed != 0)
                        {
                            timeresult += 1;
                            starttime = 0;
                            timenow = 0;
                            timeupdate = true;
                        }
                        ASC16.DrawACSIIString(vbe, timeresult.ToString(), Color.OrangeRed, (uint)(x + width) - 30, (uint)y + 27);
                        //On the top-middle side there will be shown a button to restart when its been clicked
                        drawboard(vbe, x, y, width);
                        #endregion timer
                        //
                        #region activateflag
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        if (Mouse.RightClick())
                        {
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b0 == false)
                                {
                                    b0 = true;
                                }
                                else
                                {
                                    if(b0 == true)
                                    {
                                        b0 = false;
                                    }
                                }
                                /*
                                if(idk == true)
                                {
                                    if (b0 == true)
                                    {
                                        b0 = false;
                                    }
                                }
                                if (idk == false)
                                {
                                    if (b0 == false)
                                    {
                                        b0 = true;
                                    }
                                    
                                }
                                if(idk2 == false)
                                {
                                    if (idk == true)
                                    {
                                        idk = false;
                                    }
                                    if (idk == false)
                                    {
                                        idk = true;
                                    }
                                }
                                if (idk2 == true)
                                {
                                    if (idk == false)
                                    {
                                        idk = true;
                                    }
                                    if (idk == true)
                                    {
                                        idk = false;
                                    }
                                }
                                idk = true;
                                */
                                //idk = true;
                                //b0 = true;
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b1 == false)
                                {
                                    b1 = true;
                                }
                                else
                                {
                                    if (b1 == true)
                                    {
                                        b1 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b2 == false)
                                {
                                    b2 = true;
                                }
                                else
                                {
                                    if (b2 == true)
                                    {
                                        b2 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b3 == false)
                                {
                                    b3 = true;
                                }
                                else
                                {
                                    if (b3 == true)
                                    {
                                        b3 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b4 == false)
                                {
                                    b4 = true;
                                }
                                else
                                {
                                    if (b4 == true)
                                    {
                                        b4 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (b5 == false)
                                {
                                    b5 = true;
                                }
                                else
                                {
                                    if (b5 == true)
                                    {
                                        b5 = false;
                                    }
                                }
                            }
                            //newline2
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b6 == false)
                                {
                                    b6 = true;
                                }
                                else
                                {
                                    if (b6 == true)
                                    {
                                        b6 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b7 == false)
                                {
                                    b7 = true;
                                }
                                else
                                {
                                    if (b7 == true)
                                    {
                                        b7 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b8 == false)
                                {
                                    b8 = true;
                                }
                                else
                                {
                                    if (b8 == true)
                                    {
                                        b8 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b9 == false)
                                {
                                    b9 = true;
                                }
                                else
                                {
                                    if (b9 == true)
                                    {
                                        b9 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b10 == false)
                                {
                                    b10 = true;
                                }
                                else
                                {
                                    if (b10 == true)
                                    {
                                        b10 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (b11 == false)
                                {
                                    b11 = true;
                                }
                                else
                                {
                                    if (b11 == true)
                                    {
                                        b11 = false;
                                    }
                                }
                            }
                            //newline3
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b12 == false)
                                {
                                    b12 = true;
                                }
                                else
                                {
                                    if (b12 == true)
                                    {
                                        b12 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b13 == false)
                                {
                                    b13 = true;
                                }
                                else
                                {
                                    if (b13 == true)
                                    {
                                        b13 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b14 == false)
                                {
                                    b14 = true;
                                }
                                else
                                {
                                    if (b14 == true)
                                    {
                                        b14 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b15 == false)
                                {
                                    b15 = true;
                                }
                                else
                                {
                                    if (b15 == true)
                                    {
                                        b15 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b16 == false)
                                {
                                    b16 = true;
                                }
                                else
                                {
                                    if (b16 == true)
                                    {
                                        b16 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (b17 == false)
                                {
                                    b17 = true;
                                }
                                else
                                {
                                    if (b17 == true)
                                    {
                                        b17 = false;
                                    }
                                }
                            }
                            //newline4
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b18 == false)
                                {
                                    b18 = true;
                                }
                                else
                                {
                                    if (b18 == true)
                                    {
                                        b18 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b19 == false)
                                {
                                    b19 = true;
                                }
                                else
                                {
                                    if (b19 == true)
                                    {
                                        b19 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b20 == false)
                                {
                                    b20 = true;
                                }
                                else
                                {
                                    if (b20 == true)
                                    {
                                        b20 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b21 == false)
                                {
                                    b21 = true;
                                }
                                else
                                {
                                    if (b21 == true)
                                    {
                                        b21 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b22 == false)
                                {
                                    b22 = true;
                                }
                                else
                                {
                                    if (b22 == true)
                                    {
                                        b22 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (b23 == false)
                                {
                                    b23 = true;
                                }
                                else
                                {
                                    if (b23 == true)
                                    {
                                        b23 = false;
                                    }
                                }
                            }
                            //line5
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b24 == false)
                                {
                                    b24 = true;
                                }
                                else
                                {
                                    if (b24 == true)
                                    {
                                        b24 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b25 == false)
                                {
                                    b25 = true;
                                }
                                else
                                {
                                    if (b25 == true)
                                    {
                                        b25 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b26 == false)
                                {
                                    b26 = true;
                                }
                                else
                                {
                                    if (b26 == true)
                                    {
                                        b26 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b27 == false)
                                {
                                    b27 = true;
                                }
                                else
                                {
                                    if (b27 == true)
                                    {
                                        b27 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b28 == false)
                                {
                                    b28 = true;
                                }
                                else
                                {
                                    if (b28 == true)
                                    {
                                        b28 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (b29 == false)
                                {
                                    b29 = true;
                                }
                                else
                                {
                                    if (b29 == true)
                                    {
                                        b29 = false;
                                    }
                                }
                            }
                            //newline6
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b30 == false)
                                {
                                    b30 = true;
                                }
                                else
                                {
                                    if (b30 == true)
                                    {
                                        b30 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b31 == false)
                                {
                                    b31 = true;
                                }
                                else
                                {
                                    if (b31 == true)
                                    {
                                        b31 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b32 == false)
                                {
                                    b32 = true;
                                }
                                else
                                {
                                    if (b32 == true)
                                    {
                                        b32 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b33 == false)
                                {
                                    b33 = true;
                                }
                                else
                                {
                                    if (b33 == true)
                                    {
                                        b33 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b34 == false)
                                {
                                    b34 = true;
                                }
                                else
                                {
                                    if (b34 == true)
                                    {
                                        b34 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (b35 == false)
                                {
                                    b35 = true;
                                }
                                else
                                {
                                    if (b35 == true)
                                    {
                                        b35 = false;
                                    }
                                }
                            }
                            //newline7 (above b35)
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b36 == false)
                                {
                                    b36 = true;
                                }
                                else
                                {
                                    if (b36 == true)
                                    {
                                        b36 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b37 == false)
                                {
                                    b37 = true;
                                }
                                else
                                {
                                    if (b37 == true)
                                    {
                                        b37 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b38 == false)
                                {
                                    b38 = true;
                                }
                                else
                                {
                                    if (b38 == true)
                                    {
                                        b38 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b39 == false)
                                {
                                    b39 = true;
                                }
                                else
                                {
                                    if (b39 == true)
                                    {
                                        b39 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b40 == false)
                                {
                                    b40 = true;
                                }
                                else
                                {
                                    if (b40 == true)
                                    {
                                        b40 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (b41 == false)
                                {
                                    b41 = true;
                                }
                                else
                                {
                                    if (b41 == true)
                                    {
                                        b41 = false;
                                    }
                                }
                            }
                            //newline8
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b42 == false)
                                {
                                    b42 = true;
                                }
                                else
                                {
                                    if (b42 == true)
                                    {
                                        b42 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b43 == false)
                                {
                                    b43 = true;
                                }
                                else
                                {
                                    if (b43 == true)
                                    {
                                        b43 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b44 == false)
                                {
                                    b44 = true;
                                }
                                else
                                {
                                    if (b44 == true)
                                    {
                                        b44 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b45 == false)
                                {
                                    b45 = true;
                                }
                                else
                                {
                                    if (b45 == true)
                                    {
                                        b45 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b46 == false)
                                {
                                    b46 = true;
                                }
                                else
                                {
                                    if (b46 == true)
                                    {
                                        b46 = false;
                                    }
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (b47 == false)
                                {
                                    b47 = true;
                                }
                                else
                                {
                                    if (b47 == true)
                                    {
                                        b47 = false;
                                    }
                                }
                            }
                        }
                        #endregion activateflag
                        #region ifbool
                        if(b0 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 58);
                        }
                        if (b1 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 58);
                        }
                        if (b2 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 58);
                        }
                        if (b3 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 58);
                        }
                        if (b4 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 58);
                        }
                        if (b5 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 58);
                        }
                        //newline
                        if (b6 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 76);
                        }
                        if (b7 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 76);
                        }
                        if (b8 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 76);
                        }
                        if (b9 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 76);
                        }
                        if (b10 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 76);
                        }
                        if (b11 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 76);
                        }
                        //newline
                        if (b12 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 94);
                        }
                        if (b13 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 94);
                        }
                        if (b14 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 94);
                        }
                        if (b15 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 94);
                        }
                        if (b16 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 94);
                        }
                        if (b17 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 94);
                        }
                        //newline
                        if (b18 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 112);
                        }
                        if (b19 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 112);
                        }
                        if (b20 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 112);
                        }
                        if (b21 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 112);
                        }
                        if (b22 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 112);
                        }
                        if (b23 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 112);
                        }
                        //newline Edit:take a look at theese!!!(IMPORTANT)(Done on this side bro)
                        if (b24 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 130);
                        }
                        if (b25 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 130);
                        }
                        if (b26 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 130);
                        }
                        if (b27 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 130);
                        }
                        if (b28 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 130);
                        }
                        if (b29 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 130);
                        }
                        //newline
                        if (b30 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 148);
                        }
                        if (b31 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 148);
                        }
                        if (b32 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 148);
                        }
                        if (b33 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 148);
                        }
                        if (b34 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 148);
                        }
                        if (b35 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 148);
                        }
                        //newline
                        if (b36 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 166);
                        }
                        if (b37 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 166);
                        }
                        if (b38 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 166);
                        }
                        if (b39 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 166);
                        }
                        if (b40 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 166);
                        }
                        if (b41 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 166);
                        }
                        //newline
                        if (b42 == true)
                        {
                            normalcalc(vbe, (uint)x + 25, (uint)y + 184);
                        }
                        if (b43 == true)
                        {
                            normalcalc(vbe, (uint)x + 43, (uint)y + 184);
                        }
                        if (b44 == true)
                        {
                            normalcalc(vbe, (uint)x + 61, (uint)y + 184);
                        }
                        if (b45 == true)
                        {
                            normalcalc(vbe, (uint)x + 79, (uint)y + 184);
                        }
                        if (b46 == true)
                        {
                            normalcalc(vbe, (uint)x + 97, (uint)y + 184);
                        }
                        if (b47 == true)
                        {
                            normalcalc(vbe, (uint)x + 115, (uint)y + 184);
                        }
                        #endregion ifbool
                        #region locatebomb
                        //Random r = new Random();
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 1)
                                {
                                    gameover = true;
                                }
                                else if(a2 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 1)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c0 = true;
                                    //vbe.DrawFilledRectangle((uint)x + 22, (uint)y + 55, 15, 15, (uint)Color.LightGreen.ToArgb());
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 2)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c1 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 3)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c2 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 4)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c3 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 5)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c4 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 55 && MouseManager.Y < y + 70)
                            {
                                if (a1 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 6)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c5 = true;
                                }
                            }
                            //newline2
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 7)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c6 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 8)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c7 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 9)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c8 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    //end of CANCEL button
                                    */
                                    gameover = true;
                                }
                                else if (a2 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a3 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a4 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a5 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a6 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a7 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a8 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a9 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else if (a10 == 10)
                                {
                                    /*
                                    vbe.DrawFilledRectangle(650, 500, 350, 150, (uint)Color.Red.ToArgb());
                                    vbe.DrawRectangle((uint)Color.White.ToArgb(), 650, 500, 350, 150);
                                    ASC16.DrawACSIIString(vbe, "Game over!", (uint)Color.Black.ToArgb(), 765, 505);
                                    ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel\nto close the game.", (uint)Color.Silver.ToArgb(), 655, 535);
                                    //drawing ok button
                                    vbe.DrawFilledRectangle(675, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 675, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 675, 600, 700, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 700, 600, 700, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 675, 610, 700, 610);
                                    ASC16.DrawACSIIString(vbe, "Ok", (uint)Color.Black.ToArgb(), 687, 601);
                                    //end of drawing ok button
                                    //drawing CANCEL button
                                    vbe.DrawFilledRectangle(705, 600, 25, 10, (uint)Color.White.ToArgb());
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 705, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), 705, 600, 730, 600);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 730, 600, 730, 610);
                                    vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), 705, 610, 730, 610);
                                    ASC16.DrawACSIIString(vbe, "Cancel", (uint)Color.Black.ToArgb(), 613, 601);
                                    */
                                    gameover = true;
                                }
                                else
                                {
                                    c9 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 11)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 11)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c10 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 73 && MouseManager.Y < y + 88)
                            {
                                if (a1 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 12)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 12)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c11 = true;
                                }
                            }
                            //newline3
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 13)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 13)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c12 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 14)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 14)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c13 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 15)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 15)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c14 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 16)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 16)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c15 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 17)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 17)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c16 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 91 && MouseManager.Y < y + 106)
                            {
                                if (a1 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 18)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 18)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c17 = true;
                                }
                            }
                            //newline4
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 19)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 19)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c18 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 20)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 20)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c19 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 21)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 21)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c20 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 22)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 22)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c21 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 23)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 23)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c22 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 109 && MouseManager.Y < y + 124)
                            {
                                if (a1 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 24)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 24)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c23 = true;
                                }
                            }
                            //line5
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 25)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 25)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c24 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 26)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 26)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c25 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 27)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 27)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c26 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 28)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 28)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c27 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 29)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 29)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c28 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 127 && MouseManager.Y < y + 142)
                            {
                                if (a1 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 30)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 30)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c29 = true;
                                }
                            }
                            //newline6
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 31)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 31)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c30 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 32)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 32)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c31 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 33)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 33)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c32 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 34)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 34)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c33 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 35)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 35)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c34 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 145 && MouseManager.Y < y + 160)
                            {
                                if (a1 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 36)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 36)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c35 = true;
                                }
                            }
                            //newline7 (above b35)
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 37)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 37)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c36 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 38)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 38)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c37 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 39)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 39)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c38 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 40)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 40)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c39 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 41)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 41)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c40 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 163 && MouseManager.Y < y + 178)
                            {
                                if (a1 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 42)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 42)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c41 = true;
                                }
                            }
                            //newline8
                            if (MouseManager.X > x + 22 && MouseManager.X < x + 37 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 43)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 43)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c42 = true;
                                }
                            }
                            if (MouseManager.X > x + 40 && MouseManager.X < x + 55 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 44)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 44)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c43 = true;
                                }
                            }
                            if (MouseManager.X > x + 58 && MouseManager.X < x + 73 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 45)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 45)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c44 = true;
                                }
                            }
                            if (MouseManager.X > x + 76 && MouseManager.X < x + 91 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 46)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 46)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c45 = true;
                                }
                            }
                            if (MouseManager.X > x + 94 && MouseManager.X < x + 109 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 47)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 47)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c46 = true;
                                }
                            }
                            if (MouseManager.X > x + 112 && MouseManager.X < x + 127 && MouseManager.Y > y + 181 && MouseManager.Y < y + 196)
                            {
                                if (a1 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a2 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a3 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a4 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a5 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a6 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a7 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a8 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a9 == 48)
                                {
                                    gameover = true;
                                }
                                else if (a10 == 48)
                                {
                                    gameover = true;
                                }
                                else
                                {
                                    c47 = true;
                                }
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            nownum = r.Next(1, 49);
                            if (ret.Contains(nownum.ToString()))
                            {
                                
                            }
                            else
                            {
                                if (beforenum == nownum)
                                {

                                }
                                else
                                {
                                    beforenum = nownum;
                                    if (a1010 == true)
                                    {
                                        if (a10 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a10 = nownum;
                                        }
                                        //a22 = true;
                                        a1010 = false;
                                    }
                                    if (a99 == true)
                                    {
                                        if (a9 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a9 = nownum;
                                        }
                                        a1010 = true;
                                        a99 = false;
                                    }
                                    if (a88 == true)
                                    {
                                        if (a8 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a8 = nownum;
                                        }
                                        a99 = true;
                                        a88 = false;
                                    }
                                    if (a77 == true)
                                    {
                                        if (a7 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a7 = nownum;
                                        }
                                        a88 = true;
                                        a77 = false;
                                    }
                                    if (a66 == true)
                                    {
                                        if (a6 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a6 = nownum;
                                        }
                                        a77 = true;
                                        a66 = false;
                                    }
                                    if (a55 == true)
                                    {
                                        if (a5 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a5 = nownum;
                                        }
                                        a66 = true;
                                        a55 = false;
                                    }
                                    if (a44 == true)
                                    {
                                        if (a4 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a4 = nownum;
                                        }
                                        a55 = true;
                                        a44 = false;
                                    }
                                    if (a33 == true)
                                    {
                                        if (a3 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a3 = nownum;
                                        }
                                        a44 = true;
                                        a33 = false;
                                    }
                                    if (a22 == true)
                                    {
                                        if (a2 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a2 = nownum;
                                        }
                                        a33 = true;
                                        a22 = false;
                                    }
                                    if (a11 == true)
                                    {
                                        if(a1 > 0)
                                        {

                                        }
                                        else
                                        {
                                            a1 = nownum;
                                        }
                                        a22 = true;
                                        a11 = false;
                                    }
                                   
                                    
                                    
                                    
                                    
                                    
                                    
                                    ret += nownum.ToString() + ", ";
                                }
                            }
                            //p.WaitNS(250);
                            i += 1;
                        }
                        //ASC16.DrawACSIIString(vbe, ret + "\n" + a1.ToString() + a2.ToString() + a3.ToString() + a4.ToString() + a5.ToString() + a6.ToString() + a7.ToString() + a8.ToString() + a9.ToString() + a10.ToString(), (uint)Color.Black.ToArgb(), 60, 650);
                        #endregion locatebomb
                        #region correctblock
                        if (c0 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 55, 15, 15);
                        }
                        if (c1 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 55, 15, 15);
                        }
                        if (c2 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 55, 15, 15);
                        }
                        if (c3 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 55, 15, 15);
                        }
                        if (c4 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 55, 15, 15);
                        }
                        if (c5 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 55, 15, 15);
                        }
                        //newline
                        if (c6 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 73, 15, 15);
                        }
                        if (c7 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 73, 15, 15);
                        }
                        if (c8 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 73, 15, 15);
                        }
                        if (c9 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 73, 15, 15);
                        }
                        if (c10 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 73, 15, 15);
                        }
                        if (c11 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 73, 15, 15);
                        }
                        //newline
                        if (c12 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 91, 15, 15);
                        }
                        if (c13 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 91, 15, 15);
                        }
                        if (c14 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 91, 15, 15);
                        }
                        if (c15 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 91, 15, 15);
                        }
                        if (c16 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 91, 15, 15);
                        }
                        if (c17 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 91, 15, 15);
                        }
                        //newline
                        if (c18 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 109, 15, 15);
                        }
                        if (c19 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 109, 15, 15);
                        }
                        if (c20 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 109, 15, 15);
                        }
                        if (c21 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 109, 15, 15);
                        }
                        if (c22 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 109, 15, 15);
                        }
                        if (c23 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 109, 15, 15);
                        }
                        //newline
                        if (c24 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 127, 15, 15);
                        }
                        if (c25 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 127, 15, 15);
                        }
                        if (c26 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 127, 15, 15);
                        }
                        if (c27 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 127, 15, 15);
                        }
                        if (c28 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 127, 15, 15);
                        }
                        if (c29 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 127, 15, 15);
                        }
                        //newline
                        if (c30 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 145, 15, 15);
                        }
                        if (c31 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 145, 15, 15);
                        }
                        if (c32 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 145, 15, 15);
                        }
                        if (c33 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 145, 15, 15);
                        }
                        if (c34 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 145, 15, 15);
                        }
                        if (c35 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 145, 15, 15);
                        }
                        //newline
                        if (c36 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 163, 15, 15);
                        }
                        if (c37 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 163, 15, 15);
                        }
                        if (c38 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 163, 15, 15);
                        }
                        if (c39 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 163, 15, 15);
                        }
                        if (c40 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 163, 15, 15);
                        }
                        if (c41 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 163, 15, 15);
                        }
                        //newline
                        if (c2 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 22, y + 181, 15, 15);
                        }
                        if (c43 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 40, y + 181, 15, 15);
                        }
                        if (c44 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 58, y + 181, 15, 15);
                        }
                        if (c45 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 76, y + 181, 15, 15);
                        }
                        if (c46 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 94, y + 181, 15, 15);
                        }
                        if (c47 == true)
                        {
                            vbe.DrawFilledRectangle(new Pen(Color.LightGreen), x + 112, y + 181, 15, 15);
                        }
                        #endregion correctblock
                        //Don't be surprised next the time you run it, because the else words not needed before if(fixed)
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.minesweeper_opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.minesweeper_minimised = true;
                            }
                        }
                    }
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Minesw..."))
                    {
                        TaskManager.apps.Remove("Minesw...");
                    }
                    else
                    {
                        //TaskManager.apps.Add("Minesw...");
                    }
                }
            }
            if (minimise == true)
            {
                if (Mouse.Click())
                {
                    foreach (Tuple<string, int, int, int, int> z in Kernel.applist)
                    {
                        if (z.Item1 == "Minesw...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.minesweeper_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static byte[] flag = new byte[]
        {
            //width = 10;
            //height = 10;
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,1,0,0,0,0,
            0,0,0,0,2,1,0,0,0,0,
            0,0,0,2,3,1,0,0,0,0,
            0,0,2,3,3,1,0,0,0,0,
            0,2,3,3,3,1,0,0,0,0,
            2,2,2,2,2,1,0,0,0,0,
            0,0,0,0,0,1,0,0,0,0,
            0,0,0,0,0,1,0,0,0,0,
            0,0,1,1,1,1,1,1,1,0,
        };

        public static void normalcalc(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 10; h++)
            {
                for (uint w = 0; w < 10; w++)
                {
                    if (flag[h * 10 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (flag[h * 10 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.White), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (flag[h * 10 + w] == 3)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Red), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }

        public void drawboard(VBECanvas vbe,int x, int y, int bwidth)
        {
            int x1 = x + 22;
            int y1 = y + 55;//21 originally
            int currentx = x1 + 10;
            for (int i = 1; i < 49; i++)
            {
                vbe.DrawFilledRectangle(new Pen(Color.White), x1, y1, 15, 15);
                vbe.DrawRectangle(new Pen(Color.Black), x1, y1, 15, 15);
                if (x1 > (x + bwidth) - 51)
                {
                    x1 = x + 22;
                    y1 += 18;
                }
                else
                {
                    x1 += 18;
                }
            }
        }

        public void game_over(VBECanvas vbe, int x, int y)
        {
            if(gameover == true)
            {
                vbe.DrawFilledRectangle(new Pen(Color.Red), 650, 500, 350, 150);
                vbe.DrawRectangle(new Pen(Color.White), 650, 500, 350, 150);
                ASC16.DrawACSIIString(vbe, "Game over!", Color.Black, 765, 505);
                ASC16.DrawACSIIString(vbe, "You have lost the game. Click on Ok to\nstart a new game or click on Cancel to\nclose the game.", Color.Silver, 655, 535);
                //drawing ok button
                vbe.DrawFilledRectangle(new Pen(Color.White), 675, 600, 65, 30);
                vbe.DrawRectangle(new Pen(Color.Black), 675, 600, 65, 30);
                ASC16.DrawACSIIString(vbe, "Ok", Color.Black, 690, 610);
                //end of drawing ok button
                //drawing CANCEL button
                vbe.DrawFilledRectangle(new Pen(Color.White), 750, 600, 65, 30);
                vbe.DrawRectangle(new Pen(Color.Black), 750, 600, 65, 30);
                ASC16.DrawACSIIString(vbe, "Cancel", Color.Black, 760, 610);
                if (Mouse.Click())
                {
                    if(MouseManager.X > 750 && MouseManager.X < 750 + 65 && MouseManager.Y > 600 && MouseManager.Y < 630)
                    {
                        Booleans.minesweeper_opened = false;
                        endgame();
                        gameover = false;
                    }
                }
                if (Mouse.Click())
                {
                    if (MouseManager.X > 675 && MouseManager.X < 675 + 65 && MouseManager.Y > 600 && MouseManager.Y < 630)
                    {
                        endgame();
                        gameover = false;
                    }
                }
            }
            if (gameover == false)
            {

            }
        }
        
        public void endgame()
        {
            #region b0-b47
            b0 = false;
            b1 = false;
            b2 = false;
            b3 = false;
            b4 = false;
            b5 = false;
            b6 = false;
            b7 = false;
            b8 = false;
            b9 = false;
            b10 = false;
            b11 = false;
            b12 = false;
            b13 = false;
            b14 = false;
            b15 = false;
            b16 = false;
            b17 = false;
            b18 = false;
            b19 = false;
            b20 = false;
            b21 = false;
            b22 = false;
            b23 = false;
            b24 = false;
            b25 = false;
            b26 = false;
            b27 = false;
            b28 = false;
            b29 = false;
            b30 = false;
            b31 = false;
            b32 = false;
            b33 = false;
            b34 = false;
            b35 = false;
            b36 = false;
            b37 = false;
            b38 = false;
            b39 = false;
            b40 = false;
            b41 = false;
            b42 = false;
            b43 = false;
            b44 = false;
            b45 = false;
            b46 = false;
            b47 = false;
            #endregion b0-b47
            //clearing the bomb location
            a1 = 0;
            a2 = 0;
            a3 = 0;
            a4 = 0;
            a5 = 0;
            a6 = 0;
            a7 = 0;
            a8 = 0;
            a9 = 0;
            a10 = 0;
            //
            a11 = true;
            a22 = false;
            a33 = false;
            a44 = false;
            a55 = false;
            a66 = false;
            a77 = false;
            a88 = false;
            a99 = false;
            a1010 = false;
            
            #region c0-c47
            c0 = false;
            c1 = false;
            c2 = false;
            c3 = false;
            c4 = false;
            c5 = false;
            c6 = false;
            c7 = false;
            c8 = false;
            c9 = false;
            c10 = false;
            c11 = false;
            c12 = false;
            c13 = false;
            c14 = false;
            c15 = false;
            c16 = false;
            c17 = false;
            c18 = false;
            c19 = false;
            c20 = false;
            c21 = false;
            c22 = false;
            c23 = false;
            c24 = false;
            c25 = false;
            c26 = false;
            c27 = false;
            c28 = false;
            c29 = false;
            c30 = false;
            c31 = false;
            c32 = false;
            c33 = false;
            c34 = false;
            c35 = false;
            c36 = false;
            c37 = false;
            c38 = false;
            c39 = false;
            c40 = false;
            c41 = false;
            c42 = false;
            c43 = false;
            c44 = false;
            c45 = false;
            c46 = false;
            c47 = false;
            #endregion c0-c47

            //reseting timer
            timeresult = 0;
            ret = "";
        }
    }
}