using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Server2
{
    internal class SystemInfo
    {
        ulong totalVisMemory;
        ulong totalVirtMemory;
        ulong freePhysMemory;
        ulong freeVirtMemory;
        ulong usingPhysRam;
        ulong usingVirtRam;

        public SystemInfo()
        {
            ManagementObjectSearcher memMonitor =    //запрос к WMI для получения памяти ПК
            new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory, FreeVirtualMemory, TotalVirtualMemorySize FROM Win32_OperatingSystem");

            foreach (ManagementObject management in memMonitor.Get())
            {
                totalVisMemory = Convert.ToUInt64(management["TotalVisibleMemorySize"]);
                totalVirtMemory = Convert.ToUInt64(management["TotalVirtualMemorySize"]);
                freePhysMemory = Convert.ToUInt64(management["FreePhysicalMemory"]);
                freeVirtMemory = Convert.ToUInt64(management["FreeVirtualMemory"]);
            }
            usingPhysRam = (ulong)((totalVisMemory - freePhysMemory)*100 / totalVisMemory);
            usingVirtRam = (ulong)((totalVirtMemory - freeVirtMemory)*100 / totalVirtMemory);
        }
        public string getUsingPhysRam() { return Convert.ToString(usingPhysRam); }
        public string getUsingVirtRam() { return Convert.ToString(usingVirtRam); }
        public string getfreePhysMemory() { return Convert.ToString(freePhysMemory); }
        public string gettotalVisMemory() { return Convert.ToString(totalVisMemory); }
    }
}
