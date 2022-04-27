/*
using Cosmos.HAL.Drivers.USB;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.Listing;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Console = System.Console;

namespace resolution.Applications
{
    class FileExplorer
    {
        public static Kernel kernel;
        public static List<char> stringToCharList(String input)
        {
            List<char> l = new List<char>();
            foreach (Char c in input)
            {
                l.Add(c);
            }
            return l;
        }
        public static String readFile(String path)
        {
            if (File.Exists(path))
            {
                try
                {
                    String st = "";
                    FileStream s = File.OpenRead(path);
                    byte[] a = new byte[s.Length];
                    s.Read(a, 0, a.Length);
                    foreach (Byte b in a)
                    {
                        st += (char)b;
                    }
                    return st;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
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
        public string text2 = "";
        public char currentChar;
        public static List<string> line;
        public static List<string> bottomremovedline;
        public static List<string> topremovedline;
        public static uint previousy = 115;
        public static uint newposx = 520;
        public static uint newposy = 115;
        public static uint scrollenght = 0;
        public uint x1 = 158;
        public uint y1 = 120;
        public static bool upwards = true;
        public static bool editmode = false;
        public static uint ay = 0;
        public static int i = 0;
        public static int activeline = 0;
        public static int cursx = 0;
        public static int cursy = 0;
        public static List<string> modified = new System.Collections.Generic.List<string>();
        public static bool moove_enabled = false;
        public static string content = "";
        public void File_Explorer(DoubleBufferedvbe vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise, string filename)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Notepa..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("Notepa...");
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
                            ///
                        }
                        if (moove_enabled == true)
                        {
                            Int_Manager.notepad_x = (int)MouseManager.X;
                            Int_Manager.notepad_y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                        ASC16.DrawACSIIString(vbe, "Notepad", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        //
                        vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 27, (uint)width - 10, 15, (uint)Color.LightGray.ToArgb());
                        ASC16.DrawACSIIString(vbe, "File", (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 28);
                        vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 50, (uint)width - 10, (uint)height - 55, (uint)Color.White.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 30, (uint)y + 50, 25, (uint)height - 105, (uint)Color.LightGray.ToArgb());
                        vbe.DrawFilledRectangle(newposx, newposy, 20, scrollenght, (uint)Color.Gray.ToArgb());
                        string texting = "";
                        #region scrollbar
                        if (Mouse.Click())
                        {
                            if (upwards == true)
                            {
                                if (tophiden.Count == 0)
                                {
                                    if (MouseManager.Y > 125 && MouseManager.Y < (y + height) - scrollenght)//(y + height) - 155
                                    {
                                        if (MouseManager.X > (x + width) - 25 && MouseManager.X < x + width)
                                        {
                                            if (MouseManager.Y > previousy)
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                                upwards = false;
                                            }
                                            /*
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                            ////
                                        }
                                        /*
                                        if (MouseManager.X > newposx && MouseManager.X < newposx + 20)
                                        {
                                            if (MouseManager.Y > newposy && MouseManager.Y < newposy + 150)
                                            {
                                                //try to set the x position
                                                /*
                                                if (MouseManager.Y > previousy)
                                                {
                                                    previousy = newposy;
                                                    newposy = MouseManager.Y - 15;
                                                }
                                                if (MouseManager.Y < previousy)
                                                {
                                                    previousy = newposy;
                                                    newposy = MouseManager.Y - 15;
                                                }
                                                */
                                        /*
                                        int lista = tophiden.Count;
                                        int listb = bottomhiden.Count;
                                        if (upwards == true)
                                        {
                                            ay += MouseManager.Y;
                                            upwards = false;
                                        }
                                        */
                                        /*
                                        else if (listb == 0)
                                        {
                                            if (ay < previousy)
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        */
                                        /*
                                        if (tophiden.Count != 0)
                                        {
                                            if (bottomhiden.Count == 0)
                                            {
                                                if (ay < previousy)
                                                {
                                                    previousy = newposy;
                                                    newposy -= previousy - ay;
                                                }
                                                else
                                                {

                                                }
                                            }
                                            else
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                            }
                                        }
                                        */
                                        /*
                                        if (ay != MouseManager.Y)
                                        {
                                            if (newposy + 150 == y + 115)
                                            {
                                                if (ay > previousy)
                                                {
                                                    previousy = newposy;
                                                    newposy += ay - previousy;
                                                }
                                                else
                                                {

                                                }
                                            }
                                            else
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                            }
                                            /*
                                            if (newposy + 150 == y + 115)
                                            {
                                                if (ay > previousy)
                                                {
                                                    previousy = newposy;
                                                    newposy += ay - previousy;
                                                }
                                                else
                                                {

                                                }
                                            }
                                            */
                                        /*
                                        if (ay < previousy)
                                        {
                                            previousy = newposy;
                                            newposy -= previousy - ay;//?
                                        }
                                        else
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                        */
                                        /*
                                        if (newposy + 150 == (y + height) - 5)
                                        {
                                            if (ay < previousy)
                                            {
                                                previousy = newposy;
                                                newposy -= previousy - ay;//?
                                            }
                                            else
                                            {

                                            }
                                        }
                                        */
                                        /*
                                        if (newposy + 150 <= (y + height) - 4)
                                        {
                                            ay = MouseManager.Y;
                                            //newposx = MouseManager.X;
                                            //uint ay2 = MouseManager.Y - 15;
                                            //uint num = MouseManager.Y - ay;
                                            if (ay > MouseManager.Y - 15)
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                                //previousy = newposy;
                                            }
                                        }
                                        if (newposy > y + 119)
                                        {
                                            if (MouseManager.X > newposx && MouseManager.X < newposx + 20)
                                            {
                                                if (MouseManager.Y > newposy && MouseManager.Y < newposy + 150)
                                                {
                                                    //newposx = MouseManager.X;
                                                    //uint ay2 = MouseManager.Y - 15;
                                                    //uint num = ay - MouseManager.Y;
                                                    if (ay < MouseManager.Y)
                                                    {
                                                        previousy = newposy;
                                                        newposy = MouseManager.Y + 15;
                                                        //previousy = newposy;
                                                    }
                                                }
                                            }
                                        }
                                        ///
                                    }
                                }
                            }
                            if(tophiden.Count != 0)
                            {
                                if (MouseManager.Y > 125 && MouseManager.Y < (y + height) - scrollenght)//(y + height) - 155
                                {
                                    if (MouseManager.X > (x + width) - 25 && MouseManager.X < x + width)
                                    {
                                        previousy = newposy;
                                        newposy = MouseManager.Y - 15;
                                        /*
                                        if (MouseManager.Y > previousy)
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                        if (MouseManager.Y < previousy)
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                        ///
                                    }
                                    /*
                                    if (MouseManager.X > newposx && MouseManager.X < newposx + 20)
                                    {
                                        if (MouseManager.Y > newposy && MouseManager.Y < newposy + 150)
                                        {
                                            //try to set the x position
                                            /*
                                            if (MouseManager.Y > previousy)
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                            }
                                            if (MouseManager.Y < previousy)
                                            {
                                                previousy = newposy;
                                                newposy = MouseManager.Y - 15;
                                            }
                                            */
                                    /*
                                    int lista = tophiden.Count;
                                    int listb = bottomhiden.Count;
                                    if (upwards == true)
                                    {
                                        ay += MouseManager.Y;
                                        upwards = false;
                                    }
                                    */
                                    /*
                                    else if (listb == 0)
                                    {
                                        if (ay < previousy)
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                        else
                                        {

                                        }
                                    }
                                    */
                                    /*
                                    if (tophiden.Count != 0)
                                    {
                                        if (bottomhiden.Count == 0)
                                        {
                                            if (ay < previousy)
                                            {
                                                previousy = newposy;
                                                newposy -= previousy - ay;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                    }
                                    */
                                    /*
                                    if (ay != MouseManager.Y)
                                    {
                                        if (newposy + 150 == y + 115)
                                        {
                                            if (ay > previousy)
                                            {
                                                previousy = newposy;
                                                newposy += ay - previousy;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        else
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                        }
                                        /*
                                        if (newposy + 150 == y + 115)
                                        {
                                            if (ay > previousy)
                                            {
                                                previousy = newposy;
                                                newposy += ay - previousy;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        */
                                    /*
                                    if (ay < previousy)
                                    {
                                        previousy = newposy;
                                        newposy -= previousy - ay;//?
                                    }
                                    else
                                    {
                                        previousy = newposy;
                                        newposy = MouseManager.Y - 15;
                                    }
                                    */
                                    /*
                                    if (newposy + 150 == (y + height) - 5)
                                    {
                                        if (ay < previousy)
                                        {
                                            previousy = newposy;
                                            newposy -= previousy - ay;//?
                                        }
                                        else
                                        {

                                        }
                                    }
                                    */
                                    /*
                                    if (newposy + 150 <= (y + height) - 4)
                                    {
                                        ay = MouseManager.Y;
                                        //newposx = MouseManager.X;
                                        //uint ay2 = MouseManager.Y - 15;
                                        //uint num = MouseManager.Y - ay;
                                        if (ay > MouseManager.Y - 15)
                                        {
                                            previousy = newposy;
                                            newposy = MouseManager.Y - 15;
                                            //previousy = newposy;
                                        }
                                    }
                                    if (newposy > y + 119)
                                    {
                                        if (MouseManager.X > newposx && MouseManager.X < newposx + 20)
                                        {
                                            if (MouseManager.Y > newposy && MouseManager.Y < newposy + 150)
                                            {
                                                //newposx = MouseManager.X;
                                                //uint ay2 = MouseManager.Y - 15;
                                                //uint num = ay - MouseManager.Y;
                                                if (ay < MouseManager.Y)
                                                {
                                                    previousy = newposy;
                                                    newposy = MouseManager.Y + 15;
                                                    //previousy = newposy;
                                                }
                                            }
                                        }
                                    }
                                    ///
                                }
                            }
                            if (tophiden.Count == 0)
                            {
                                upwards = true;
                            }
                        }
                        if (menu == true)
                        {
                            content = File.ReadAllText(filename);
                            //newposx = (uint)(x + width) - 25;
                            //newposy = (uint)(y + 30);
                            //x1 = (uint)x + 8;
                            //y1 = (uint)y + 55;
                            //cd = File.ReadAllText(@"0:\image.txt");
                            //tophiden.Add(" ");
                            foreach (string line in File.ReadAllLines(filename))
                            {
                                if (line.Length > 15)
                                {

                                }
                                if (wieved.Count < 10)
                                {
                                    wieved.Add(line);
                                }
                                else
                                {
                                    bottomhiden.Add(line);
                                }
                                i += 1;
                            }
                            int fellow = 0;
                            foreach(string line2 in bottomhiden)
                            {
                                fellow += 1;
                            }
                            if(fellow > 0)
                            {
                                //int minus = i * 5;
                                //scrollenght = (uint)(y + height) - 145;
                                //scrollenght = (uint)(y + height) - (uint)(130 + 15);
                                scrollenght = (uint)height - (uint)(130 + 15);
                            }
                            // The 15 can be modified
                            //tophiden.Add(" ");
                            menu = false;
                        }
                        #region
                        /*
                        if (newposy < previousy)
                        {
                            int f = (int)previousy - (int)newposy;
                            if (f > 9)
                            {
                                if (f > 12)
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
                            if (f > 9)
                            {
                                if (f > 12)
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
                        ///
                        #endregion
                        #region textediting
                        KeyEvent keyEvent;
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if(MouseManager.Y > 120 && MouseManager.Y < 135)
                                {
                                    editmode = true;
                                    activeline = 1;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 135 && MouseManager.Y < 150)
                                {
                                    editmode = true;
                                    activeline = 2;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 150 && MouseManager.Y < 165)
                                {
                                    editmode = true;
                                    activeline = 3;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 165 && MouseManager.Y < 180)
                                {
                                    editmode = true;
                                    activeline = 4;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 180 && MouseManager.Y < 195)
                                {
                                    editmode = true;
                                    activeline = 5;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 195 && MouseManager.Y < 210)
                                {
                                    editmode = true;
                                    activeline = 6;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 210 && MouseManager.Y < 225)
                                {
                                    editmode = true;
                                    activeline = 7;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 225 && MouseManager.Y < 240)
                                {
                                    editmode = true;
                                    activeline = 8;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 240 && MouseManager.Y < 255)
                                {
                                    editmode = true;
                                    activeline = 9;
                                }
                            }
                            if (MouseManager.X > 158 && MouseManager.X < (158 + width) - 5)
                            {
                                if (MouseManager.Y > 255 && MouseManager.Y < 270)
                                {
                                    editmode = true;
                                    activeline = 10;
                                }
                            }
                        }
                        /*
                        if (editmode == true)
                        {
                            if (activeline == 1)
                            {
                                //cursy = 120;
                                if(KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if(key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach(string s in wieved.GetRange(0, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(0, 1);
                                        wieved.Insert(0, xe);
                                        
                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(0, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(0, 1);
                                        wieved.Insert(0, xd);
                                    }
                                }
                                string nd = "";
                                foreach (string s in wieved.GetRange(0, 1))
                                {
                                    nd += s;
                                }
                                cursy = 120;
                                cursx = (x + 8) + (nd.Length * 8);
                            }
                            if (activeline == 2)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(1, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(1, 1);
                                        wieved.Insert(1, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(1, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(1, 1);
                                        wieved.Insert(1, xd);
                                    }
                                }
                                string nd = "";
                                foreach (string s in wieved.GetRange(1, 1))
                                {
                                    nd += s;
                                }
                                cursy = 135;
                                cursx = (x + 8) + (nd.Length * 8);
                            }
                            //further work from here MAN!!!
                            if (activeline == 3)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(2, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(2, 1);
                                        wieved.Insert(2, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(2, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(2, 1);
                                        wieved.Insert(2, xd);
                                    }
                                }
                            }
                            if (activeline == 4)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(3, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(3, 1);
                                        wieved.Insert(3, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(3, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(3, 1);
                                        wieved.Insert(3, xd);
                                    }
                                }
                            }
                            if (activeline == 5)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(4, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(4, 1);
                                        wieved.Insert(4, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(4, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(4, 1);
                                        wieved.Insert(4, xd);
                                    }
                                }
                            }
                            if (activeline == 6)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(5, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(5, 1);
                                        wieved.Insert(5, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(5, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(5, 1);
                                        wieved.Insert(5, xd);
                                    }
                                }
                            }
                            if (activeline == 7)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(6, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(6, 1);
                                        wieved.Insert(6, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(6, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(6, 1);
                                        wieved.Insert(6, xd);
                                    }
                                }
                            }
                            if (activeline == 8)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(7, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(7, 1);
                                        wieved.Insert(7, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(7, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(7, 1);
                                        wieved.Insert(7, xd);
                                    }
                                }
                            }
                            if (activeline == 9)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(8, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(8, 1);
                                        wieved.Insert(8, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(8, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(8, 1);
                                        wieved.Insert(8, xd);
                                    }
                                }
                            }
                            if (activeline == 10)
                            {
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    if (key.Key == ConsoleKeyEx.Backspace)
                                    {
                                        string xd = "";
                                        string xe = "";
                                        foreach (string s in wieved.GetRange(9, 1))
                                        {
                                            xd = s;
                                        }
                                        xe = xd.Remove(xd.Length - 1);
                                        wieved.RemoveRange(9, 1);
                                        wieved.Insert(9, xe);

                                    }
                                    else
                                    {
                                        string xd = "";
                                        foreach (string s in wieved.GetRange(9, 1))
                                        {
                                            xd += s;
                                        }
                                        xd += key.KeyChar;
                                        wieved.RemoveRange(9, 1);
                                        wieved.Insert(9, xd);
                                    }
                                }
                            }
                        }
                        ///
                        if (editmode == false)
                        {

                        }
                        #endregion textediting
                        #region cursor
                        vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), cursx, cursy, cursx, cursy + 15);
                        #endregion cursor
                        if (newposy > 110 && newposy < 115)
                        {
                            if (tophiden.Count != 0)
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
                            else
                            {

                            }
                        }
                        if (newposy > 115 && newposy < 120)
                        {
                            if(tophiden.Count != 1)
                            {
                                foreach (string line in wieved.GetRange(0, 1))
                                {
                                    tophiden.Add(line);
                                    wieved.Remove(line);
                                }
                                foreach (string line in bottomhiden.GetRange(0, 1))
                                {
                                    wieved.Add(line);
                                    bottomhiden.Remove(line);
                                }
                            }
                            else
                            {

                            }
                        }
                        if (newposy > 120 && newposy < 125)
                        {
                            if (tophiden.Count != 2)
                            {
                                foreach (string line in wieved.GetRange(0, 1))
                                {
                                    tophiden.Add(line);
                                    wieved.Remove(line);
                                }
                                foreach (string line in bottomhiden.GetRange(0, 1))
                                {
                                    wieved.Add(line);
                                    bottomhiden.Remove(line);
                                }
                            }
                            else
                            {

                            }
                        }
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
                                content += keyEvent.KeyChar;
                                /*
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
                                ///
                            }
                        }
                        foreach (string c in wieved)
                        {
                            ASC16.DrawACSIIString(vbe, c, (uint)Color.Black.ToArgb(), (uint)x1, (uint)y1);
                            y1 += 15;
                        }
                        //ASC16.DrawACSIIString(vbe, cd, (uint)Color.Black.ToArgb(), 600, 150);
                        //string[] linesoftext = File.ReadAllLines(@"0:\longdoc.txt");
                        #endregion scrollbar
                        ASC16.DrawACSIIString(vbe, content, (uint)Color.Black.ToArgb(), 800, 5);
                        KeyEvent h;
                        if(KeyboardManager.TryReadKey(out h))
                        {
                            if(h.Key == ConsoleKeyEx.Enter)
                            {
                                content += "\n";
                            }
                            if(h.Key == ConsoleKeyEx.Backspace)
                            {
                                content.Remove(content.Length - 1);
                            }
                            else
                            {
                                content += keyEvent.KeyChar;
                            }
                        }
                        //ASC16.DrawACSIIString(vbe, text, (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 55);
                        //vbe.DoubleBuffer_DrawLine((uint)Color.Black.ToArgb(), a, y + 52, a, y + 60);
                        //KeyEvent keyEvent;
                        //ASC16.DrawACSIIString(vbe, text2, (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 55);
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
                        if (Kernel.filepage == true)
                        {
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 45, 70, 140, (uint)Color.LightGray.ToArgb());
                            ASC16.DrawACSIIString(vbe, "Save", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 48);
                            ASC16.DrawACSIIString(vbe, "Open...", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 68);
                            ASC16.DrawACSIIString(vbe, "New file", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 88);
                            //Action for save
                            if (Mouse.Click())
                            {
                                if(MouseManager.X > x + 5 && MouseManager.X < x + 75)
                                {
                                    if(MouseManager.Y > y + 48 && MouseManager.Y < y + 63)
                                    {
                                        /*
                                        foreach(string line in tophiden)
                                        {
                                            modified.Add(line);
                                        }
                                        foreach (string line in wieved)
                                        {
                                            modified.Add(line);
                                        }
                                        foreach (string line in bottomhiden)
                                        {
                                            modified.Add(line);
                                        }
                                        string complete = "";
                                        foreach(string line in modified)
                                        {
                                            complete += line + "\n";
                                            
                                        }
                                        //Kernel.writeFile(filename, true, complete);
                                        string filename2 = filename;
                                        File.Delete(filename);
                                        File.Create(filename2);
                                        File.WriteAllText(filename2, complete);
                                        ///
                                        string filename2 = filename;
                                        File.Delete(filename);
                                        File.Create(filename2);
                                        File.WriteAllText(filename2, content);
                                    }
                                }
                            }
                        }
                        if (Kernel.filepage == false)
                        {

                        }
                    }
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Notepa..."))
                    {
                        TaskManager.apps.Remove("Notepa...");
                    }
                    else
                    {
                        //TaskManager.apps.Remove("Notepa...");
                    }
                }
            }
            if (minimise == true)
            {
                if (Mouse.Click())
                {
                    foreach (Tuple<string, int, int, int, int> z in Kernel.applist)
                    {
                        if (z.Item1 == "Notepa...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Kernel.minimise = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        public unsafe class MemoryManager
        {
            // blocks
            public static List<MemoryBlock> Blocks { get; private set; } = new List<MemoryBlock>();
            public static int Count { get { return Blocks.Count; } }

            // properties
            public static uint BaseStart { get; private set; } = 0x400000;
            public static uint BaseEnd { get; private set; } = 0x100000;
            public static uint Size { get { return BaseStart - BaseEnd; } }
            public static uint Pointer { get; private set; } = BaseStart;

            // task
            public static Task Task = new Task("memmgr", "memmgr");

            // allocate memory
            public static MemoryBlock AllocateBlock(uint size)
            {
                // create block
                Pointer -= size;
                MemoryBlock block = new MemoryBlock(Pointer, size);
                block.Fill(0x00);
                block.Allocated = true;

                // add block
                Blocks.Add(block);

                // update indices
                UpdateIndexValues();

                // log
                //ShowMessage("new", (int)block.Base, block.Size, true);

                // return 
                return block;
            }

            // unallocate memory
            public static bool Unallocate(MemoryBlock block)
            {
                // unable to unallocate
                if (!block.Allocated) { return false; }

                // clear region
                block.Fill(0x00);

                // remove and update indices
                Blocks.RemoveAt((int)block.Index);
                UpdateIndexValues();

                // log
                //ShowMessage("del", (int)block.Base, block.Size, true);

                // return
                return true;

            }

            // update indexes
            private static void UpdateIndexValues()
            {
                for (uint i = 0; i < Blocks.Count; i++) { Blocks[(int)i].Index = i; }
                if (Blocks.Count == 0) { Pointer = BaseStart; }
            }

            // swape range of memory
            public static void Swap(byte* dest, byte* source, uint len)
            {
                for (uint i = 0; i < len; i++)
                    if (*(dest + i) != *(source + i))
                        *(dest + i) = *(source + i);
            }

            // swap range of memory using blocks
            public static void Swap(MemoryBlock dest, MemoryBlock src, uint len) { Swap(dest.Base, src.Base, len); }

            // copy range of memory
            public static void Copy(byte* src, byte* dest, uint len)
            {
                for (uint i = 0; i < len; i++) { *(dest + i) = *(src + i); }
            }


            // get free memory
            public static uint GetFree()
            {
                uint free = 0;
                for (int i = 0; i < Blocks.Count; i++) { free += Blocks[i].GetFree(); }
                return free;
            }

            // get used memory
            public static uint GetUsed()
            {
                uint used = 0;
                for (int i = 0; i < Blocks.Count; i++) { used += Blocks[i].GetUsed(); }
                return used;
            }

            // get total memory
            public static uint GetSize() { return Size; }
        }
        public unsafe class MemoryBlock
        {
            // properties
            public byte* Base { get; private set; }
            public uint Size { get; private set; }
            public uint Index { get; set; }
            public bool Allocated { get; set; }

            // memory
            public uint AmountFree { get; private set; }
            public uint AmountUsed { get; private set; }

            // usage
            private bool changed = false;
            private uint free, used;

            // constructors
            public MemoryBlock(uint offset, uint size)
            {
                this.Base = (byte*)offset;
                this.Size = size;
                this.Allocated = false;
            }

            // fill
            public void Fill(byte data) { for (int i = 0; i < Size; i++) { Base[i] = data; } }

            // copy data to different address
            public void Copy(byte* dest, uint index, uint len)
            {
                for (uint i = 0; i < len; i++)
                { *(dest + i) = *(Base + index + i); }
            }

            // write 8-bit integer
            public bool WriteInt8(uint offset, byte data)
            {
                if (offset >= Size) { Console.WriteLine("Tried to write out of memory bounds: " + offset.ToString()); return false; }
                Base[offset] = data;
                changed = true;
                return true;
            }

            // write 16-bit integer
            public bool WriteInt16(uint offset, ushort data)
            {
                if (offset + 1 >= Size) { Console.WriteLine("Tried to write out of memory bounds: " + (offset + 1).ToString()); return false; }
                Base[offset] = (byte)((data & 0xFF00) >> 8);
                Base[offset + 1] = (byte)(data & 0x00FF);
                changed = true;
                return true;
            }

            // write 32-bit integer
            public bool WriteInt32(uint offset, uint data)
            {
                if (offset + 3 >= Size) { Console.WriteLine("Tried to write out of memory bounds: " + (offset + 3).ToString()); return false; }
                Base[offset] = (byte)((data & 0xFF000000) >> 24);
                Base[offset + 1] = (byte)((data & 0x00FF0000) >> 16);
                Base[offset + 2] = (byte)((data & 0x0000FF00) >> 8);
                Base[offset + 3] = (byte)(data & 0x000000FF);
                changed = true;
                return true;
            }

            // write character
            public bool WriteChar(uint offset, char data) { return WriteInt8(offset, (byte)data); }

            // write string
            public bool WriteString(uint offset, string data)
            {
                if (offset + data.Length + 1 >= Size) { return false; }
                for (uint i = 0; i < data.Length; i++) { Base[offset + i] = (byte)data[(int)i]; }
                changed = true;
                return true;
            }

            // read 8-bit integer
            public byte ReadInt8(uint offset)
            {
                if (offset >= Size) { Console.WriteLine("Tried to read out of memory bounds: " + offset.ToString()); return 0; }
                byte data = Base[offset];
                return data;
            }

            // read 16-bit integer
            public ushort ReadInt16(uint offset)
            {
                if (offset + 1 >= Size) { Console.WriteLine("Tried to read out of memory bounds: " + (offset + 1).ToString()); return 0; }
                ushort data = (ushort)((Base[offset] << 8) | Base[offset + 1]);
                return data;
            }

            // read 32-bit integer
            public uint ReadInt32(uint offset)
            {
                if (offset + 3 >= Size) { Console.WriteLine("Tried to read out of memory bounds: " + (offset + 3).ToString()); return 0; }
                uint data = (uint)((Base[offset] << 24) | (Base[offset + 1] << 16) | Base[offset + 2] << 8 | Base[offset + 3]);
                return data;
            }

            // read character
            public char ReadChar(uint offset) { return (char)ReadInt8(offset); }

            // read string
            public string ReadString(uint offset, uint len)
            {
                if (offset + len >= Size) { Console.WriteLine("Tried to read out of memory bounds: " + (offset + len).ToString()); return string.Empty; }
                string text = "";
                for (uint i = 0; i < len; i++) { text += Base[offset + i]; }
                return text;
            }

            // update usage stats
            public void UpdateUsage(bool onChange)
            {
                if (onChange)
                {
                    if (changed)
                    {
                        free = 0;
                        used = 0;
                        for (uint i = 0; i < Size; i++) { if (Base[i] == 0) { free++; } else { used++; } }
                        changed = false;
                    }
                }
                else
                {
                    free = 0;
                    used = 0;
                    for (uint i = 0; i < Size; i++) { if (Base[i] == 0) { free++; } else { used++; } }
                    changed = false;
                }
            }

            // get amount free
            public uint GetFree() { return free; }

            // get amount used
            public uint GetUsed() { return used; }

            // get amount total
            public uint GetTotal() { return Size; }
        }

        public class Task
        {
            // properties
            public string Name { get; private set; }
            public string UID { get; private set; }
            public int ID { get; set; }

            // memory usage
            public uint MemoryUsed { get; set; }
            public uint MemoryFree { get; set; }
            public uint MemoryTotal { get; set; }

            // constructor
            public Task(string name, string uid)
            {
                this.Name = name;
                this.UID = uid;
                this.ID = 0;
            }

        }
    }
}
*/