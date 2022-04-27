using Cosmos.HAL;
using Cosmos.System;
using Cosmos.System.Graphics;
using CosmosKernel1;
using CosmosDrawString;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace resolution.SystemFolder
{
    class Lexer
    {
        //First element is standing for the name if the element.
        //Second element is standing for the data of it.
        public static List<Tuple<string, string>> stringcontainer = new System.Collections.Generic.List<Tuple<string, string>>();
        public static List<Tuple<string, int>> intcontainer = new System.Collections.Generic.List<Tuple<string, int>>();
        public static List<Tuple<string, bool>> boolcontainer = new System.Collections.Generic.List<Tuple<string, bool>>();
        public static List<Tuple<string, uint>> uintcontainer = new System.Collections.Generic.List<Tuple<string, uint>>();
        public static List<Tuple<string, long>> longcontainer = new System.Collections.Generic.List<Tuple<string, long>>();
        public static List<Tuple<string, ulong>> ulongcontainer = new System.Collections.Generic.List<Tuple<string, ulong>>();
        public static List<Tuple<string, short>> shortcontainer = new System.Collections.Generic.List<Tuple<string, short>>();
        public static List<Tuple<string, ushort>> ushortcontainer = new System.Collections.Generic.List<Tuple<string, ushort>>();
        public static List<Tuple<int, int, int, int, string>> buttontcontainer = new System.Collections.Generic.List<Tuple<int, int, int, int, string>>();
        public static List<Tuple<int, int, string>> textcontainer = new System.Collections.Generic.List<Tuple<int, int, string>>();
        public static bool active = true;
        public static bool active2 = true;
        public static bool active3 = true;
        public static bool left = false;
        public static bool right = false;
        public static bool hello = false;
        public static char separator = ' ';
        public static int leftdata = 0;
        public static int rightdata = 0;
        public static uint leftdata2 = 0;
        public static uint rightdata2 = 0;
        public static long leftdata3 = 0;
        public static long rightdata3 = 0;
        public static ulong leftdata4 = 0;
        public static ulong rightdata4 = 0;
        public static ushort leftdata5 = 0;
        public static ushort rightdata5 = 0;
        public static short leftdata6 = 0;
        public static short rightdata6 = 0;
        public static bool greenlight = false;
        public static bool wasif = false;
        public static bool waselse = false;
        public static bool elsesection = false;
        public static bool wasx = false;
        public static bool wask = false;
        public static bool ifsection = false;
        public static int b = 0;
        public static int d = 0;
        public static int noname = 0;
        public static int noname2 = 0;
        public static bool dd = true;
        public static bool opened = false;
        public static int a = 0;
        public static int b2 = 0;
        public static int c = 0;
        public static int d2 = 0;

        public static int a2 = 0;
        public static int b3 = 0;
        public static int c2 = 0;
        public static int d3 = 0;
        public static string title = "";
        public static int a3 = 0;
        public static int b4 = 0;
        public static int c3 = 0;
        public static int d4 = 0;
        public static string title2 = "";

        public static bool n = true;
        public static bool n1 = false;
        public static bool n2 = false;
        public static bool n3 = false;
        public static bool n4 = true;
        public static bool n5 = false;
        public static bool n6 = false;
        public static bool n7 = false;
        public static bool n8 = false;
        public static bool n9 = true;
        public static bool n10 = true;
        public static bool n11 = false;
        public static bool n12 = false;
        public static bool n13 = false;
        public static bool n14 = true;
        public static bool n15 = false;
        public static bool n16 = false;
        public static bool n17 = false;
        public static bool n18 = false;
        public static bool n19 = false;
        public void analyser(VBECanvas vbe)
        {
            try
            {
                string nex = "";
                string[] data = System.IO.File.ReadAllLines(@"0:\MYPRG.NEX");
                foreach (string g in data)
                {
                    noname += 1;
                }
                foreach (string s in data)
                {
                    #region mathenmatics
                    if (s.StartsWith("int"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 4);
                        //data of the int
                        string modified = s.Remove(0, b);
                        int a = int.Parse(modified);
                        if (intcontainer.Count < 2)
                        {
                            intcontainer.Add(new Tuple<string, int>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    if (s.StartsWith("uint"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 5);
                        //data of the int
                        string modified = s.Remove(0, b);
                        uint a = uint.Parse(modified);
                        if (uintcontainer.Count < 2)
                        {
                            uintcontainer.Add(new Tuple<string, uint>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    if (s.StartsWith("long"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 5);
                        //data of the int
                        string modified = s.Remove(0, b);
                        long a = long.Parse(modified);
                        if (longcontainer.Count < 2)
                        {
                            longcontainer.Add(new Tuple<string, long>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    if (s.StartsWith("ulong"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 6);
                        //data of the int
                        string modified = s.Remove(0, b);
                        ulong a = ulong.Parse(modified);
                        if (ulongcontainer.Count < 2)
                        {
                            ulongcontainer.Add(new Tuple<string, ulong>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    if (s.StartsWith("short"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 6);
                        //data of the int
                        string modified = s.Remove(0, b);
                        short a = short.Parse(modified);
                        if (shortcontainer.Count < 2)
                        {
                            shortcontainer.Add(new Tuple<string, short>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    if (s.StartsWith("ushort"))
                    {
                        foreach (char c in s)
                        {
                            if (active == true)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                            if (active == false) { }
                        }
                        //active = false;
                        //name of the int
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 7);
                        //data of the int
                        string modified = s.Remove(0, b);
                        ushort a = ushort.Parse(modified);
                        if (ushortcontainer.Count < 2)
                        {
                            ushortcontainer.Add(new Tuple<string, ushort>(modified3, a));
                        }
                        else { }
                        //intcontainer.Add(new Tuple<string, int>(modified3, a));
                    }
                    #endregion mathematics
                    if (s.StartsWith("string"))
                    {
                        int b = 0;
                        if (active2 == true)
                        {
                            foreach (char c in s)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                        }
                        //name of the string
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 7);
                        //data of the string
                        string modified = s.Remove(0, b);
                        stringcontainer.Add(new Tuple<string, string>(modified3, modified));
                    }
                    if (s.StartsWith("bool"))
                    {
                        int b = 0;
                        if (active2 == true)
                        {
                            foreach (char c in s)
                            {
                                if (c == '=')
                                {
                                    b += 2;
                                    active = false;
                                }
                                else
                                {
                                    b += 1;
                                }
                            }
                        }
                        //name of the bool
                        string modified2 = s.Remove(b - 3);
                        string modified3 = modified2.Remove(0, 5);
                        //data of the bool
                        bool modified = bool.Parse(s.Remove(0, b));
                        boolcontainer.Add(new Tuple<string, bool>(modified3, modified));
                    }
                    //here comes the tricky part
                    #region if/else block
                    /*
                    if (greenlight == false)
                    {
                        if (elsesection == true)
                        {
                            #region consoleclass
                            if (s.StartsWith("Console.WriteLine(\""))
                            {
                                string writeline = s.Remove(0, 19);
                                string writeline2 = writeline.Remove(writeline.Length - 2);
                                ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            }
                            if (s.StartsWith("Console.ReadKey("))
                            {
                                string button = "";
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    button += key.KeyChar;
                                }
                                ASC16.DrawACSIIString(vbe, button, (uint)Color.Black.ToArgb(), 120, 35);
                                button = "";
                            }
                            if (s.StartsWith("Console.ReadLine("))
                            {
                                string button = "";
                                if (KeyboardManager.TryReadKey(out KeyEvent key))
                                {
                                    button += key.KeyChar;
                                }
                                ASC16.DrawACSIIString(vbe, "You have pressed the following buttons:" + button, (uint)Color.Black.ToArgb(), 120, 55);
                            }
                            #endregion consoleclass
                            #region Filesystem
                            bool allowed = false;
                            if (s.StartsWith("File.Create(\""))
                            {
                                string writeline = s.Remove(0, 13);
                                string writeline2 = writeline.Remove(writeline.Length - 2);
                                //allowed = true;
                                //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                                if (!File.Exists(writeline2))
                                {
                                    File.Create(writeline2);
                                }
                                else
                                {

                                }
                            }
                            if (s.StartsWith("File.Delete(\""))
                            {
                                string writeline = s.Remove(0, 13);
                                string writeline2 = writeline.Remove(writeline.Length - 2);
                                //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                                if (File.Exists(writeline2))
                                {
                                    File.Delete(writeline2);
                                }
                                else
                                {

                                }
                            }
                            if (s.StartsWith("File.Move(\""))
                            {
                                string writeline = s.Remove(0, 11);
                                bool xd = true;
                                int l = 0;
                                foreach (char c in writeline)
                                {
                                    if (xd == true)
                                    {
                                        if (c == ',')
                                        {
                                            l += 2;
                                            xd = false;
                                        }
                                        else
                                        {
                                            l += 1;
                                        }
                                    }
                                }
                                string source = writeline.Remove(l - 3);
                                string destination = writeline.Remove(0, l + 1);
                                string destination2 = destination.Remove(destination.Length - 2);
                                //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                                if (File.Exists(source))
                                {
                                    if (!File.Exists(destination2))
                                    {
                                        File.Copy(source, destination2);
                                        File.Delete(source);
                                    }
                                }
                            }
                            if (s.StartsWith("File.Exists(\""))
                            {
                                string writeline = s.Remove(0, 13);
                                string writeline2 = writeline.Remove(writeline.Length - 2);
                                //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                                if (File.Exists(writeline2))
                                {
                                    allowed = true;
                                }
                                if (!File.Exists(writeline2))
                                {
                                    allowed = false;
                                }
                            }
                            #endregion Filesystem
                            #region register window&elements
                            if (s.StartsWith("Console.WriteLine(\""))
                            {
                                string writeline = s.Remove(0, 19);
                                string writeline2 = writeline.Remove(writeline.Length - 2);
                                ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            }
                            #endregion register window&elements
                        }
                    }
                    */
                    if (s.StartsWith("{"))
                    {

                    }
                    if (s.StartsWith("}"))
                    {
                        //greenlight = false;
                    }
                    if (s.StartsWith("if("))
                    {
                        //int c = 0;
                        foreach (char c in s)
                        {
                            if (active3 == true)
                            {
                                if (c == '>')
                                {
                                    d += 2;
                                    separator = '>';
                                    active3 = false;
                                }
                                else if (c == '<')
                                {
                                    d += 2;
                                    separator = '<';
                                    active3 = false;
                                }
                                else if (c == '=')
                                {
                                    d += 2;
                                    separator = '=';
                                    active3 = false;
                                }
                                else
                                {
                                    d += 1;
                                }
                            }
                            if (active3 == false) { }
                        }
                        //active2 = false;
                        //Left side of the if block
                        string leftside = s.Remove(d - 3);
                        string leftside2 = leftside.Remove(0, 3);
                        //leftdata = leftside2;
                        //Right side of the if block
                        string rightside = s.Remove(0, d);
                        string rightside2 = rightside.Remove(rightside.Length - 1);
                        foreach (Tuple<string, int> w in intcontainer)
                        {
                            if (w.Item1 == leftside2)
                            {
                                leftdata = w.Item2;
                                left = true;
                            }
                            if (w.Item1 == rightside2)
                            {
                                rightdata = w.Item2;
                                right = true;
                            }
                        }
                        if (separator == '<')
                        {
                            int result = Math.Max(leftdata, rightdata);
                            if (result == rightdata)
                            {
                                greenlight = true;
                            }
                            if (result == leftdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                            if(result == leftdata || result == rightdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                        }
                        if (separator == '>')
                        {
                            int result = Math.Max(leftdata, rightdata);
                            if (result == rightdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                            if (result == leftdata)
                            {
                                greenlight = true;
                            }
                            if (result == leftdata || result == rightdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                        }
                        if (separator == '=')
                        {
                            int result = Math.Max(leftdata, rightdata);
                            if (result == rightdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                            if (result == leftdata)
                            {
                                hello = true;
                                greenlight = false;
                            }
                            if (result == leftdata || result == rightdata)
                            {
                                greenlight = true;
                            }
                        }
                    }
                    if (hello == true)
                    {
                        if (s.StartsWith("else"))
                        {
                            //wasif = false;
                            //waselse = true;
                            greenlight = true;
                            hello = false;
                            //ifsection = false;
                        }
                        else
                        {

                        }
                    }
                    if (greenlight == true)
                    {
                        #region consoleclass
                        if (s.StartsWith("Console.WriteLine(\""))
                        {
                            string writeline = s.Remove(0, 19);
                            string writeline2 = writeline.Remove(writeline.Length - 2);
                            ASC16.DrawACSIIString(vbe, writeline2, Color.Black, 120, 15);
                        }
                        if (s.StartsWith("Console.ReadKey("))
                        {
                            string button = "";
                            if (KeyboardManager.TryReadKey(out KeyEvent key))
                            {
                                button += key.KeyChar;
                            }
                            ASC16.DrawACSIIString(vbe, button, Color.Black, 120, 35);
                            button = "";
                        }
                        if (s.StartsWith("Console.ReadLine("))
                        {
                            string button = "";
                            if (KeyboardManager.TryReadKey(out KeyEvent key))
                            {
                                button += key.KeyChar;
                            }
                            ASC16.DrawACSIIString(vbe, "You have pressed the following buttons:" + button, Color.Black, 120, 55);
                        }
                        #endregion consoleclass
                        #region Filesystem
                        bool allowed = false;
                        if (s.StartsWith("File.Create(\""))
                        {
                            string writeline = s.Remove(0, 13);
                            string writeline2 = writeline.Remove(writeline.Length - 2);
                            //allowed = true;
                            //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            if (!File.Exists(writeline2))
                            {
                                File.Create(writeline2);
                            }
                            else
                            {

                            }
                        }
                        if (s.StartsWith("File.Delete(\""))
                        {
                            string writeline = s.Remove(0, 13);
                            string writeline2 = writeline.Remove(writeline.Length - 2);
                            //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            if (File.Exists(writeline2))
                            {
                                File.Delete(writeline2);
                            }
                            else
                            {

                            }
                        }
                        if (s.StartsWith("File.Move(\""))
                        {
                            string writeline = s.Remove(0, 11);
                            bool xd = true;
                            int l = 0;
                            foreach (char c in writeline)
                            {
                                if (xd == true)
                                {
                                    if (c == ',')
                                    {
                                        l += 2;
                                        xd = false;
                                    }
                                    else
                                    {
                                        l += 1;
                                    }
                                }
                            }
                            string source = writeline.Remove(l - 3);
                            string destination = writeline.Remove(0, l + 1);
                            string destination2 = destination.Remove(destination.Length - 2);
                            //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            if (File.Exists(source))
                            {
                                if (!File.Exists(destination2))
                                {
                                    File.Copy(source, destination2);
                                    File.Delete(source);
                                }
                            }
                        }
                        if (s.StartsWith("File.Exists(\""))
                        {
                            string writeline = s.Remove(0, 13);
                            string writeline2 = writeline.Remove(writeline.Length - 2);
                            //ASC16.DrawACSIIString(vbe, writeline2, (uint)Color.Black.ToArgb(), 120, 15);
                            if (File.Exists(writeline2))
                            {
                                allowed = true;
                            }
                            if (!File.Exists(writeline2))
                            {
                                allowed = false;
                            }
                        }
                        #endregion Filesystem
                        #region register window&elements
                        if (s.StartsWith("Console.WriteLine(\""))
                        {
                            string writeline = s.Remove(0, 19);
                            string writeline2 = writeline.Remove(writeline.Length - 2);
                            ASC16.DrawACSIIString(vbe, writeline2, Color.Black, 120, 15);
                        }
                        #endregion register window&elements
                        #region window&elements
                        if (s.StartsWith("System.DefineWindow("))
                        {
                            opened = true;
                            string removed = s.Remove(0, 20);
                            string removed2 = removed.Remove(removed.Length - 1);
                            string[] alpha = removed2.Split(", ");
                            foreach (string g in alpha)
                            {
                                if (n3 == true)
                                {
                                    d2 = int.Parse(g);
                                    n3 = false;
                                }
                                if (n2 == true)
                                {
                                    c = int.Parse(g);
                                    n3 = true;
                                    n2 = false;
                                }
                                if (n1 == true)
                                {
                                    b2 = int.Parse(g);
                                    n2 = true;
                                    n1 = false;
                                }
                                if (n == true)
                                {
                                    a = int.Parse(g);
                                    n1 = true;
                                    n = false;
                                }
                            }
                            n = true;
                        }
                        if (s.StartsWith("System.DefineButton("))
                        {
                            opened = true;
                            string removed = s.Remove(0, 20);
                            string removed2 = removed.Remove(removed.Length - 1);
                            string[] alpha = removed2.Split(", ");
                            foreach (string g in alpha)
                            {
                                if (n8 == true)
                                {
                                    title = g;
                                    n8 = false;
                                }
                                if (n7 == true)
                                {
                                    d3 = int.Parse(g);
                                    n8 = true;
                                    n7 = false;
                                }
                                if (n6 == true)
                                {
                                    c2 = int.Parse(g);
                                    n7 = true;
                                    n6 = false;
                                }
                                if (n5 == true)
                                {
                                    b3 = int.Parse(g);
                                    n6 = true;
                                    n5 = false;
                                }
                                if (n4 == true)
                                {
                                    a2 = int.Parse(g);
                                    n5 = true;
                                    n4 = false;
                                }
                            }
                            if (buttontcontainer.Count < 2)
                            {
                                buttontcontainer.Add(new Tuple<int, int, int, int, string>(a2, b3, c2, d3, title));
                            }
                            n4 = true;
                            //buttontcontainer.Add(new Tuple<int, int, int, int, string>(a2, b3, c2, d3, title));
                        }
                        if (s.StartsWith("System.DrawString("))
                        {
                            //opened = true;
                            string removed = s.Remove(0, 18);
                            string removed2 = removed.Remove(removed.Length - 1);
                            string[] alpha = removed2.Split(", ");
                            foreach (string g in alpha)
                            {
                                if (n11 == true)
                                {
                                    title2 = g;
                                    n11 = false;
                                }
                                if (n10 == true)
                                {
                                    b4 = int.Parse(g);
                                    n11 = true;
                                    n10 = false;
                                }
                                if (n9 == true)
                                {
                                    a3 = int.Parse(g);
                                    n10 = true;
                                    n9 = false;
                                }
                            }
                            if (textcontainer.Count < 2)
                            {
                                textcontainer.Add(new Tuple<int, int, string>(a3, b4, title2));
                            }
                            n9 = true;
                            //buttontcontainer.Add(new Tuple<int, int, int, int, string>(a2, b3, c2, d3, title));
                        }
                        if (c != 0)
                        {
                            Window w = new Window();
                            w.window(vbe, a, b2, c, d2, "executable", opened);
                        }
                        #endregion window&elements
                    }
                    //For future me: Try to use else if block unless you haven't figured out the actual causer of the issue
                    noname2 += 1;
                    //wasif = false;
                    #endregion if/else block
                    if (noname2 == noname)
                    {
                        active = true;
                        active2 = true;
                        active3 = true;
                        left = false;
                        right = false;
                        separator = ' ';
                        leftdata = 0;
                        rightdata = 0;
                        greenlight = false;
                        wasif = false;
                        waselse = false;
                        elsesection = false;
                        wasx = false;
                        wask = false;
                        ifsection = false;
                        b = 0;
                        d = 0;
                        noname2 = 0;
                        noname = 0;
                    }
                    noname = 0;
                }
            }
            catch (Exception e)
            {
                ASC16.DrawACSIIString(vbe, e.Message, Color.Black, 150, 15);
            }
        }
    }
}
/*
foreach (Tuple<string, uint> w in uintcontainer)
{
    if (w.Item1 == leftside2)
    {
        leftdata2 += w.Item2;
        left = true;
    }
    if (w.Item1 == rightside2)
    {
        rightdata2 += w.Item2;
        right = true;
    }
}
foreach (Tuple<string, long> w in longcontainer)
{
    if (w.Item1 == leftside2)
    {
        leftdata3 += w.Item2;
        left = true;
    }
    if (w.Item1 == rightside2)
    {
        rightdata3 += w.Item2;
        right = true;
    }
}
foreach (Tuple<string, ulong> w in ulongcontainer)
{
    if (w.Item1 == leftside2)
    {
        leftdata4 += w.Item2;
        left = true;
    }
    if (w.Item1 == rightside2)
    {
        rightdata4 += w.Item2;
        right = true;
    }
}
foreach (Tuple<string, short> w in shortcontainer)
{
    if (w.Item1 == leftside2)
    {
        leftdata6 += w.Item2;
        left = true;
    }
    if (w.Item1 == rightside2)
    {
        rightdata6 += w.Item2;
        right = true;
    }
}
foreach (Tuple<string, ushort> w in ushortcontainer)
{
    if (w.Item1 == leftside2)
    {
        leftdata5 += w.Item2;
        left = true;
    }
    if (w.Item1 == rightside2)
    {
        rightdata5 += w.Item2;
        right = true;
    }
}
*/
/*
if (s.StartsWith("{"))
{
    if (separator == '<')
    {
        int result = Math.Max(leftdata, rightdata);
        if (result != rightdata)
        {
            elsesection = true;
        }
    }
    else if (separator == '>')
    {
        int result = Math.Max(leftdata, rightdata);
        if (result != leftdata)
        {
            elsesection = true;
        }
    }
    else if (separator == '=')
    {
        if (leftdata != rightdata)
        {
            elsesection = true;
        }
    }
}
if (s.StartsWith("}"))
{
    elsesection = false;
}
*/
//if(waselse == true) { }
/*
if (ifsection == true)
{
    if (wasif == true)
    {
        if (left == true)
        {
            if (right == true)
            {
                if (separator == '<')
                {
                    int result = Math.Max(leftdata, rightdata);
                    if (result == rightdata)
                    {
                        greenlight = true;
                    }
                    /*
                    if (result1 == rightdata2)
                    {
                        greenlight = true;
                    }
                    if (result2 == rightdata3)
                    {
                        greenlight = true;
                    }
                    if (result3 == rightdata4)
                    {
                        greenlight = true;
                    }
                    if (result4 == rightdata6)
                    {
                        greenlight = true;
                    }
                    if (result5 == rightdata5)
                    {
                        greenlight = true;
                    }
                }
                else if (separator == '>')
                {
                    int result = Math.Max(leftdata, rightdata);
                    if (result == leftdata)
                    {
                        greenlight = true;
                    }
                    /*
                    if (result1 == leftdata2)
                    {
                        greenlight = true;
                    }
                    if (result2 == leftdata3)
                    {
                        greenlight = true;
                    }
                    if (result3 == leftdata4)
                    {
                        greenlight = true;
                    }
                    if (result4 == leftdata6)
                    {
                        greenlight = true;
                    }
                    if (result5 == leftdata5)
                    {
                        greenlight = true;
                    }
                }
                else if (separator == '=')
                {
                    if (leftdata == rightdata)
                    {
                        greenlight = true;
                    }
                    /*
                    if (leftdata2 == rightdata2)
                    {
                        greenlight = true;
                    }
                    if (leftdata3 == rightdata3)
                    {
                        greenlight = true;
                    }
                    if (leftdata4 == rightdata4)
                    {
                        greenlight = true;
                    }
                    if (leftdata5 == rightdata5)
                    {
                        greenlight = true;
                    }
                    if (leftdata6 == rightdata6)
                    {
                        greenlight = true;
                    }
                }
            }
        }
    }
}
*/
