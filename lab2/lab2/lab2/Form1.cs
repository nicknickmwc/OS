using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace lab2
{
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
   IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
   uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);

        [Flags]
        public enum DuplicateOptions : uint
        {
            DUPLICATE_CLOSE_SOURCE = (0x00000001),// Closes the source handle. This occurs regardless of any error status returned.
            DUPLICATE_SAME_ACCESS = (0x00000002), //Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.
        }



        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            ProcessAccessFlags processAccess,
            bool bInheritHandle,
            int processId
        );

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

   
            //////////////////////////////task2
       


            Process process = new Process();

            textBox1.Text = Process.GetCurrentProcess().Id.ToString();

            textBox2.Text = GetCurrentProcess().ToString();

            IntPtr duplicateHandle;

            IntPtr openProcess;

            DuplicateHandle(GetCurrentProcess(), GetCurrentProcess(), GetCurrentProcess(), 
               out duplicateHandle, 0, false, ((uint)DuplicateOptions.DUPLICATE_SAME_ACCESS));

            textBox3.Text = duplicateHandle.ToString();

            openProcess = OpenProcess(ProcessAccessFlags.All, false, Process.GetCurrentProcess().Id);

            textBox4.Text = openProcess.ToString();

            textBox5.Text = CloseHandle(duplicateHandle).ToString();

            textBox6.Text = CloseHandle(openProcess).ToString();


            //////////////////////////////task2
            




            //////////////////////////////task1


            Process process1 = Process.GetCurrentProcess();

            ProcessModuleCollection modules = process1.Modules;


            foreach (ProcessModule module in modules)
            {
                listView1.Items.Add(module.FileName.ToString());
                listView2.Items.Add(module.ModuleName.ToString());
            }

            task1(textBox7, textBox8, textBox9);


            //////////////////////////////task1


        }

        public static void task1(TextBox handleBox, TextBox fullNameBox, TextBox nameBox)
        {

            Process process = Process.GetCurrentProcess();
            ProcessModuleCollection modules = process.Modules;

            switch (handleBox.Text)
            {
                case "":
                    switch (fullNameBox.Text)
                    {
                        case "":
                            foreach (ProcessModule module in modules)
                            {
                                if (module.ModuleName.ToString() == nameBox.Text)
                                {
                                    handleBox.Text = module.BaseAddress.ToString();
                                    fullNameBox.Text = module.FileName.ToString();
                                }
                            }
                            break;

                        default:
                            foreach (ProcessModule module in modules)
                            {
                                if (module.FileName.ToString() == fullNameBox.Text)
                                {
                                    handleBox.Text = module.BaseAddress.ToString();
                                    nameBox.Text = module.ModuleName.ToString();
                                }
                            }
                            break;
                    }
                    break;
                default:
                    foreach (ProcessModule module in modules)
                    {
                        if (module.BaseAddress.ToString() == handleBox.Text)
                        {
                            nameBox.Text = module.ModuleName.ToString();
                            fullNameBox.Text = module.FileName.ToString();
                        }
                    }
                    break;
            }
                    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
