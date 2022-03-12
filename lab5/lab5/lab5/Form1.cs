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

namespace lab5
{
    public partial class Form1 : Form
    {
        public string nameOfProc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();

            dataGridView1.RowCount = processes.Length;
            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].HeaderText = "Name";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(this.nameOfProc);
            Process process = processes[0];

            ProcCard procCard = new ProcCard(process);
            procCard.getProcCard();

            dataGridView2.RowCount = procCard.maxCount();
            dataGridView2.ColumnCount = 7;

            textBox2.Text = procCard.maxCount().ToString();

            int count = 0;

            foreach (string item in procCard.baseAdresses)
            {
                dataGridView2.Rows[count].Cells[0].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.AllocationBase)
            {
                dataGridView2.Rows[count].Cells[1].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.RegionSize)
            {
                dataGridView2.Rows[count].Cells[2].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.State)
            {
                dataGridView2.Rows[count].Cells[3].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.AllocationProtect)
            {
                dataGridView2.Rows[count].Cells[4].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.Protect)
            {
                dataGridView2.Rows[count].Cells[5].Value = item;
                count++;
            }
            count = 0;
            foreach (string item in procCard.Type)
            {
                dataGridView2.Rows[count].Cells[6].Value = item;
                count++;
            }
            //count = 0;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;

            this.nameOfProc = dataGridView1.Rows[row].Cells[column].Value.ToString();
            textBox1.Text = this.nameOfProc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}
