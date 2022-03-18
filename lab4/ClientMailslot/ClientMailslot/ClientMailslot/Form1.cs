using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientMailslot
{
    public partial class Form1 : Form
    {

        public static IntPtr _WriteHandle;
        public static string _SlotName = "slot1";
        public static string Scope = "*";
        uint bytesWritten = 0;
        public static System.Threading.NativeOverlapped stnOverlap = new System.Threading.NativeOverlapped();
        public static bool result;

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare, int securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        private unsafe static extern bool ReadFile(IntPtr hFile, out byte[] lpBuffer, int nNumberOfBytesToRead, int* lpNumberOfBytesRead,
            int overlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten,
            [In] ref System.Threading.NativeOverlapped lpOverlapped);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "df";
            byte[] data = new byte[64];
            data = Encoding.Unicode.GetBytes(message);
            _WriteHandle = CreateFile("\\\\" + Scope + "\\mailslot\\" + _SlotName,
                      FileAccess.Write, FileShare.Read, 0, FileMode.Open, 0, IntPtr.Zero);
            result=WriteFile(_WriteHandle, data, (uint)data.Length, out bytesWritten, ref stnOverlap);
            label1.Text = _WriteHandle.ToString();
        }
    }
}
