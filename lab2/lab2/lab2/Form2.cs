using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            Process[] processes = Process.GetProcesses();


            Process process2 = Process.GetCurrentProcess();
            ProcessThreadCollection processThreads = process2.Threads;


            dataGridView1.RowCount = processes.Length;
            dataGridView1.ColumnCount = 5;
            


            dataGridView1.Columns[0].HeaderText = "Name";
            //dataGridView1.Columns[0].Width = Convert.ToInt32(dataGridView1.Width*0.5);
            dataGridView1.Columns[1].HeaderText = "Id";
            dataGridView1.Columns[2].HeaderText = "Handle count";
            dataGridView1.Columns[3].HeaderText = "Base priority";
            dataGridView1.Columns[4].HeaderText = "Threads count";

            int count = 0;



            foreach (Process process in processes)
            {
                //listView1.Items.Add(process.ToString());
                //listView1.Items.Add(process.ToString());
                dataGridView1.Rows[count].Cells[0].Value = process.ProcessName.ToString();
                dataGridView1.Rows[count].Cells[1].Value = process.Id.ToString();
                dataGridView1.Rows[count].Cells[2].Value = process.HandleCount.ToString();
                dataGridView1.Rows[count].Cells[3].Value = process.BasePriority.ToString();
                dataGridView1.Rows[count].Cells[4].Value = process.Threads.Count.ToString();
                count++;
            }

            



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;

            textBox1.Text = dataGridView1.Rows[row].Cells[column].Value.ToString();

            Process[] processes = Process.GetProcessesByName(textBox1.Text);

            Process process = processes[0];

            ProcessThreadCollection processThreads = process.Threads;

            dataGridView2.RowCount = processThreads.Count;
            dataGridView2.ColumnCount = 4;

            dataGridView2.Columns[0].HeaderText = "Id";
            dataGridView2.Columns[1].HeaderText = "Base priority";
            dataGridView2.Columns[2].HeaderText = "State";

            int count = 0;

            foreach (ProcessThread thread in processThreads)
            {
                dataGridView2.Rows[count].Cells[0].Value = thread.Id.ToString();
                dataGridView2.Rows[count].Cells[1].Value = thread.BasePriority.ToString();
                dataGridView2.Rows[count].Cells[2].Value = thread.ThreadState.ToString();
                count++;
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
