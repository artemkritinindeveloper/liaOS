using Cosmos.System;
using Cosmos.System.FileSystem.Listing;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.Applications;
using resolution.Graphical_Resource_Pack;
using resolution.iconmanager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Kernel = CrystalOS.Kernel;
using Cosmos.System.Graphics;

namespace resolution.SystemFolder
{
    class dialogbox
    {
        Kernel k = new Kernel();
        public static string currentdir = @"0:\";
        public int y1 = 0;
        public int x1 = 0;
        public static List<Tuple<int, int, int, int, String>> Files = new List<Tuple<int, int, int, int, String>>();
        public static List<Tuple<int, int, int, int, String>> Folders = new List<Tuple<int, int, int, int, String>>();
        public static List<Tuple<string>> PrevDirs = new List<Tuple<string>>();
        public static List<string> options = new List<string>();
        public static bool enabeled = true;
        int listcounter = 0;
        public static int counter = 0;
        public static string newstring = "";
        public static string textboxcontent = "t";
        public static bool opened = false;
        public static string choosed = "";
        public static bool moove_enabled = false;
        public void Savedialog(VBECanvas vbe, int x, int y)
        {
            if(Booleans.dialogbox_opened == true)
            {
                if(Booleans.dialogbox_minimised == false)
                {
                    #region
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("Create file/..."))
                    {

                    }
                    else
                    {
                        TaskManager.apps.Add("Create file/...");
                    }
                    if (y1 == 0)
                    {
                        y1 = y + 46;
                    }
                    if (x1 == 0)
                    {
                        x1 = x + 103;
                    }
                    int width = 400;
                    int height = 300;
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                    vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                    vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                    ASC16.DrawACSIIString(vbe, "Creating file/folder", Color.White, (uint)x + 5, (uint)y + 3);
                    //vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                    vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                    //Making the base white behind the files and folders
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 100, y + 42, width - 103, height - 100);
                    //34, 78
                    //Making the quick-access bars white base
                    //Try an only once reading process like in the scrollbar
                    vbe.DrawFilledRectangle(new Pen(Color.White), x + 3, y + 21, 85, height - 23);
                    //Rendering the files in wertrical
                    if (enabeled == true)
                    {
                        foreach (DirectoryEntry d in k.getDirFolders(currentdir))
                        {
                            k.FirstFolder(vbe, (uint)x1, (uint)y1);
                            Folders.Add(new Tuple<int, int, int, int, String>(x1, y1, x1 + (d.mName.Length * 8), (int)y1 + 20, d.mFullPath));
                            //y1 += 35;
                            int o = d.mName.Length;
                            if (o > 8)
                            {
                                string ia = d.mName;
                                string ib = "";
                                ib = ia.Remove(8);
                                string ic = "";
                                ic = ib + "...";
                                ASC16.DrawACSIIString(vbe, ic, Color.Black, (uint)x1 + 45, (uint)y1 + 8);
                                //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                y1 += 35;
                            }
                            else
                            {
                                ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)x1 + 45, (uint)y1 + 8);
                                //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                y1 += 35;
                            }
                            if (y1 > y + 200)
                            {
                                y1 = y + 36;
                                x1 += 100;
                            }
                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, x1 + (d.mName.Length * 8) + 25, (int)y1 + 35, d.mFullPath));
                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, (x1 + 60) + d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                        }
                        /*
                        foreach (DirectoryEntry d in k.getDirFiles(currentdir))
                        {
                        if (d.mFullPath.EndsWith(".txt") || d.mFullPath.EndsWith(".TXT"))
                        {
                            //Textfile.drawtxticon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                            Textfile.drawtxticon(vbe, (uint)x1 + (uint)9, (uint)y1);
                        }
                        else if (d.mFullPath.EndsWith(".run") || d.mFullPath.EndsWith(".RUN"))
                        {
                            //Calcicon.normalcalc(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 24), (uint)y);
                            Calcicon.normalcalc(vbe, (uint)x1, (uint)y1 + 9);
                        }
                        else
                        {
                            //FirstIcon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                            k.FirstIcon(vbe, (uint)x1 + (uint)9, (uint)y1);
                        }
                        int o = d.mName.Length;
                        if (o > 8)
                        {
                            string ia = d.mName;
                            string ib = "";
                            ib = ia.Remove(8);
                            string ic = "";
                            ic = ib + "...";
                            ASC16.DrawACSIIString(vbe, ic, (uint)Color.Black.ToArgb(), (uint)x1 + 45, (uint)y1 + 8);
                            //Files.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 50, d.mFullPath));
                            y1 += 50;
                        }
                        else
                        {
                            ASC16.DrawACSIIString(vbe, d.mName, (uint)Color.Black.ToArgb(), (uint)x1 + 45, (uint)y1 + 8);
                            //Files.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 50, d.mFullPath));
                            y1 += 50;
                        }
                        if (y1 > y + 200)
                        {
                            y1 = y + 36;
                            x1 = x + 233;
                        }
                        Files.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, (x1 + 50) + d.mName.Length * 8, (int)y1 + 50, d.mFullPath));
                        }
                        */
                        //enabeled = false;
                    }
                    /*
                    if(Folders.Count != 0)
                    {
                        foreach (Tuple<int, int, int, int, String> s in Folders)
                        {
                            vbe.DrawRectangle((uint)Color.Black.ToArgb(), s.Item1, s.Item2, s.Item3, s.Item4);
                        }
                    }
                    */
                    foreach (Tuple<int, int, int, int, String> t in Folders)
                    {
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > t.Item1 && MouseManager.X < t.Item3)
                            {
                                if (MouseManager.Y > t.Item2 && MouseManager.Y < t.Item4 + 15)
                                {
                                    currentdir = t.Item5;
                                    x1 = 0;
                                    y1 = 0;
                                    Folders.Clear();
                                    foreach (DirectoryEntry d in k.getDirFolders(t.Item5))
                                    {
                                        k.FirstFolder(vbe, (uint)x1, (uint)y1);
                                        Folders.Add(new Tuple<int, int, int, int, String>(x1, y1, x1 + (d.mName.Length * 8), (int)y1 + 20, d.mFullPath));
                                        y1 += 35;
                                        int o = d.mName.Length;
                                        if (o > 8)
                                        {
                                            string ia = d.mName;
                                            string ib = "";
                                            ib = ia.Remove(8);
                                            string ic = "";
                                            ic = ib + "...";
                                            ASC16.DrawACSIIString(vbe, ic, Color.Black, (uint)x1 + 45, (uint)y1 + 8);
                                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                            y1 += 35;
                                        }
                                        else
                                        {
                                            ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)x1 + 45, (uint)y1 + 8);
                                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                            y1 += 35;
                                        }
                                        if (y1 > y + 200)
                                        {
                                            y1 = y + 36;
                                            x1 += 100;
                                        }
                                        //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, x1 + (d.mName.Length * 8) + 25, (int)y1 + 35, d.mFullPath));
                                        //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, (x1 + 60) + d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                    }
                                    /*
                                    // = "";

                                    //enabeled = true;
                                    x1 = 0;
                                    y1 = 0;
                                    //Files.Clear();
                                    Folders.RemoveRange(0, Folders.Count);
                                    currentdir = t.Item5;
                                    */
                                }
                            }
                        }
                    }
                    //ASC16.DrawACSIIString(vbe, currentdir, (uint)Color.Black.ToArgb(), 450, 350);
                    uint X = MouseManager.X;
                    uint Y = MouseManager.Y;
                    #region actionbuttons
                    Window w = new Window();
                    w.button(vbe, x + 95, y + 21, 22, 18, "Up");
                    w.button(vbe, x + 122, y + 21, 36, 18, "Back");
                    w.button(vbe, (x + width) - 55, (y + height) - 50, 50, 20, "Save");
                    w.button(vbe, (x + width) - 55, (y + height) - 27, 50, 20, "Cancel");
                    #endregion actionbuttons
                    KeyEvent keyEvent;
                    if (KeyboardManager.TryReadKey(out keyEvent))
                    {
                        switch (keyEvent.Key)
                        {
                            case ConsoleKeyEx.Enter:
                                break;

                            case ConsoleKeyEx.Backspace:
                                if (textboxcontent.Length != 0)
                                {
                                    textboxcontent = textboxcontent.Remove(textboxcontent.Length - 1);
                                }
                                break;

                            default:
                                textboxcontent += keyEvent.KeyChar;
                                break;
                        }
                    }
                    options.Add("File");
                    options.Add("Folder");
                    optionchooser(vbe, x + 145, (y + height) - 27, width - 205, 20, options);
                    ASC16.DrawACSIIString(vbe, choosed, Color.Black, (uint)x + 148, (uint)(y + height) - 24);
                    options.Clear();
                    #region textbox
                    TextBox tb = new TextBox();
                    tb.textbox(vbe, x + 145, (y + height) - 50, width - 205, 20, textboxcontent);
                    tb.textbox(vbe, x + 163, y + 21, width - 203, 18, currentdir);
                    #endregion textbox
                    #region activate buttons
                    if (Mouse.Click())
                    {
                        if (MouseManager.X > (x + width) - 26 && MouseManager.X < (x + width) - 6 && MouseManager.Y > y + 5 && MouseManager.Y < y + 17)
                        {
                            Booleans.dialogbox_opened = false;
                        }
                        if (MouseManager.X > (x + width) - 51 && MouseManager.X < (x + width) - 31 && MouseManager.Y > y + 5 && MouseManager.Y < y + 17)
                        {
                            Booleans.dialogbox_minimised = true;
                        }
                        foreach(Tuple<string, int, int, int, int> z in Kernel.applist)
                        {
                            if (z.Item1 == "Create file/...")
                            {
                                if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                                {
                                    if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                    {
                                        Booleans.dialogbox_minimised = false;
                                    }
                                }
                            }
                        }
                        if (MouseManager.X > x + 95 && MouseManager.X < x + 117)
                        {
                            if (MouseManager.Y > y + 21 && MouseManager.Y < y + 39)
                            {
                                if (currentdir != "0:\\")
                                {
                                    cleanupstring(currentdir, "\\");
                                }
                            }
                        }
                        /*
                        if (MouseManager.X > (x + width) - 45 && MouseManager.X < (x + width) - 5)
                        {
                            if (MouseManager.Y > (y + height) - 50 && MouseManager.Y < (y + height) - 30)
                            {
                                if((currentdir + "\\" + textboxcontent).Contains("."))
                                {
                                    if (!File.Exists(currentdir + "\\" + textboxcontent))
                                    {
                                        File.Create(currentdir + "\\" + textboxcontent);
                                    }
                                }
                                else
                                {
                                    if (!Directory.Exists(currentdir + "\\" + textboxcontent))
                                    {
                                        Directory.CreateDirectory(currentdir + "\\" + textboxcontent);
                                    }
                                }
                            }
                        }
                        */
                        if (MouseManager.X > (x + width) - 45 && MouseManager.X < (x + width) - 5)
                        {
                            if (MouseManager.Y > (y + height) - 50 && MouseManager.Y < (y + height) - 30)
                            {
                                if (choosed == "File")
                                {
                                    if (!File.Exists(currentdir + "\\" + textboxcontent))
                                    {
                                        File.Create(currentdir + "\\" + textboxcontent);
                                    }
                                    else
                                    {
                                        ErrorFeedbackHandler error = new ErrorFeedbackHandler();
                                        error.EFH(vbe, 150, 500, "The file you want to create is already exists!");
                                    }
                                }
                                if (choosed == "Folder")
                                {
                                    if (!Directory.Exists(currentdir + "\\" + textboxcontent))
                                    {
                                        Directory.CreateDirectory(currentdir + "\\" + textboxcontent);
                                    }
                                    else
                                    {
                                        ErrorFeedbackHandler error = new ErrorFeedbackHandler();
                                        error.EFH(vbe, 150, 500, "The folder you want to create is already exists!");
                                    }
                                }
                            }
                        }
                    }
                    #endregion activate buttons
                    ASC16.DrawACSIIString(vbe, "Name:", Color.Black, (uint)x + 100, (uint)(y + height) - 47);
                    #endregion
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
                    if(moove_enabled == true)
                    {
                        Int_Manager.dialogbox_x = (int)MouseManager.X;
                        Int_Manager.dialogbox_y = (int)MouseManager.Y;
                        if (Mouse.RightClick())
                        {
                            moove_enabled = false;
                        }
                    }
                }
                if (Booleans.dialogbox_minimised == true)
                {
                    if (Mouse.Click())
                    {
                        foreach (Tuple<string, int, int, int, int> z in Kernel.applist)
                        {
                            if (z.Item1 == "Create file/...")
                            {
                                if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                                {
                                    if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                    {
                                        Booleans.dialogbox_minimised = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(Booleans.dialogbox_opened == false)
            {
                if (TaskManager.apps.Contains("Create file/..."))
                {
                    TaskManager.apps.Remove("Create file/...");
                }
                else
                {
                    //TaskManager.apps.Add("Create file/...");
                }
            }
        }
        public void cleanupstring(string input, string separator)
        {
            List<string> d = new List<string>();
            string[] splited = input.Split(separator);
            foreach(string s in splited)
            {
                d.Add(s);
            }
            d.RemoveRange(d.Count - 1, 1);
            currentdir = "";
            foreach(string h in d)
            {
                if(listcounter == d.Count - 1)
                {
                    currentdir += h + "\\";
                }
                else
                {
                    currentdir += h + "\\";
                    listcounter += 1;
                }
            }
        }
        //List<string> elements
        public void optionchooser(VBECanvas vbe, int x, int y, int width, int height, List<string> elements)
        {
            vbe.DrawFilledRectangle(new Pen(Color.White), x, y, width, height);
            vbe.DrawRectangle(new Pen(Color.Black), x, y, width, height);
            int why = (height / 2) - 6;
            //downarrow
            vbe.DrawLine(new Pen(Color.Black), x + width - 8, y + 2, x + width - 8, (y + height) - 4);
            vbe.DrawLine(new Pen(Color.Black), x + width - 8, (y + height) - 4, x + width - 4, (y + height) - 8);
            vbe.DrawLine(new Pen(Color.Black), x + width - 8, (y + height) - 4, x + width - 12, (y + height) - 8);
            vbe.DrawRectangle(new Pen(Color.Black), x + width - 15, y, 15, height);
            //Activating arrow button
            bool activator = false;
            if (Mouse.Click())
            {
                if(MouseManager.X > x + width - 15 && MouseManager.X < x + width && MouseManager.Y > y && MouseManager.Y < y + height)
                {
                    if (opened == true)
                    {
                        opened = false;
                    }
                    else
                    {
                        opened = true;
                    }
                }
            }
            if(opened == true)
            {
                vbe.DrawFilledRectangle(new Pen(Color.White), x, (y + height), width, 50);
                vbe.DrawRectangle(new Pen(Color.Black), x, y + height, width, 50);
                int x2 = x + 3;
                int y2 = y + height + 3;
                foreach (string t in elements)
                {
                    ASC16.DrawACSIIString(vbe, t, Color.Black, (uint)x2, (uint)y2);
                    y2 += 15;
                }
                if (Mouse.Click())
                {
                    if(MouseManager.X > x && MouseManager.X < x + width && MouseManager.Y > y + height && MouseManager.Y < y + height + 15)
                    {
                        choosed = "File";
                        opened = false;
                    }
                    if (MouseManager.X > x && MouseManager.X < x + width && MouseManager.Y > y + height + 15 && MouseManager.Y < y + height + 25)
                    {
                        choosed = "Folder";
                        opened = false;
                    }
                }
            }
            if(opened != true)
            {

            }
        }
    }
}