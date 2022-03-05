using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace lab3
{
    internal class Class2
    {
        public Mutex mutex1 = new Mutex();

        public Mutex mutex2 = new Mutex();

        public int x = 1;

        public int y = 1;

        object obj = new object();

        public List<int> listX = new List<int>();

        public List<int> listY = new List<int>();

        public void sum()
        {
            mutex1.WaitOne();
                for (int i = 0; i < 4; i++)
                {
                    listX.Add(x);
                    listY.Add(y);
                    this.x++;
                    this.y++;
                //Thread.Sleep(100);
                //listView.Items.Add(this.x.ToString());
            }
                mutex1.ReleaseMutex();
                //listView.Items.Add("/////////////");
        }

        public void mult()
        {
            mutex1.WaitOne();
                for (int i = 0; i < 3; i++)
                {
                    listX.Add(x);
                    this.x *= this.x;
                    //listView.Items.Add(this.x.ToString());
                }
            //listView.Items.Add("/////////////");
            mutex1.ReleaseMutex();
        }
        public void mult1()
        {
            mutex2.WaitOne();
            for (int i = 0; i < 3; i++)
            {
                listY.Add(y);
                this.y *= this.y;
                //listView.Items.Add(this.x.ToString());
            }
            //listView.Items.Add("/////////////");
            mutex2.ReleaseMutex();
        }



    }
}
