ManagementObjectSearcher ramMonitor =    //запрос к WMI для получения памяти ПК
            new ManagementObjectSearcher("SELECT TotalVisibleMemorySize, FreePhysicalMemory, FreeVirtualMemory, TotalVirtualMemorySize FROM Win32_OperatingSystem"); 
 
foreach (ManagementObject objram in ramMonitor.Get())
                {
                    ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);    //общая память ОЗУ
                    ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);         //занятная память = (total-free)
                    Console.WriteLine(((busyRam * 100) / totalRam));       //вычисляем проценты занятой памяти
                }
