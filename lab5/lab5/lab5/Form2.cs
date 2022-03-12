using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            ulong totalVisMemory=0;
            ulong totalVirtMemory=0;
            ulong freePhysMemory=0;
            ulong freeVirtMemory=0;
            ulong maxProcessMemorySize = 0;
            ulong usingPhysRam=0;
            ulong usingVirtRam=0;

            ManagementObjectSearcher memMonitor =    //запрос к WMI для получения памяти ПК
            new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory, FreeVirtualMemory, TotalVirtualMemorySize, MaxProcessMemorySize FROM Win32_OperatingSystem");

            foreach (ManagementObject management in memMonitor.Get())
            {
                totalVisMemory = Convert.ToUInt64(management["TotalVisibleMemorySize"]) / 1024;
                totalVirtMemory = Convert.ToUInt64(management["TotalVirtualMemorySize"]) / 1024;
                freePhysMemory = Convert.ToUInt64(management["FreePhysicalMemory"]) / 1024;
                freeVirtMemory = Convert.ToUInt64(management["FreeVirtualMemory"]) / 1024;
                maxProcessMemorySize = Convert.ToUInt64(management["MaxProcessMemorySize"]);
            }
            usingPhysRam = (ulong)((totalVisMemory - freePhysMemory) * 100 / totalVisMemory);
            usingVirtRam = (ulong)((totalVirtMemory - freeVirtMemory) * 100 / totalVirtMemory);

            chart1.Series[0].Points.AddY(totalVisMemory);
            chart1.Series[0].Points[0].LegendText = "Всего физической памяти: "+totalVisMemory.ToString();
            chart1.Series[0].Points.AddY(freePhysMemory);
            chart1.Series[0].Points[1].LegendText = "Свободной физической памяти: " + freePhysMemory.ToString();

            chart2.Series[0].Points.AddY(totalVirtMemory);
            chart2.Series[0].Points[0].LegendText = "Всего виртуальной памяти: " + totalVirtMemory.ToString();
            chart2.Series[0].Points.AddY(freeVirtMemory);
            chart2.Series[0].Points[1].LegendText = "Свободной виртуальной памяти: " + freeVirtMemory.ToString();
        }
    }
}
