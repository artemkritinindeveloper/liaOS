using System;
using System.Collections.Generic;
using System.Text;

namespace resolution.SystemFolder
{
    class Booleans
    {
        #region DialogBox
        public static bool dialogbox_opened = false;
        public static bool dialogbox_minimised = false;
        #endregion DialogBox
        //
        #region Clock
        public static bool clock_opened = false;
        public static bool clock_minimised = false;
        #endregion Clock
        //
        #region Taskmanager
        public static bool taskmgr_opened = false;
        public static bool taskmgr_minimised = false;
        #endregion Taskmanager
        //
        #region Calculator
        public static bool calculator_opened = false;
        public static bool calculator_minimised = false;
        public static bool num1 = true;
        public static bool num2 = false;
        public static bool result = false;
        public static int resutment;
        public static string text = string.Empty;
        public static string action = string.Empty;
        public static string secnum = string.Empty;
        #endregion Calculator
        //
        #region Calendar
        public static bool calendar_opened = false;
        public static bool calendar_minimised = false;
        #endregion Calendar
        //
        #region CommandPrompt
        public static bool cmd_opened = false;
        public static bool cmd_minimised = false;
        #endregion CommandPrompt
        //
        #region Explorer
        public static bool explorer_opened = false;
        public static bool explorer_minimised = false;
        public static bool explorer_maximised = false;
        #endregion Explorer
        //
        #region Minesweeper
        public static bool minesweeper_opened = false;
        public static bool minesweeper_minimised = false;
        #endregion Minesweeper
        //
        #region Settings
        public static bool settings_open = false;
        public static bool settings_minimised = false;
        public static bool display = true;
        #endregion Settings
        //
        #region Computer_Info
        public static bool computeri_opened = false;
        public static bool computeri_minimised = false;
        public static bool computeri_fullscreen = false;
        #endregion Computer_Info
        //
        #region Command_prompt
        public static bool commandpr_opened = false;
        public static bool commandpr_minimised = false;
        #endregion Commpand_prompt
        //
        #region SSM
        public static bool firstwindow = true;
        public static bool secondwindow = false;
        public static bool thirdwindow = false;
        public static bool SSM_minimised = false;
        public static bool SSM_opened = false;
        public static bool egy = false;
        public static string executable = @"0:\";
        public static string shortcutlocation = @"0:\";
        #endregion SSM
        //
        #region external_executebles
        public static bool openwindow = false;
        #endregion external_executables

        #region Calculator
        public static bool calc = false;
        #endregion Calculator
    }
}
