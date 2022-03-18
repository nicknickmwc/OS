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
using System.Threading;
using System.Windows.Forms;

namespace ServerMailslot
{
    public partial class Form1 : Form
    {

        public static string _SlotName = "slot1";
        public static IntPtr _ReadHandle;
        public static IntPtr _WriteHandle;
        public static int iMsgSize = 0;
        public static uint bytesWritten = 0;
        public static System.Threading.NativeOverlapped stnOverlap = new System.Threading.NativeOverlapped();

        [DllImport("kernel32.dll")]
        static extern bool GetFileTime(IntPtr hFile, out IntPtr lpCreationTime, out IntPtr lpLastAccessTime, out IntPtr lpLastWriteTime);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateMailslot(string lpName, uint nMaxMessageSize, uint lReadTimeout, IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll")]
        static extern bool GetMailslotInfo(IntPtr hMailslot, int lpMaxMessageSize, ref int lpNextSize, IntPtr lpMessageCount, IntPtr lpReadTimeout);

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare, int securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadFile(IntPtr hFile, out byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead,
            [In] ref System.Threading.NativeOverlapped lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten,
            [In] ref System.Threading.NativeOverlapped lpOverlapped);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = getMessage();
            //Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mailslot.createFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void Connect()
        {
            _ReadHandle = CreateMailslot("\\\\.\\mailslot\\" + _SlotName, 0, 0,
                                          IntPtr.Zero);
        }

        public static string getMessage()

        {
            uint bytesWritten = 0;
            //string message = "";
            int overL;
            byte[] data = new byte[64];
            ReadFile(_ReadHandle, out data, (uint)data.Length, out bytesWritten, ref stnOverlap);
            //GetMailslotInfo(_ReadHandle, 0, ref iMsgSize, IntPtr.Zero, IntPtr.Zero);
            //int dataL = data.Length;
            string message = Encoding.UTF8.GetString(data);
            //builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            //message = builder.ToString();
            return iMsgSize.ToString();
        }

        public static void createFile()
        {
            string message = "df";
            byte[] data = new byte[64];
            data = Encoding.Unicode.GetBytes(message);
            _WriteHandle = CreateFile("\\\\" + "*" + "\\mailslot\\" + _SlotName,
                      FileAccess.Write, FileShare.Read, 0, FileMode.Open, 0, IntPtr.Zero);
            bool result = WriteFile(_WriteHandle, data, (uint)data.Length, out bytesWritten, ref stnOverlap);
            //label1.Text = _WriteHandle.ToString();
        }

    }
}
