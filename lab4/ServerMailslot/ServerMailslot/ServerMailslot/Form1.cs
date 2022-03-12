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

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mailslot.Connect("*");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = Mailslot.getMessage();
            //Thread.Sleep(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mailslot.createFile();
        }
    }
}
