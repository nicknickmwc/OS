using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectToServer connectToServer1 = new ConnectToServer(8888);
            //if (true)
            //{
                RequestHandler handler = new RequestHandler(connectToServer1.getSystemInfo());
                handler.getOutInfo(2, 14);
                lastErrTB.Text = handler.getEr();
                cursorXTB.Text = handler.getX();
                cursorYTB.Text = handler.getY();
                //lastErrTB.Text = connectToServer1.getMessage();
            //}
        }

        private void server2BT_Click(object sender, EventArgs e)
        {
            ConnectToServer connectToServer1 = new ConnectToServer(8887);
            RequestHandler handler = new RequestHandler(connectToServer1.getSystemInfo());
            handler.getOutInfo(1, 14);
            phRamTB.Text = handler.getY();
            virtRamTB.Text = handler.getX();    
        }
    }
}
