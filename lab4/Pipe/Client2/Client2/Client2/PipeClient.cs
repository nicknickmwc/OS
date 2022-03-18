﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client2
{
    internal class PipeClient
    {
        public void sendMessage(TextBox textBox, ListView listView)
        {

            using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", "labPipeTwo", PipeDirection.InOut))
            using (BinaryWriter binaryWriter = new BinaryWriter(pipeClientStream))
            using (BinaryReader binaryReader = new BinaryReader(pipeClientStream))
            {
                pipeClientStream.Connect();
                binaryWriter.Write(textBox.Text);
                string message = binaryReader.ReadString();
                listView.Items.Add(message);
                pipeClientStream.Close();
            }
        }

        public void getMessage(ListView listView)
        {
            using (NamedPipeClientStream pipeClientStream = new NamedPipeClientStream(".", "labPipeTwo", PipeDirection.InOut))
            using (BinaryWriter binaryWriter = new BinaryWriter(pipeClientStream))
            using (BinaryReader binaryReader = new BinaryReader(pipeClientStream))
            {
                pipeClientStream.Connect();
                listView.Items.Add(binaryReader.ReadString());
                pipeClientStream.Close();
            }
        }
    }
}
