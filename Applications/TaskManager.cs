using Cosmos.System.Graphics;
using CosmosDrawString;
using CosmosKernel1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace resolution.Applications
{
    class TaskManager
    {
        public static List<string> apps = new List<string>();
        //Note: task name, task status, origin of the app(hard coded or external)
        public void TaskMan(VBECanvas vbe, int x, int y, int width, int height, bool opened)
        {
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x, y, width, height);
            vbe.DrawRectangle(new Pen(Color.Black), (int)x, (int)y, (int)width, (int)height);
            vbe.DrawFilledRectangle(new Pen(Color.DarkBlue), x + 3, y + 3, width - 6, 16);
            ASC16.DrawACSIIString(vbe, "Task Manager", Color.White, (uint)x + 5, (uint)y + 3);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 76, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 51, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), (x + width) - 26, y + 5, 20, 12);
            vbe.DrawFilledRectangle(new Pen(Color.SlateGray), x + 3, y + 21, width - 6, height - 23);
           /*
            #region rendering tasks
            int taskx = x + 8;
            int tasky = y + 25;
            foreach(Tuple<string, string, string> a in apps)
            {
                vbe.DrawACSIIString(a.Item1, (uint)Color.Black.ToArgb(), (uint)taskx, (uint)tasky);
                tasky += 15;
                /*
                if (a.Item1.Length > 7)
                {
                    string shortedtaskname = a.Item1.Remove(7) + "...";
                    vbe.DrawACSIIString(shortedtaskname, (uint)Color.Black.ToArgb(), (uint)taskx, (uint)tasky);
                    tasky += 15;
                }
                if(a.Item1.Length <= 7)
                {
                    vbe.DrawACSIIString(a.Item1, (uint)Color.Black.ToArgb(), (uint)taskx, (uint)tasky);
                    tasky += 15;
                }
                */
        }
    }
}
