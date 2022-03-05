using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace lab3
{
    internal class Class1
    {
        public int x = 1;

        object obj = new object();

        public List<int> list = new List<int>();

        public void sum()
        {
            lock (obj)
            {
                for (int i = 0; i < 4; i++)
                {
                    list.Add(x);
                    this.x++;
                    //Thread.Sleep(100);
                    //listView.Items.Add(this.x.ToString());
                }
                //listView.Items.Add("/////////////");
            }
        }

        public void mult()
        {
            lock (obj) {
                for (int i = 0; i < 3; i++)
                {
                    list.Add(x);
                    this.x *= this.x;
                    //listView.Items.Add(this.x.ToString());
                }
                //listView.Items.Add("/////////////");
            }
        }

       

    }
}
