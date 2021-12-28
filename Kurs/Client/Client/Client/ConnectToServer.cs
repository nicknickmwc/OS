using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    internal class ConnectToServer
    {
        const string address = "127.0.0.1";
        int port;
        //string message;

        public ConnectToServer(int port)
        {
            this.port = port;
        }

        public string getSystemInfo()
        {
            string message = "getSystemInfo";
            TcpClient tcpClient = null;
            
                tcpClient = new TcpClient(address,port);
                NetworkStream stream = tcpClient.GetStream();
                while (true)
                {
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // получаем ответ
                    data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    tcpClient.Close();
                    return message;
                    
                }
            
        }
        //public string getMessage() { return message; }
    }
}
