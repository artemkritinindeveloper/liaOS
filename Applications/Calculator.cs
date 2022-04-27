using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosDrawString;
using CosmosKernel8.Drivers;
using resolution.iconmanager;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using windows_95;
using Kernel = CrystalOS.Kernel;

namespace resolution.Applications
{
    class Calculator
    {
        public string text;
        public ConsoleKey ConsoleKey;
        public static bool moove_enabled = false;
        public void calculator(VBECanvas vbe, int x, int y, int width, int height, bool settings, bool minimise, string text, string secnum, bool num1, bool num2, bool result)
        {
            if (minimise == false)
            {
                if (settings == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Calc..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("Calc...");
                    }
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
                        Int_Manager.calc_x = (int)MouseManager.X;
                        Int_Manager.calc_x = (int)MouseManager.Y;
                        if (Mouse.RightClick())
                        {
                            moove_enabled = false;
                        }
                    }
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                    vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                    vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                    ASC16.DrawACSIIString(vbe, "Calculator", Color.White, (uint)x + 5, (uint)y + 3);//originally 5
                    //Calcicon.tinycalc(vbe, (uint)x + 4, (uint)y + 4);
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                    //
                    //
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 5, y + 24, width - 10, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 5, y + 24, width - 10, 30);
                    //
                    //buttons
                    #region button
                    //one
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 59, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 59, 30, 30);
                    ASC16.DrawACSIIString(vbe, "7", Color.Black, (uint)x + 15, (uint)y + 71);
                    //two
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 36, y + 59, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 36, y + 59, 30, 30);
                    ASC16.DrawACSIIString(vbe, "8", Color.Black, (uint)x + 48, (uint)y + 71);
                    //three
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 69, y + 59, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 69, y + 59, 30, 30);
                    ASC16.DrawACSIIString(vbe, "9", Color.Black, (uint)x + 81, (uint)y + 71);
                    //four
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 92, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 92, 30, 30);
                    ASC16.DrawACSIIString(vbe, "4", Color.Black, (uint)x + 15, (uint)y + 104);
                    //five
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 36, y + 92, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 36, y + 92, 30, 30);
                    ASC16.DrawACSIIString(vbe, "5", Color.Black, (uint)x + 48, (uint)y + 104);
                    //six
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 69, y + 92, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 69, y + 92, 30, 30);
                    ASC16.DrawACSIIString(vbe, "6", Color.Black, (uint)x + 81, (uint)y + 104);
                    //seven
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 125, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 125, 30, 30);
                    ASC16.DrawACSIIString(vbe, "1", Color.Black, (uint)x + 15, (uint)y + 137);
                    //eight
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 36, y + 125, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 36, y + 125, 30, 30);
                    ASC16.DrawACSIIString(vbe, "2", Color.Black, (uint)x + 48, (uint)y + 137);
                    //nine
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 69, y + 125, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 69, y + 125, 30, 30);
                    ASC16.DrawACSIIString(vbe, "3", Color.Black, (uint)x + 81, (uint)y + 137);
                    //zero
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 158, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 3, y + 158, 30, 30);
                    ASC16.DrawACSIIString(vbe, "0", Color.Black, (uint)x + 15, (uint)y + 170);
                    //add
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 102, y + 59, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 102, y + 59, 30, 30);
                    ASC16.DrawACSIIString(vbe, "+", Color.Black, (uint)x + 114, (uint)y + 71);
                    //minus
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 102, y + 92, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 102, y + 92, 30, 30);
                    ASC16.DrawACSIIString(vbe, "-", Color.Black, (uint)x + 114, (uint)y + 104);
                    //*
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 102, y + 125, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 102, y + 125, 30, 30);
                    ASC16.DrawACSIIString(vbe, "*", Color.Black, (uint)x + 114, (uint)y + 137);
                    //divide
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 102, y + 158, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 102, y + 158, 30, 30);
                    ASC16.DrawACSIIString(vbe, "/", Color.Black, (uint)x + 114, (uint)y + 170);
                    //delete a number
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 36, y + 158, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 36, y + 158, 30, 30);
                    ASC16.DrawACSIIString(vbe, "<-", Color.Black, (uint)x + 45, (uint)y + 170);
                    //enter
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 69, y + 158, 30, 30);
                    vbe.DrawRectangle(new Pen(Color.Black), x + 69, y + 158, 30, 30);
                    ASC16.DrawACSIIString(vbe, "=", Color.Black, (uint)x + 81, (uint)y + 170);
                    #endregion button
                    //
                    System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                    if (Mouse.Click())
                    {
                        if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                        {
                            if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                            {
                                Booleans.calculator_opened = false;
                            }
                        }
                    }
                    if (Mouse.Click())
                    {
                        if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                        {
                            Booleans.calculator_minimised = true;
                        }
                    }
                    KeyEvent keyEvent;
                    KeyboardManager.TryReadKey(out keyEvent);
                    if (Booleans.num1 == true)
                    {
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.text += '7';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.text += '8';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.text += '9';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.text += '4';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.text += '5';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.text += '6';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 155))
                                {
                                    Booleans.text += '1';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 155))
                                {
                                    Booleans.text += '2';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 165))
                                {
                                    Booleans.text += '3';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 188))
                                {
                                    Booleans.text += '0';
                                }
                            }
                        }
                        //actions
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 191))
                                {
                                    Booleans.text = Booleans.text.Remove(Booleans.text.Length - 1);
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 102 && (CurMouse.X < x + 135)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 191))
                                {
                                    Booleans.num1 = false;
                                    Booleans.action = "divide";
                                    Booleans.num2 = true;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 102 && (CurMouse.X < x + 135)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 158))
                                {
                                    Booleans.action = "multiply";
                                    Booleans.num2 = true;
                                    Booleans.num1 = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 102 && (CurMouse.X < x + 135)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 125))
                                {
                                    Booleans.num1 = false;
                                    Booleans.action = "minus";
                                    Booleans.num2 = true;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 102 && (CurMouse.X < x + 135)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 92))
                                {
                                    Booleans.num1 = false;
                                    Booleans.action = "plus";
                                    Booleans.num2 = true;
                                }
                            }
                        }
                        ASC16.DrawACSIIString(vbe, text, Color.Black, (uint)(x + width) - (uint)(10 + (text.ToString().Length * 10)), (uint)y + 36);
                        if (keyEvent.Key == ConsoleKeyEx.Num1)
                        {
                            Booleans.text += '1';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num2)
                        {
                            Booleans.text += '2';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num3)
                        {
                            Booleans.text += '3';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num4)
                        {
                            Booleans.text += '4';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num5)
                        {
                            Booleans.text += '5';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num6)
                        {
                            Booleans.text += '6';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num7)
                        {
                            Booleans.text += '7';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num8)
                        {
                            Booleans.text += '8';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num9)
                        {
                            Booleans.text += '9';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num0)
                        {
                            Booleans.text += '0';
                        }
                        else
                        {
                            if (keyEvent.Key == ConsoleKeyEx.D1)
                            {
                                Booleans.action = "multiply";
                                Booleans.num2 = true;
                                Booleans.num1 = false;
                            }
                            if (keyEvent.Key == ConsoleKeyEx.D2)
                            {
                                Booleans.num1 = false;
                                Booleans.action = "divide";
                                Booleans.num2 = true;
                            }
                            if (keyEvent.Key == ConsoleKeyEx.D3)
                            {
                                Booleans.num1 = false;
                                Booleans.action = "minus";
                                Booleans.num2 = true;
                            }
                            if (keyEvent.Key == ConsoleKeyEx.D4)
                            {
                                Booleans.num1 = false;
                                Booleans.action = "plus";
                                Booleans.num2 = true;
                            }
                        }
                    }
                    if (Booleans.num1 == false)
                    {

                    }
                    if (Booleans.num2 == true)
                    {
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.secnum += '7';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.secnum += '8';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 59) && (CurMouse.Y < y + 89))
                                {
                                    Booleans.secnum += '9';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.secnum += '4';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.secnum += '5';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 92) && (CurMouse.Y < y + 122))
                                {
                                    Booleans.secnum += '6';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 155))
                                {
                                    Booleans.secnum += '1';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 155))
                                {
                                    Booleans.secnum += '2';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 125) && (CurMouse.Y < y + 165))
                                {
                                    Booleans.secnum += '3';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 3 && (CurMouse.X < x + 33)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 188))
                                {
                                    Booleans.secnum += '0';
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 69 && (CurMouse.X < x + 102)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 191))
                                {
                                    Booleans.result = true;
                                    Booleans.num2 = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > x + 36 && (CurMouse.X < x + 69)))
                            {
                                if ((CurMouse.Y > y + 158) && (CurMouse.Y < y + 191))
                                {
                                    Booleans.secnum = Booleans.text.Remove(Booleans.secnum.Length - 1);
                                }
                            }
                        }
                        ASC16.DrawACSIIString(vbe, secnum, Color.Black, (uint)(x + width) - (uint)(10 + (secnum.ToString().Length * 10)), (uint)y + 36);
                        if (keyEvent.Key == ConsoleKeyEx.Num1)
                        {
                            Booleans.secnum += '1';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num2)
                        {
                            Booleans.secnum += '2';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num3)
                        {
                            Booleans.secnum += '3';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num4)
                        {
                            Booleans.secnum += '4';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num5)
                        {
                            Booleans.secnum += '5';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num6)
                        {
                            Booleans.secnum += '6';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num7)
                        {
                            Booleans.secnum += '7';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num8)
                        {
                            Booleans.secnum += '8';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num9)
                        {
                            Booleans.secnum += '9';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.Num0)
                        {
                            Booleans.secnum += '0';
                        }
                        if (keyEvent.Key == ConsoleKeyEx.R)
                        {
                            Booleans.result = true;
                            Booleans.num2 = false;
                        }
                    }
                    if (Booleans.num2 == false)
                    {

                    }
                    if (Booleans.result == true)
                    {
                        int.TryParse(text, out int number1);
                        int.TryParse(secnum, out int number2);

                        if (Booleans.action == "multiply")
                        {
                            Booleans.resutment = number1 * number2;
                        }
                        if (Booleans.action == "divide")
                        {
                            Booleans.resutment = number1 / number2;
                        }
                        if (Booleans.action == "minus")
                        {
                            Booleans.resutment = number1 - number2;
                        }
                        if (Booleans.action == "plus")
                        {
                            Booleans.resutment = number1 + number2;
                        }
                        ASC16.DrawACSIIString(vbe, Booleans.resutment.ToString(), Color.Black, (uint)(x + width) - (uint)(10 + (Booleans.resutment.ToString().Length * 10)), (uint)y + 36);
                    }
                    if (Booleans.result == false)
                    {

                    }
                }
                if (settings == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Calc..."))
                    {
                        TaskManager.apps.Remove("Calc...");
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
                        if (z.Item1 == "Calc...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.calculator_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
