using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.WinForm.MessageBox
{
    public static class Methods
    {
        public enum DialogResults
        {
            Yes = 6,
            No = 7,
            Cancel = 2,
            OK = 1
        }

        public enum MessageBoxButtons
        {
            OK = 0,
            YesNoCancel = 3,
            YesNo = 4,
            OKCancel = 1
        }

        public static bool SuppressMessageBox { get; set; } = false;
    }
}
