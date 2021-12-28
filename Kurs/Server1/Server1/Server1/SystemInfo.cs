using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Management;

namespace Server1
{
    internal class SystemInfo
    {
        private int cursorX;
        private int cursorY;
        private int lastErr;
        public SystemInfo()
        {
            this.cursorX = Cursor.Position.X;
            this.cursorY = Cursor.Position.Y;
            this.lastErr = Marshal.GetLastWin32Error();
        }

        public string getCursorPosition()
        {
            return Convert.ToString(this.cursorX) + ";" + Convert.ToString(this.cursorY);
        }
        public string getlastError() { return Convert.ToString(this.lastErr);}
    }
}
