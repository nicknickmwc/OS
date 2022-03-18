using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.MemoryMappedFiles;

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
            string s = textBox1.Text;
            MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("MemoryFile", s.Length * 2 + 4);

            using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, s.Length * 2 + 4))
            {
                //запись в разделяемую память
                //запись размера с нулевого байта в разделяемой памяти
                writer.Write(0, s.Length);
                char[] chars = s.ToCharArray();
                //запись сообщения с четвертого байта в разделяемой памяти
                writer.WriteArray<char>(4, chars, 0, chars.Length);
                label1.Text = "Сообщение отправлено";
            }
        }
    }
}
