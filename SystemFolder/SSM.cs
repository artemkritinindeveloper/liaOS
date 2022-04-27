using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosDrawString;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace resolution
{
    class SSM
    {
        public void ssm(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool minimise)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    if (Mouse.Click())
                    {
                        if (MouseManager.X > x + 3 && MouseManager.X < (x + width) - 05)
                        {
                            if (MouseManager.Y > y + 3 && MouseManager.Y < y + 40)
                            {
                                //Kernel.x = (int)MouseManager.X - 40;
                                //Kernel.y = (int)MouseManager.Y - 20;
                            }
                        }
                    }
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                    vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                    vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                    ASC16.DrawACSIIString(vbe, "SSM - System Shortcut Manager", Color.White, (uint)x + 5, (uint)y + 3);
                    //vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                    //
                    if (Booleans.firstwindow == true)
                    {
                        ASC16.DrawACSIIString(vbe, "Welcome to System Shortcut Manager visard. In the next few\nsteps you can create your own shortcut. If you didn't know\nwhat a shortcut is then click HERE.", Color.Black, (uint)x + 5, (uint)y + 35);
                        ASC16.DrawACSIIString(vbe, "Location of the executable file:", Color.Black, (uint)x + 5, (uint)y + 165);
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 265, y + 165, 230, 15);
                        vbe.DrawRectangle(new Pen(Color.Black), x + 265, y + 165, 230, 15);
                        ASC16.DrawACSIIString(vbe, Booleans.executable, Color.Black, (uint)x + 268, (uint)y + 167);
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), (x + width) - 40, (y + height) - 35, 35, 15);
                        vbe.DrawRectangle(new Pen(Color.Blue), (x + width) - 40, (y + height) - 35, 35, 15);
                        ASC16.DrawACSIIString(vbe, "Next", Color.Black, (uint)(x + width) - 37, (uint)(y + height - 34));
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > (x + width) - 40 && MouseManager.X < x + width - 5)
                            {
                                if (MouseManager.Y > (y + height) - 35 && MouseManager.Y < (y + height) - 20)
                                {
                                    Booleans.firstwindow = false;
                                    Booleans.secondwindow = true;
                                }
                            }
                        }
                    }
                    if(Booleans.firstwindow == false)
                    {

                    }
                    if(Booleans.secondwindow == true)
                    {
                        ASC16.DrawACSIIString(vbe, "In step two you have to give the location where the\nshortcut be placed.\nIMPORTANT: Please add the shortcut name too.(without an extension)", Color.Black, (uint)x + 5, (uint)y + 35);
                        ASC16.DrawACSIIString(vbe, "The shortcut will be placed at:", Color.Black, (uint)x + 5, (uint)y + 165);
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 265, y + 165, 230, 15);
                        vbe.DrawRectangle(new Pen(Color.Black), x + 265, y + 165, 230, 15);
                        ASC16.DrawACSIIString(vbe, Booleans.shortcutlocation, Color.Black, (uint)x + 268, (uint)y + 167);
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), (x + width) - 40, (y + height) - 35, 35, 15);
                        vbe.DrawRectangle(new Pen(Color.Blue), (x + width) - 40, (y + height) - 35, 35, 15);
                        ASC16.DrawACSIIString(vbe, "Next", Color.Black, (uint)(x + width) - 37, (uint)(y + height - 34));
                        if(Booleans.shortcutlocation.Length > 4)
                        {
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > (x + width) - 40 && MouseManager.X < x + width - 5)
                                {
                                    if (MouseManager.Y > (y + height) - 35 && MouseManager.Y < (y + height) - 20)
                                    {
                                        File.Create(Booleans.shortcutlocation + ".sct");
                                        File.WriteAllText(Booleans.shortcutlocation + ".sct", Booleans.executable);
                                        Booleans.secondwindow = false;
                                        Booleans.thirdwindow = true;
                                    }
                                }
                            }
                        }
                    }
                    if(Booleans.secondwindow == false)
                    {

                    }
                    if(Booleans.thirdwindow == true)
                    {
                        ASC16.DrawACSIIString(vbe, "CONGRATULATIONS!\nYou successfuly created your shortcut. The visard will be closed\nafter clicking on the finish button.", Color.Black, (uint)x + 5, (uint)y + 35);
                        //ASC16.DrawACSIIString(vbe, "The location where the shortcut will be placed:", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 165);
                        //vbe.DrawFilledRectangle((uint)x + 265, (uint)y + 165, 230, 15, (uint)Color.White.ToArgb());
                        //vbe.DrawRectangle((uint)Color.Black.ToArgb(), x + 265, y + 165, 230, 15);
                        //ASC16.DrawACSIIString(vbe, Kernel.shortcutlocation, (uint)Color.Black.ToArgb(), (uint)x + 268, (uint)y + 167);
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), (x + width) - 45, (y + height) - 35, 40, 15);
                        vbe.DrawRectangle(new Pen(Color.Blue), (x + width) - 45, (y + height) - 35, 40, 15);
                        ASC16.DrawACSIIString(vbe, "Finish", Color.Black, (uint)(x + width) - 42, (uint)(y + height - 34));
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > (x + width) - 45 && MouseManager.X < x + width - 5)
                            {
                                if (MouseManager.Y > (y + height) - 35 && MouseManager.Y < (y + height) - 20)
                                {
                                    Booleans.egy = false;
                                }
                            }
                        }
                    }
                    if(Booleans.thirdwindow == false)
                    {

                    }
                    //
                    System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                    if (Mouse.Click())
                    {
                        if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                        {
                            if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                            {
                                Booleans.SSM_opened = false;
                            }
                        }
                    }
                    if (Mouse.Click())
                    {
                        if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                        {
                            Booleans.SSM_minimised = true;
                        }
                    }
                }
            }
        }
    }
}
