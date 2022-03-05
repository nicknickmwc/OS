using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int coreObjInt = 0;

        static volatile bool stop;

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            var thread1 = new Thread(() => class1.sum());
            var thread2 = new Thread(() => class1.mult());
            thread1.Start();
            thread2.Start();
            Thread.Sleep(1000);

            for (int i = 0; i<class1.list.Count; i++)
            {
                listView1.Items.Add(class1.list[i].ToString());
            }

        }

        static void coreObj()
        {
            while(!stop)
            {
                coreObjInt++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() => coreObj()).Start();

            Thread.Sleep(2000);

            stop = true;

            listView2.Items.Add(coreObjInt.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class2 class2 = new Class2();
            var thread1 = new Thread(() => class2.sum());
            var thread2 = new Thread(() => class2.mult());
            var thread3 = new Thread(() => class2.mult1());
            thread3.Start();
            thread1.Start();
            thread2.Start();
            Thread.Sleep(1000);

            for (int i = 0; i < class2.listX.Count; i++)
            {
                listView3.Items.Add(class2.listX[i].ToString());
            }
            for (int i = 0; i < class2.listY.Count; i++)
            {
                listView4.Items.Add(class2.listY[i].ToString());
            }

        }
    }
}
