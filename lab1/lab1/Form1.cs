using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace lab1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
        

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime([In] ref SYSTEMTIME st);

        [DllImport("user32.dll")]
        public static extern uint GetDoubleClickTime();

        [DllImport("kernell32.dll")]
        public static extern uint GetOEMCP();


        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = System.Windows.Forms.SystemInformation.ComputerName;
            textBox2.Text = Environment.UserName;

            textBox3.Text = Environment.SystemDirectory;
            textBox4.Text = Environment.OSVersion.ToString();

            textBox5.Text = GetSystemMetrics(0).ToString();
            textBox6.Text = GetSystemMetrics(1).ToString();

            textBox7.Text = System.Windows.Forms.SystemInformation.CursorSize.ToString();
            if (System.Windows.Forms.SystemInformation.DragFullWindows == true)
            {
                textBox8.Text = "Включено";
            }
            else
            {
                textBox8.Text = "Не включено";
            }

            Color startColor = Color.SkyBlue;
            textBox9.BackColor = startColor;
            Color endColor = Color.FromArgb(startColor.R +70, startColor.G, startColor.B-30);
            textBox10.BackColor = endColor;

            textBox11.Text = DateTime.Now.ToString();

            textBox12.Text = GetDoubleClickTime().ToString();

            StreamReader streamReader = new StreamReader("FileCheck.txt");
            textBox13.Text = streamReader.CurrentEncoding.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = Convert.ToInt16("2000");
            st.wMonth = Convert.ToInt16("02");
            st.wDay = Convert.ToInt16("22");
            st.wHour = Convert.ToInt16(DateTime.UtcNow.Hour);
            st.wMinute = Convert.ToInt16(DateTime.UtcNow.Minute);
            st.wSecond = Convert.ToInt16(DateTime.UtcNow.Second);
            st.wMilliseconds = Convert.ToInt16(DateTime.UtcNow.Millisecond);
            SetSystemTime(ref st);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
