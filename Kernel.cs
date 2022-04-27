using Cosmos.Core;
using Cosmos.Core.IOGroup;
using Cosmos.HAL.Drivers;
using Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using CosmosDrawString;
using CosmosKernel1;
using resolution;
using resolution.Applications;
using resolution.NewFolder;
using resolution.SystemFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Point = Cosmos.System.Graphics.Point;
using Sys = Cosmos.System;

namespace CrystalOS
{
    public class Kernel : Sys.Kernel
    {
        public static bool computernamebox = true;
        public static bool password = false;
        public static bool password2 = false;
        public static bool filepage = false;
        public static string passw = "x";
        public static string passw2 = "x2";
        public static bool timebool = false;
        public static bool createfile = false;
        public static bool finished = false;
        public static bool checkrequirements = true;
        public static bool ramok = false;
        public static bool personalinfo = false;
        public static bool getuserdata = false;
        public static bool background = false;
        public static string computername = "My-PC";
        public static bool recordtime = false;
        public static bool basic = true;
        public static bool hardware = false;
        public static bool sofware = false;
        public static CosmosVFS FS = new Sys.FileSystem.CosmosVFS();
        private string lastDirFilePath = "";
        private List<DirectoryEntry> lastDirFile = new List<DirectoryEntry>();
        private string lastDirFolderPath = "";
        private List<DirectoryEntry> lastDirFolder = new List<DirectoryEntry>();
        public List<DirectoryEntry> getDirFiles(string path)
        {
            if (path == lastDirFilePath)
            {
                return lastDirFile;
            }
            List<DirectoryEntry> l = new List<DirectoryEntry>();
            foreach (DirectoryEntry d in Kernel.FS.GetDirectoryListing(path.ToUpper()))
            {
                if (d.mEntryType == Cosmos.System.FileSystem.Listing.DirectoryEntryTypeEnum.File)
                {
                    l.Add(d);
                }
            }
            lastDirFilePath = path;
            lastDirFile = l;
            return l;
        }
        private static List<Tuple<int, int, int, int, String>> fileExpFiles = new List<Tuple<int, int, int, int, String>>();
        private static List<Tuple<int, int, int, int, String>> fileExpDirs = new List<Tuple<int, int, int, int, String>>();
        public List<DirectoryEntry> getDirFolders(string path)
        {
            if (path == lastDirFolderPath)
            {
                return lastDirFolder;
            }
            List<DirectoryEntry> l = new List<DirectoryEntry>();
            foreach (DirectoryEntry d in Kernel.FS.GetDirectoryListing(path.ToUpper()))
            {
                if (d.mEntryType == Cosmos.System.FileSystem.Listing.DirectoryEntryTypeEnum.Directory)
                {
                    l.Add(d);
                }
            }
            lastDirFolderPath = path;
            lastDirFolder = l;
            return l;
        }

        public static List<Tuple<string, int, int, int, int>> applist = new List<Tuple<string, int, int, int, int>>();

        int[] cursor = new int[]
{
                1,0,0,0,0,0,0,0,0,0,0,0,
                1,1,0,0,0,0,0,0,0,0,0,0,
                1,2,1,0,0,0,0,0,0,0,0,0,
                1,2,2,1,0,0,0,0,0,0,0,0,
                1,2,2,2,1,0,0,0,0,0,0,0,
                1,2,2,2,2,1,0,0,0,0,0,0,
                1,2,2,2,2,2,1,0,0,0,0,0,
                1,2,2,2,2,2,2,1,0,0,0,0,
                1,2,2,2,2,2,2,2,1,0,0,0,
                1,2,2,2,2,2,2,2,2,1,0,0,
                1,2,2,2,2,2,2,2,2,2,1,0,
                1,2,2,2,2,2,2,2,2,2,2,1,
                1,2,2,2,2,2,2,1,1,1,1,1,
                1,2,2,2,1,2,2,1,0,0,0,0,
                1,2,2,1,0,1,2,2,1,0,0,0,
                1,2,1,0,0,1,2,2,1,0,0,0,
                1,1,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,1,2,2,1,0,0,
                0,0,0,0,0,0,0,1,1,0,0,0
};
        public static Cosmos.System.Graphics.VBECanvas vbe = new Cosmos.System.Graphics.VBECanvas(new Mode(1280, 768, ColorDepth.ColorDepth32));

        public static Color background1 = Color.Empty;

