using Cosmos.System;
using Cosmos.System.FileSystem.Listing;
using CosmosKernel1;
using CosmosKernel8.Drivers;
using CosmosDrawString;
using resolution.iconmanager;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Kernel = CrystalOS.Kernel;
using Cosmos.System.Graphics;

namespace resolution.Applications
{
    class FolderExplorer
    {
        public int x2 = Int_Manager.explorer_x + 15;
        public int y2 = Int_Manager.explorer_y + 80;
        Kernel k = new Kernel();
        string file;
        string fileExpCtxTarget;
        string hope;
        uint fileExpCtxX;
        uint fileExpCtxY;
        public static string parentdir = @"0:\";
        //public static string parentdir2 = "";
        public static List<Tuple<int, int, int, int, string>> fileExpDirs = new List<Tuple<int, int, int, int, string>>();
        public static List<Tuple<int, int, int, int, string>> fileExpFiles = new List<Tuple<int, int, int, int, string>>();
        /*
        public void Desktopfiles2(VBECanvas vbe, int x, int y)
        {
            foreach (DirectoryEntry d in k.getDirFiles(@"0:\"))
            {
                iconmanager.SystemFile.drawsysicon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 20), (uint)y);
                ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)x, (uint)y + 30);
                fileExpFiles.Add(new Tuple<int, int, int, int, String>(x, (int)y, d.mName.Length * 8, (int)y + 63, d.mFullPath));
                y += 50;

            }
            foreach (DirectoryEntry d in k.getDirFolders(@"0:\"))
            {
                k.FirstFolder(vbe, (uint)x + 130 + (uint)(((d.mName.Length * 8) / 2) - 10), (uint)y);
                ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)x + 130, (uint)y + 30);
                //y3 += 20;
                fileExpDirs.Add(new Tuple<int, int, int, int, String>(130, (int)y, 200, (int)y + 20, d.mFullPath));
            }
            //here was it.

            DirectoryEntryTypeEnum fileExpCtxType = DirectoryEntryTypeEnum.File;
        }
        */
        bool change = true;
        public static bool moove_enabled = false;
        /*
        public void File_Explorer(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise)
        {
            if (Kernel.minimise1 == false)
            {
                if (Kernel.opened1 == true)
                {
                    if (Kernel.fullscreen == false)
                    {
                        TaskManager tmg = new TaskManager();
                        if (TaskManager.apps.Contains("File-E..."))
                        {

                        }
                        else
                        {
                            TaskManager.apps.Add("File-E...");
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
                            ///
                        }
                        if (moove_enabled == true)
                        {
                            Kernel.explorerx = (int)MouseManager.X;
                            Kernel.explorery = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                        ASC16.DrawACSIIString(vbe, "File-Explorer", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                        //
                        vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 27, (uint)width - 10, 30, (uint)Color.LightGray.ToArgb());//62 magas
                        ASC16.DrawACSIIString(vbe, "File", (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 33);
                        vbe.DrawFilledRectangle((uint)x + 45, (uint)y + 32, (uint)width - 60, 20, (uint)Color.White.ToArgb());
                        ASC16.DrawACSIIString(vbe, parentdir, (uint)Color.Black.ToArgb(), (uint)x + 48, (uint)y + 33);
                       
                        vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 70, (uint)width - 10, (uint)height - 100, (uint)Color.White.ToArgb());
                        //Kernel k = new Kernel();
                        //Desktopfiles2(vbe, x + 15, y + 55);
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        //Task bar starts here
                        vbe.DrawFilledRectangle((uint)x + 3, (uint)(y + height) - 25, (uint)width - 6, 20, (uint)Color.LightGray.ToArgb());
                        vbe.DrawRectangle((uint)Color.White.ToArgb(), x + 3, (y + height) - 25, width - 6, 20);
                        DriveInfo driveInfo = new DriveInfo("0:\\");
                        int driverspace = (int)driveInfo.TotalSize / 1048576;
                        int usedspace = (int)driverspace - (int)(driveInfo.TotalFreeSpace / 1048576);
                        int freespace = (int)driveInfo.AvailableFreeSpace / 1048576;
                        ASC16.DrawACSIIString(vbe, @"C:\ " + driverspace + "  Total size(MB)      " + usedspace + "  Used space(MB)      " + freespace + "  Free space(MB)", (uint)Color.Black.ToArgb(), (uint)x + 11, (uint)(y + height) - 23);
                        //Task bar ends here
                        //string hope = "";
                        //ASC16.DrawACSIIString(vbe, k.file, (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 28);
                        uint X = MouseManager.X;
                        uint Y = MouseManager.Y;
                        DirectoryEntryTypeEnum fileExpCtxType = DirectoryEntryTypeEnum.File;
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Kernel.opened1 = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.fullscreen1 = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Kernel.minimise1 = true;
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
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 45, 120, 140, (uint)Color.LightGray.ToArgb());
                            ASC16.DrawACSIIString(vbe, "Create ->", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 48);
                            vbe.DoubleBuffer_DrawLine((uint)Color.LightGray.ToArgb(), x + 8, y + 53, x + 115, y + 53);
                            //ASC16.DrawACSIIString(vbe, "Open...", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 68);
                            ASC16.DrawACSIIString(vbe, "New file", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 88);
                        }
                        if (Kernel.filepage == false)
                        {

                        }
                        if (Kernel.fullscreen1 == true)
                        {
                            x = 0;
                            y = 0;
                            width = 1280;
                            height = 738;
                            vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                            ASC16.DrawACSIIString(vbe, "File-Explorer", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                            vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            //
                            vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 27, (uint)width - 10, 30, (uint)Color.LightGray.ToArgb());//62 magas
                            ASC16.DrawACSIIString(vbe, "File", (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 33);
                            vbe.DrawFilledRectangle((uint)x + 45, (uint)y + 32, (uint)width - 60, 20, (uint)Color.White.ToArgb());
                            ASC16.DrawACSIIString(vbe, parentdir, (uint)Color.Black.ToArgb(), (uint)x + 48, (uint)y + 33);

                            vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 70, (uint)width - 10, (uint)height - 75, (uint)Color.White.ToArgb());
                            //Kernel k = new Kernel();
                            //Desktopfiles2(vbe, x + 15, y + 55);
                            //System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);


                            //string hope = "";
                            //ASC16.DrawACSIIString(vbe, k.file, (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 28);
                            //uint X = MouseManager.X;
                            //uint Y = MouseManager.Y;
                            //DirectoryEntryTypeEnum fileExpCtxType = DirectoryEntryTypeEnum.File;
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
                            }
                            if (Kernel.filepage == false)
                            {

                            }
                            System.Drawing.Point CurMouse0 = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                                {
                                    if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                    {
                                        Kernel.opened1 = false;
                                    }
                                }
                            }
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                                {
                                    Kernel.fullscreen1 = false;
                                }
                            }
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                                {
                                    Kernel.minimise1 = true;
                                }
                            }
                        }
                        if (Kernel.opened == false)
                        {

                        }
                    }
                }
                if (Kernel.opened1 == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("File-E..."))
                    {
                        TaskManager.apps.Remove("File-E...");
                    }
                    else
                    {

                    }
                }
            }
            if (Kernel.minimise1 == true)
            {

            }
        }
        */

