using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string messageClient1 = "";
        public static string messageClient2 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            PipeServer pipeServer = new PipeServer();
            var thread1 = new Thread(() => pipeServer.serverThreadClient1());
            thread1.Start();
            var thread2 = new Thread(() => pipeServer.serverThreadClient2());
            thread2.Start();
        }
    }
}