        int[] icon = new int[]
{
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,
                0,0,0,0,1,2,1,2,2,2,2,2,2,2,1,0,0,
                0,0,0,1,2,2,1,2,2,2,2,2,2,2,1,0,0,
                0,0,1,2,2,2,1,2,2,2,2,2,2,2,1,0,0,
                0,1,1,1,1,1,1,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,
                0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0
};
        //unknown file (h=27;w=22)
        int[] icon2 = new int[]
{
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,0,0,0,0,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,0,0,0,1,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,0,0,1,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,0,1,2,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
                0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
};

        int[] folder = new int[960]
        {
            //height = 24, width =40
            0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
            0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
            0,0,0,1,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,
            0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
        };

        public static int explorerwidth = 590;
        public static int explorerheight = 335;
        public static bool fullscreen = false;
        public static int calcwidth = 139;
        public static int calcheight = 194;
        public static bool display = false;
        public static bool SandA = false;
        public static int x = 400;
        public static int y = 10;
        public static int width = 500;
        public static int height = 400;
        public static string god = @"0:\";
        public static int explorery = 150;
        public static int explorerx = 500;
        public static int desktopx = 5;
        public static int desktopy = 5;
        public static bool lost = false;
        public static bool filesystem = true;
        public static bool quriousity = true;

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS);
            FS.Initialize();
            vbe.Clear(Color.White);
            MouseManager.ScreenWidth = 1280;
            MouseManager.ScreenHeight = 768;
            MouseManager.X = 1280 / 2;
            MouseManager.Y = 768 / 2;