        public void File_Explorer2(VBECanvas vbe, int x, int y, int width, int height, bool opened, bool fullscreen, bool minimise)
        {
            if (minimise == false)
            {
                if (opened == true)
                {
                    if (fullscreen == false)
                    {
                        TaskManager tmg = new TaskManager();
                        if (TaskManager.apps.Contains("File-E..."))
                        {

                        }
                        else
                        {
                            TaskManager.apps.Add("File-E...");
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
                            Int_Manager.explorer_x = (int)MouseManager.X;
                            Int_Manager.explorer_y = (int)MouseManager.Y;
                            if (Mouse.RightClick())
                            {
                                moove_enabled = false;
                            }
                        }
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
                        vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
                        vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
                        ASC16.DrawACSIIString(vbe, "File-Explorer", Color.White, (uint)x + 5, (uint)y + 3);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
                        vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
                        //
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 5, y + 27, width - 10, 30);//62 magas
                        ASC16.DrawACSIIString(vbe, "File", Color.Black, (uint)x + 8, (uint)y + 33);
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 45, y + 32, width - 88, 20);//38//-60
                        Window w = new Window();
                        w.button(vbe, (x + width) - 35, y + 32, 22, 18, "Up");
                        ASC16.DrawACSIIString(vbe, parentdir, Color.Black, (uint)x + 48, (uint)y + 33);
                        vbe.DrawFilledRectangle(new Pen(Color.White), x + 5, y + 70, width - 10, height - 100);
                        //Kernel k = new Kernel();
                        //Desktopfiles2(vbe, x + 15, y + 55);
                        foreach (Tuple<int, int, int, int, string> t in fileExpDirs)
                        {
                            if (Mouse.Click())
                            {
                                if (MouseManager.X > t.Item1 && MouseManager.X < t.Item3)
                                {
                                    if (MouseManager.Y > t.Item2 && MouseManager.Y < t.Item4)
                                    {
                                        parentdir = t.Item5;
                                        fileExpDirs.Clear();
                                        /*
                                        foreach (DirectoryEntry d in k.getDirFolders(t.Item5))
                                        {
                                            k.FirstFolder(vbe, (uint)x2, (uint)y2);
                                            fileExpDirs.Add(new Tuple<int, int, int, int, string>(x2, y2, x2 + (d.mName.Length * 8), (int)y2 + 20, d.mFullPath));
                                            y2 += 35;
                                            int o = d.mName.Length;
                                            if (o > 8)
                                            {
                                                string ia = d.mName;
                                                string ib = "";
                                                ib = ia.Remove(8);
                                                string ic = "";
                                                ic = ib + "...";
                                                ASC16.DrawACSIIString(vbe, ic, (uint)Color.Black.ToArgb(), (uint)x2 + 45, (uint)y2 + 8);
                                                //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                                y2 += 35;
                                            }
                                            else
                                            {
                                                ASC16.DrawACSIIString(vbe, d.mName, (uint)Color.Black.ToArgb(), (uint)x2 + 45, (uint)y2 + 8);
                                                //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                                y2 += 35;
                                            }
                                            if (y2 > y + 200)
                                            {
                                                y2 = y + 36;
                                                x2 += 100;
                                            }
                                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, x1 + (d.mName.Length * 8) + 25, (int)y1 + 35, d.mFullPath));
                                            //Folders.Add(new Tuple<int, int, int, int, String>(x1, (int)y1, (x1 + 60) + d.mName.Length * 8, (int)y1 + 35, d.mFullPath));
                                        }
                                        */
                                    }
                                }
                            }
                        }
                        #region

                        /*
                        if (Mouse.Click())
                        {
                            foreach (Tuple<int, int, int, int, string> t in fileExpDirs)
                            {
                                if ((MouseManager.X > t.Item1 && MouseManager.X < t.Item3 && (MouseManager.Y > t.Item2 && MouseManager.Y < t.Item4)))
                                {
                                    parentdir2 = t.Item5;
                                    //FolderExplorer.parentdir = t.Item5;
                                    //opened1 = true;
                                    //Booleans.explorer_opened = true;
                                    //FolderExplorer f = new FolderExplorer();
                                    //f.File_Explorer(vbe, explorerx, explorery, explorerwidth, explorerheight, true, false, false);
                                    return;
                                }
                            }
                            #region
                            /*
                            foreach (Tuple<int, int, int, int, String> t in fileExpFiles)
                            {
                                if ((X > t.Item1 && X < t.Item3 && (Y > t.Item2 - 20 && Y < t.Item4 - 20)))
                                {
                                    fileExpCtxTarget = string.Empty;
                                    file = string.Empty;
                                    fileExpCtxType = DirectoryEntryTypeEnum.File;
                                    fileExpCtxTarget += t.Item5;
                                    fileExpCtxX = X;
                                    fileExpCtxY = Y;
                                    //opened = true;
                                    //file += File.ReadAllText(fileExpCtxTarget);
                                    hope = t.Item5;
                                    if (hope.EndsWith(".sct"))
                                    {
                                        string ok = "";
                                        ok = File.ReadAllText(hope);
                                        if (ok.EndsWith(".txt"))
                                        {
                                            opened = true;
                                            file += File.ReadAllText(ok);
                                        }
                                        else
                                        {

                                        }
                                    }
                                    if (hope.EndsWith(".txt"))
                                    {
                                        opened = true;
                                        //file += File.ReadAllText(hope);
                                        file += hope;
                                    }
                                    if (hope.EndsWith(".TXT"))
                                    {
                                        opened = true;
                                        //file += File.ReadAllText(hope);
                                        file += hope;
                                    }
                                    if (hope.EndsWith(".sdf"))
                                    {
                                        opened = true;
                                        file += File.ReadAllText(hope);
                                        /*
                                        if (y > 400)
                                        {
                                            y = 205;
                                            x += 125;
                                        }
                                    }
                                    if (hope.EndsWith(".RUN") || hope.EndsWith(".run"))
                                    {
                                        Kernel.comeon = true;
                                        //string ok = "";
                                        //ok = File.ReadAllText(hope);
                                        //
                                        string[] lines = File.ReadAllLines(hope);
                                        foreach (string ok in lines)
                                        {
                                            //
                                            if (ok.StartsWith("x = "))
                                            {
                                                x1 = int.Parse(ok.Remove(0, 4));
                                            }
                                            if (ok.StartsWith("y = "))
                                            {
                                                y1 = int.Parse(ok.Remove(0, 4));
                                            }
                                            if (ok.StartsWith("width = "))
                                            {
                                                width1 = int.Parse(ok.Remove(0, 8));
                                            }
                                            if (ok.StartsWith("height = "))
                                            {
                                                height1 = int.Parse(ok.Remove(0, 9));
                                            }
                                            if (ok.StartsWith("title = "))
                                            {
                                                title = ok.Remove(0, 8);
                                            }
                                            //
                                            if (ok.StartsWith("buttonx = "))
                                            {
                                                buttonx = int.Parse(ok.Remove(0, 10));
                                            }
                                            if (ok.StartsWith("buttony = "))
                                            {
                                                buttony = int.Parse(ok.Remove(0, 10));
                                            }
                                            if (ok.StartsWith("buttonwidth = "))
                                            {
                                                buttonwidth = int.Parse(ok.Remove(0, 14));
                                            }
                                            if (ok.StartsWith("buttonheight = "))
                                            {
                                                buttonheight = int.Parse(ok.Remove(0, 15));
                                            }
                                            if (ok.StartsWith("buttontitle = "))
                                            {
                                                buttontitle = ok.Remove(0, 14);
                                            }
                                            if (ok.StartsWith("msgtext = "))
                                            {
                                                msgtext = ok.Remove(0, 10);
                                            }
                                            if (ok.StartsWith("stringx = "))
                                            {
                                                stringx = int.Parse(ok.Remove(0, 10));
                                            }
                                            if (ok.StartsWith("stringy = "))
                                            {
                                                stringy = int.Parse(ok.Remove(0, 10));
                                            }
                                            if (ok.StartsWith("stringcontent = "))
                                            {
                                                stringcontent = ok.Remove(0, 16);
                                            }
                                            /*
                                            if(ok.StartsWith("buttonfunction = "))
                                            {
                                                string thebest = ok.Remove(0, 17);
                                                if (thebest == "msgbox")
                                                {
                                                    Window window = new Window();

                                                }
                                            }
                                            if (ok.StartsWith("buttonfunction(") && ok.EndsWith(")"))
                                            {
                                                string thebest = ok.Remove(0, 15);
                                                string buttonfunc = thebest.Remove(thebest.Length - 1);
                                                if (buttonfunc.StartsWith("msgbox,\"") && buttonfunc.EndsWith("\""))
                                                {
                                                    string message0 = buttonfunc.Remove(0, 8);
                                                    string message = message0.Remove(buttonfunc.Length - 1);
                                                    Window window = new Window();

                                                    window.msgbox(vbe, 700, 400, 200, 100, message, "warning!", msgbox);
                                                }
                                            }
                                            /*
                                            int x = 0;
                                            int y = 0;
                                            int width = 0;
                                            int height = 0;
                                            if (ok.StartsWith("newbutton\n{\n"))
                                            {
                                                if(ok.StartsWith("x = "))
                                                {
                                                    string a = ok.Remove(0, 16);
                                                    x = int.Parse(a.Remove(2, a.Length - 2));
                                                }
                                                if (ok.StartsWith("y = "))
                                                {
                                                    string a = ok.Remove(0, 23);
                                                    y = int.Parse(a.Remove(2, a.Length - 2));
                                                }
                                                if (ok.StartsWith("width = "))
                                                {
                                                    string a = ok.Remove(0, 34);
                                                    width = int.Parse(a.Remove(2, a.Length - 2));
                                                }
                                                if (ok.StartsWith("height = "))
                                                {
                                                    string a = ok.Remove(0, 45);
                                                    height = int.Parse(a.Remove(2, a.Length - 2));
                                                }
                                                vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.Blue.ToArgb());
                                            }
                                            if (ok.StartsWith("//"))
                                            {
                                                //Cosmos.HAL.PCSpeaker.Beep((uint)Notes.D5, 10);
                                            }
                                            //window.graphical_executable(vbe, ok);
                                            /*
                                            if (ok.StartsWith("x = "))
                                            {
                                                x1 = int.Parse(ok.Remove(0, 4));
                                            }
                                            if (ok.StartsWith("y = "))
                                            {
                                                y1 = int.Parse(ok.Remove(0, 4));
                                            }
                                            if (ok.StartsWith("width = "))
                                            {
                                                width1 = int.Parse(ok.Remove(0, 8));
                                            }
                                            if (ok.StartsWith("height = "))
                                            {
                                                height1 = int.Parse(ok.Remove(0, 9));
                                            }
                                            if (ok.StartsWith("title = "))
                                            {
                                                title = ok.Remove(0, 8);
                                            }
                                            Window a = new Window();
                                            openwindow = true;
                                            a.window(vbe, x1, y1, width1, height1, title, openwindow);
                                        }
                                    }
                                    if (hope.EndsWith(".NEX") || hope.EndsWith(".nex"))
                                    {
                                        Lexer l = new Lexer();
                                        l.analyser(vbe);
                                    }
                                    return;
                                }
                            }
                            */
                        #endregion
                        #region back
                        if (Mouse.Click())
                        {
                            if (MouseManager.X > (x + width) - 35 && MouseManager.X < (x + width) - 13)
                            {
                                if (MouseManager.Y > y + 32 && MouseManager.Y < y + 50)
                                {
                                    if (parentdir != "0:\\")
                                    {
                                        dialogbox db = new dialogbox();
                                        cleanupstring(parentdir, "\\");
                                    }
                                }
                            }
                        }
                        #endregion back
                        foreach (DirectoryEntry d in k.getDirFolders(parentdir))
                        {
                            //FirstFolder(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 10), (uint)y);
                            k.FirstFolder(vbe, (uint)x2 + 2, (uint)y2);
                            //ASC16.DrawACSIIString(vbe, d.mName, (uint)Color.Black.ToArgb(), (uint)x, (uint)y + 30);
                            //int i = 0;
                            int o = d.mName.Length;
                            if (o > 6 || o == 6)
                            {
                                string ia = d.mName.Remove(4);
                                string ib = "";
                                //ib = ia.Insert(6, "\n");
                                ib = ia + "...";
                                //int length = (ib.Length * 8) / 2;
                                //int length2 = length / 4;
                                //int length = x2 + 12;
                                //int length2 = (ib.Length * 8) / 2;
                                //int length3 = length - length2;
                                int length = (ib.Length * 8) / 2;
                                int length2 = length / 2;
                                ASC16.DrawACSIIString(vbe, ib, Color.Black, (uint)(x2 + 12 - length2), (uint)y2 + 30);//length3 + 10
                                fileExpDirs.Add(new Tuple<int, int, int, int, string>(x2, y2, x2 + (d.mName.Length * 8), (int)y2 + 60, d.mFullPath));
                                
                            }
                            else
                            {
                                int length = (o * 8) / 2;
                                int length2 = length / 2;
                                ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)(x2 + length2), (uint)y2 + 30);
                                fileExpDirs.Add(new Tuple<int, int, int, int, string>(x2, y2, x2 + (d.mName.Length * 8), (int)y2 + 50, d.mFullPath));
                            }
                            //x2 += 50;
                            y2 += 50;
                            //ASC16.DrawACSIIString(vbe, d.mName, (uint)Color.Black.ToArgb(), (uint)x, (uint)y + 30);
                            //fileExpDirs.Add(new Tuple<int, int, int, int, String>(x, (int)y, d.mName.Length * 8, (int)y + 63, d.mFullPath));
                            //y += 50;
                        }
                        foreach (DirectoryEntry d in k.getDirFiles(parentdir))
                        {
                            //y2 += 50;
                            if(y2 > y + height - 125)
                            {
                                if (d.mFullPath.EndsWith(".txt") || d.mFullPath.EndsWith(".TXT"))
                            {
                                //Textfile.drawtxticon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                                Textfile.drawtxticon(vbe, (uint)x2 + (uint)9, (uint)y2);
                            }
                                else if (d.mFullPath.EndsWith(".run") || d.mFullPath.EndsWith(".RUN"))
                            {
                                //Calcicon.normalcalc(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 24), (uint)y);
                                Calcicon.normalcalc(vbe, (uint)x2 + (uint)9, (uint)y2);
                            }
                                else
                            {
                                //FirstIcon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                                k.FirstIcon(vbe, (uint)x2 + (uint)9, (uint)y2);
                            }
                                int o = d.mName.Length;
                                if (o > 6 || o == 6)
                                {
                                    string ia = d.mName.Remove(4);
                                    string ib = "";
                                    //ib = ia.Insert(6, "\n");
                                    ib = ia + "...";
                                    int length = (ib.Length * 8) / 2;
                                    int length2 = length / 2;
                                    ASC16.DrawACSIIString(vbe, ib, Color.Black, (uint)(x2 + 13 - length2), (uint)y2 + 30);
                                    fileExpFiles.Add(new Tuple<int, int, int, int, String>(x2, (int)y2, d.mName.Length * 8, (int)y2 + 60, d.mFullPath));
                                    //y2 += 60;
                                }
                                else
                                {
                                    int length = (o * 8) / 2;
                                    int length2 = length / 2;
                                    ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)(x2 + 13 - length2), (uint)y2 + 30);
                                    fileExpFiles.Add(new Tuple<int, int, int, int, String>(x2, (int)y2, d.mName.Length * 8, (int)y2 + 50, d.mFullPath));
                                    //y2 += 50;
                                }
                                x2 += 80;
                                y2 = y + 80;
                            }
                            else
                            {
                                if (d.mFullPath.EndsWith(".txt") || d.mFullPath.EndsWith(".TXT"))
                                {
                                    //Textfile.drawtxticon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                                    Textfile.drawtxticon(vbe, (uint)x2 + (uint)9, (uint)y2);
                                }
                                else if (d.mFullPath.EndsWith(".run") || d.mFullPath.EndsWith(".RUN"))
                                {
                                    //Calcicon.normalcalc(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 24), (uint)y);
                                    Calcicon.normalcalc(vbe, (uint)x2 + (uint)9, (uint)y2);
                                }
                                else
                                {
                                    //FirstIcon(vbe, (uint)x + (uint)(((d.mName.Length * 8) / 2) - 26), (uint)y);
                                    k.FirstIcon(vbe, (uint)x2 + (uint)9, (uint)y2);
                                }
                                int o = d.mName.Length;
                                if (o > 6 || o == 6)
                                {
                                    string ia = d.mName.Remove(4);
                                    string ib = "";
                                    //ib = ia.Insert(6, "\n");
                                    ib = ia + "...";
                                    int length = (ib.Length * 8) / 2;
                                    int length2 = length / 2;
                                    ASC16.DrawACSIIString(vbe, ib, Color.Black, (uint)(x2 + 13 - length2), (uint)y2 + 30);
                                    //ASC16.DrawACSIIString(vbe, ib, (uint)Color.Black.ToArgb(), (uint)x2, (uint)y2 + 30);
                                    fileExpFiles.Add(new Tuple<int, int, int, int, String>(x2, (int)y2, d.mName.Length * 8, (int)y2 + 60, d.mFullPath));
                                    //y2 += 60;
                                    y2 += 50;
                                }
                                else
                                {
                                    ASC16.DrawACSIIString(vbe, d.mName, Color.Black, (uint)x2, (uint)y2 + 30);
                                    fileExpFiles.Add(new Tuple<int, int, int, int, String>(x2, (int)y2, d.mName.Length * 8, (int)y2 + 50, d.mFullPath));
                                    y2 += 50;
                                }
                            }
                        }
                        System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                        //Task bar starts here
                        vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 3, (y + height) - 25, width - 6, 20);
                        vbe.DrawRectangle(new Pen(Color.White), x + 3, (y + height) - 25, width - 6, 20);
                        DriveInfo driveInfo = new DriveInfo("0:\\");
                        int driverspace = (int)driveInfo.TotalSize / 1048576;
                        int usedspace = (int)driverspace - (int)(driveInfo.TotalFreeSpace / 1048576);
                        int freespace = (int)driveInfo.AvailableFreeSpace / 1048576;
                        ASC16.DrawACSIIString(vbe, @"C:\ " + driverspace + "  Total size(MB)      " + usedspace + "  Used space(MB)      " + freespace + "  Free space(MB)", Color.Black, (uint)x + 11, (uint)(y + height) - 23);
                        //Task bar ends here
                        //string hope = "";
                        //ASC16.DrawACSIIString(vbe, k.file, (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 28);
                        uint X = MouseManager.X;
                        uint Y = MouseManager.Y;
                        DirectoryEntryTypeEnum fileExpCtxType = DirectoryEntryTypeEnum.File;
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                            {
                                if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                {
                                    Booleans.explorer_opened = false;
                                }
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.explorer_maximised = true;
                            }
                        }
                        if (Mouse.Click())
                        {
                            if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                            {
                                Booleans.explorer_minimised = true;
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
                            vbe.DrawFilledRectangle(new Pen(Color.LightGray), x + 3, y + 45, 120, 140);
                            ASC16.DrawACSIIString(vbe, "Create ->", Color.Black, (uint)x + 5, (uint)y + 48);
                            vbe.DrawLine(new Pen(Color.LightGray), x + 8, y + 53, x + 115, y + 53);
                            //ASC16.DrawACSIIString(vbe, "Open...", (uint)Color.Black.ToArgb(), (uint)x + 5, (uint)y + 68);
                            ASC16.DrawACSIIString(vbe, "New file", Color.Black, (uint)x + 5, (uint)y + 88);
                        }
                        if (Kernel.filepage == false)
                        {

                        }
                        /*
                        if (Kernel.fullscreen1 == true)
                        {
                            x = 0;
                            y = 0;
                            width = 1280;
                            height = 738;
                            vbe.DrawFilledRectangle((uint)x, (uint)y, (uint)width, (uint)height, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawRectangle((uint)Color.Black.ToArgb(), (int)x, (int)y, (int)width, (int)height);
                            vbe.DrawFilledRectangle((uint)x + 3, (uint)y + 3, (uint)width - 6, 16, (uint)Color.DarkBlue.ToArgb());
                            ASC16.DrawACSIIString(vbe, "File-Explorer", (uint)Color.White.ToArgb(), (uint)x + 5, (uint)y + 3);
                            vbe.DrawFilledRectangle((uint)(x + width) - 76, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 51, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            vbe.DrawFilledRectangle((uint)(x + width) - 26, (uint)y + 5, 20, 12, (uint)Color.SlateGray.ToArgb());
                            //
                            vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 27, (uint)width - 10, 30, (uint)Color.LightGray.ToArgb());//62 magas
                            ASC16.DrawACSIIString(vbe, "File", (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 33);
                            vbe.DrawFilledRectangle((uint)x + 45, (uint)y + 32, (uint)width - 60, 20, (uint)Color.White.ToArgb());
                            ASC16.DrawACSIIString(vbe, parentdir, (uint)Color.Black.ToArgb(), (uint)x + 48, (uint)y + 33);

                            vbe.DrawFilledRectangle((uint)x + 5, (uint)y + 70, (uint)width - 10, (uint)height - 75, (uint)Color.White.ToArgb());
                            //Kernel k = new Kernel();
                            //Desktopfiles2(vbe, x + 15, y + 55);
                            //System.Drawing.Point CurMouse = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);


                            //string hope = "";
                            //ASC16.DrawACSIIString(vbe, k.file, (uint)Color.Black.ToArgb(), (uint)x + 8, (uint)y + 28);
                            //uint X = MouseManager.X;
                            //uint Y = MouseManager.Y;
                            //DirectoryEntryTypeEnum fileExpCtxType = DirectoryEntryTypeEnum.File;
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
                            }
                            if (Kernel.filepage == false)
                            {

                            }
                            System.Drawing.Point CurMouse0 = new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y);
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (uint)(x + width) - 26) && (CurMouse.X < (uint)(x + width) - 6))
                                {
                                    if ((CurMouse.Y > (uint)y + 5) && (CurMouse.Y < (uint)y + 17))
                                    {
                                        Kernel.opened1 = false;
                                    }
                                }
                            }
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (x + width) - 51) && (CurMouse.X < (x + width) - 31) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                                {
                                    Kernel.fullscreen1 = false;
                                }
                            }
                            if (Mouse.Click())
                            {
                                if ((CurMouse.X > (x + width) - 76) && (CurMouse.X < (x + width) - 56) && (CurMouse.Y > y + 5) && (CurMouse.Y < y + 17))
                                {
                                    Kernel.minimise1 = true;
                                }
                            }
                        }
                        if (Kernel.opened == false)
                        {

                        }
                        */
                    }
                }
                if (opened == false)
                {
                    TaskManager tmg = new TaskManager();
                    if (TaskManager.apps.Contains("File-E..."))
                    {
                        TaskManager.apps.Remove("File-E...");
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
                        if (z.Item1 == "File-E...")
                        {
                            if (MouseManager.X > z.Item2 && MouseManager.X < z.Item4)
                            {
                                if (MouseManager.Y > z.Item3 && MouseManager.Y < z.Item5)
                                {
                                    Booleans.explorer_minimised = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static int listcounter = 0;
        public void cleanupstring(string input, string separator)
        {
            List<string> d = new List<string>();
            string[] splited = input.Split(separator);
            foreach (string s in splited)
            {
                d.Add(s);
            }
            d.RemoveRange(d.Count - 1, 1);
            parentdir = "";
            foreach (string h in d)
            {
                if (listcounter == d.Count - 1)
                {
                    parentdir += h + "\\";
                }
                else
                {
                    parentdir += h + "\\";
                    listcounter += 1;
                }
            }
        }
    }
}
