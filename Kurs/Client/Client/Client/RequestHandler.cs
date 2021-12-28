using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal class RequestHandler
    {
        string message="";
        string X = "";
        string Y = "";
        string er = "";

        public RequestHandler(string message) { this.message = message; }

        public string getEr() { return this.er; }

        public string getX() { return this.X; }

        public string getY() { return this.Y; }

        public int volOfRequest() //На сколько запросов ответил сервер
        {
            return Convert.ToInt32(this.message[12]);
        }

        public void getOutInfo(int vol, int index) //Распределяем данные из ответа
        {
            string msg = this.message.Substring(index);
            if (vol==1)
            {
                int a = 0;
                while (msg[a] !=';')
                {
                    this.X+=msg[a];
                    a += 1;
                }
                this.Y=msg.Substring(a+1);
            }
            if (vol == 2)
            {
                int a = 0;
                while (msg[a]!='$')
                {
                    this.er+=msg[a];
                    a += 1;
                }
                getOutInfo(1, index + a + 1);
            }
        }
    }
}
