using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal class PipeServer
    {

        public void sds()
        {
            string s = "";
            s = "";
        }

        public void serverThreadClient1()
        {
            using (NamedPipeServerStream pipeServerStream = new NamedPipeServerStream("labPipe", PipeDirection.InOut))
            using (BinaryWriter binaryWriter = new BinaryWriter(pipeServerStream))
            using (BinaryReader binaryReader = new BinaryReader(pipeServerStream))
            {
                while (true)
                {
                    pipeServerStream.WaitForConnection();


                    if (pipeServerStream.IsConnected == true)
                    {
                        string message = binaryReader.ReadString();
                        if (message != null)
                        {
                            Form1.messageClient1 = message;
                        }
                        binaryWriter.Write(Form1.messageClient2);
                    }
                    pipeServerStream.WaitForPipeDrain();
                    //Form1.s = "sd";
                    Thread.Sleep(1000);
                    pipeServerStream.Disconnect();
                    Form1.messageClient2 = "";
                }
            }
        }

        public void serverThreadClient2()
        {
            using (NamedPipeServerStream pipeServerStream = new NamedPipeServerStream("labPipeTwo", PipeDirection.InOut))
            using (BinaryWriter binaryWriter = new BinaryWriter(pipeServerStream))
            using (BinaryReader binaryReader = new BinaryReader(pipeServerStream))
            {
                while (true)
                {
                    pipeServerStream.WaitForConnection();

                    if (pipeServerStream.IsConnected == true)
                    {
                        string message = binaryReader.ReadString();
                        if (message != null)
                        {
                            Form1.messageClient2 = message;
                        }
                        binaryWriter.Write(Form1.messageClient1);
                    }
                    pipeServerStream.WaitForPipeDrain();
                    //Form1.s = "sd";
                    Thread.Sleep(1000);
                    pipeServerStream.Disconnect();
                    Form1.messageClient1 = "";
                }
            }
        }
    }
}