            if (File.Exists(@"0:\SystemFolder\Screen.sdf"))
            {
                string a = File.ReadAllText(@"0:\SystemFolder\Screen.sdf");
                if (a.Contains("Pink"))
                {
                    background1 = Color.Pink;
                }
                if (a.Contains("Green"))
                {
                    background1 = Color.Green;
                }
                if (a.Contains("Blue"))
                {
                    background1 = Color.Blue;
                }
                if (a.Contains("Yellow"))
                {
                    background1 = Color.Yellow;
                }
                if (a.Contains("Red"))
                {
                    background1 = Color.Red;
                }
                if (a.Contains("Orange"))
                {
                    background1 = Color.Orange;
                }
                if (a.Contains("Black"))
                {
                    background1 = Color.Black;
                }
                if (a.Contains("Purple"))
                {
                    background1 = Color.Purple;
                }
                if (a.Contains("Aqua"))
                {
                    background1 = Color.Aqua;
                }
                if (a.Contains("White"))
                {
                    background1 = Color.White;
                }
            }
            else
            {
                background1 = Color.Blue;
            }
        }

        protected override void Run()
        {
            if (File.Exists(@"0:\SystemFolder\setupa.sdf"))
            {
                if (File.ReadAllText(@"0:\SystemFolder\setupa.sdf") == "finished")
                {

                }
                else
                {
                    Setup sd = new Setup();
                    //sd.setup(vbe);
                }
            }
            else
            {
                Setup sd = new Setup();
                //sd.setup(vbe);
            }
            #region
            FolderExplorer f = new FolderExplorer();
            TextRenderer text = new TextRenderer();
            settings s = new settings();
            #region desktop
            //vbe.Clear(Color.Teal);
            vbe.Clear(background1);
            //Desktopfiles(vbe, desktopx, desktopy, explorerx + 10, explorery + 70);
            #endregion desktop
            //vbe.DrawFilledRectangle(new Pen(Color.Teal), 0, 0, 1280, 768);
            //text.StringTextHandler(vbe, FPS.ToString(), new Point(0, 0));
            #region taskbar
            vbe.DrawFilledRectangle(new Pen(Color.Silver), 0, 738, 1280, 30);
            vbe.DrawFilledRectangle(new Pen(Color.LightGray), 5, 743, 55, 20);
            vbe.DrawRectangle(new Pen(Color.Black), 0, 737, 1279, 30);

            vbe.DrawRectangle(new Pen(Color.Black), 5, 743, 55, 20);
            text.StringTextHandler(vbe, "menu", new Point(7, 743));
            ASC16.DrawACSIIString(vbe, DateTime.UtcNow.Hour + ":" + DateTime.UtcNow.Minute, Color.Black, 1215, 742);
            ASC16.DrawACSIIString(vbe, $"{DateTime.UtcNow.Year + "." + DateTime.UtcNow.Month + "." + DateTime.UtcNow.Day}", Color.Black, 1200, 755);
            DrawMenu.update(new System.Drawing.Point((int)MouseManager.X, (int)MouseManager.Y), vbe);
            #region opened apps
            int drawx = 65;
            int drawy = 743;
            foreach (string str in TaskManager.apps)
            {
                applist.Add(new Tuple<string, int, int, int, int>(str, drawx, drawy, drawx + 125, drawy + 20));
                vbe.DrawFilledRectangle(new Pen(Color.White), drawx, drawy, 125, 20);
                vbe.DrawRectangle(new Pen(Color.Black), drawx, drawy, 125, 20);
                ASC16.DrawACSIIString(vbe, str, Color.Black, (uint)drawx + 2, (uint)drawy + 2);
                drawx += 130;
            }
            #endregion opened apps
            #endregion taskbar
            //
            #region accessories
            if (Calculator.moove_enabled == true || Calendar.moove_enabled == true || Clock.moove_enabled == true || /*FileExplorer.moove_enabled == true ||*/ FolderExplorer.moove_enabled == true || Minesweeper.moove_enabled == true || settings.moove_enabled == true)
            {

            }
            else
            {
                //Hint: Right click activities comes here
            }
            #endregion accessories
            //
            #region activate apps
            s.Settings(vbe, x, y, width, height, fullscreen, Booleans.display, SandA, Booleans.settings_open, Booleans.settings_minimised, lost);
            Calculator calculator = new Calculator();
            calculator.calculator(vbe, Int_Manager.calc_x, Int_Manager.calc_y, calcwidth, calcheight, Booleans.calculator_opened, Booleans.calculator_minimised, Booleans.text, Booleans.secnum, Booleans.num1, Booleans.num2, Booleans.result);
            Calendar cal = new Calendar();
            cal.File_Explorer(vbe, Int_Manager.calendar_x, Int_Manager.calendar_y, 520, 400, Booleans.calendar_opened, fullscreen, Booleans.calendar_minimised);
            Clock clock = new Clock();
            clock.init(vbe, Int_Manager.clock_x, Int_Manager.clock_y, Int_Manager.clock_width, Int_Manager.clock_height, Booleans.clock_opened, fullscreen, Booleans.clock_minimised);
            Minesweeper minesweeper = new Minesweeper();
            minesweeper.minesweeper(vbe, Int_Manager.minesweeper_x, Int_Manager.minesweeper_y, 150, 200, Booleans.minesweeper_minimised, fullscreen, Booleans.minesweeper_opened);
            f.File_Explorer2(vbe, Int_Manager.explorer_x, Int_Manager.explorer_y, explorerwidth, explorerheight, Booleans.explorer_opened, Booleans.explorer_maximised, Booleans.explorer_minimised);
            Computer_information ci = new Computer_information();
            dialogbox db = new dialogbox();
            db.Savedialog(vbe, Int_Manager.dialogbox_x, Int_Manager.dialogbox_y);
            ci.init(vbe, Int_Manager.compiteri_x, Int_Manager.computeri_y, 400, 320, Booleans.computeri_opened, Booleans.computeri_fullscreen, Booleans.computeri_minimised, basic, hardware, sofware);
            #endregion activate apps
            #endregion
            //vbe.DrawFilledRectangle(new Pen(Color.Black), (int)MouseManager.X, (int)MouseManager.Y, 10, 10);
            DrawCursor(vbe, MouseManager.X, MouseManager.Y);
            vbe.Display();
            //Update();
        }

        public void FirstIcon(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 27; h++)
            {
                for (uint w = 0; w < 22; w++)
                {
                    if (icon2[h * 22 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (icon2[h * 22 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.White), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }
        public void FirstFolder(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 24; h++)
            {
                for (uint w = 0; w < 40; w++)
                {
                    if (folder[h * 40 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Orange), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (folder[h * 40 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Yellow), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (folder[h * 40 + w] == 3)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.White), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }
        public void DrawCursor(VBECanvas vbe, uint x, uint y)
        {
            for (uint h = 0; h < 19; h++)
            {
                for (uint w = 0; w < 12; w++)
                {
                    if (cursor[h * 12 + w] == 1)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.Black), (int)(w + x), (int)(h + y), 1, 1);
                    }
                    if (cursor[h * 12 + w] == 2)
                    {
                        vbe.DrawFilledRectangle(new Pen(Color.White), (int)(w + x), (int)(h + y), 1, 1);
                    }
                }
            }
        }
    }
}
