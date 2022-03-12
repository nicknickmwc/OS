using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class ProcCard
    {


        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;      // Сообщает то же значение, что и параметр pvAddress,
                                            // но округленное до ближайшего меньшего адреса, кратного размеру страницы
            public IntPtr AllocationBase;   // Идентифицирует базовый адрес региона, включающего в себя адрес,
                                            // указанный в параметре pvAddress
            public int AllocationProtect;   // Идентифицирует атрибут защиты, присвоенный региону при его резервировании
            public IntPtr RegionSize;       // Сообщаем суммарный размер (в байтах) группы
            public int State;               // Сообщает состояние (MEM_FRFF, MFM_RFSFRVE или MEM_COMMIT) всех смежных страниц
            public int Protect;             // Идентифицирует атрибут защиты (PAGE *) всех смежных страниц
            public int Type;                // Идентифицирует тип физической памяти (MEM_IMAGE, MEM_MAPPED или MEM PRIVATE)
        }

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern UIntPtr VirtualQueryEx         // сообщает информацию о памяти в другом процессе
                    (
                        IntPtr hProcess,                    // Дескриптора процесса
                        IntPtr pvAddress,                   // адрес виртуальной памяти
                        out MEMORY_BASIC_INFORMATION pmbi,  // это адрес структуры MEMORY_BASIC_INFORMATION,
                                                            // которую надо создать перед вызовом функции
                        int dwLength                        // задает размер структуры MEMORY_BASIC_INFORMATION
                    );


        Process process;

        public ProcCard(Process process) { this.process = process; }

        public List<string> baseAdresses = new List<string>();
        public List<string> AllocationBase = new List<string>();
        public List<string> RegionSize = new List<string>();
        public List<string> State = new List<string>();
        public List<string> AllocationProtect = new List<string>();
        public List<string> Protect = new List<string>();
        public List<string> Type = new List<string>();

        public int maxCount()
        {
            int count = 0;

            if(this.baseAdresses.Count > count)
            {
                count = this.baseAdresses.Count;
            }

            if(this.AllocationBase.Count > count)
            {
                count= this.AllocationBase.Count;
            }
            if(this.RegionSize.Count > count)
            {
                count= this.RegionSize.Count;
            }
            if(this.State.Count > count)
            {
                count= this.State.Count;
            }
            if(this.AllocationProtect.Count > count)
            {
                count= this.AllocationProtect.Count;
            }
            if(this.Protect.Count > count)
            {
                count= this.Protect.Count;
            }
            if(this.Type.Count > count)
            {
                count= this.Type.Count;
            }
            return count;
        }

        public void getProcCard()
        {
            IntPtr ptr0 = this.process.Handle;  // Получение дескриптора процесса
            long ptr1Count = 0x00000000; // адресс после недоступной зоны
            MEMORY_BASIC_INFORMATION b; // Объявляем структуру
            IntPtr ptr1 = new IntPtr(ptr1Count);

            while (ptr1Count <= 0x7FFE0000)
            {
                VirtualQueryEx(ptr0, ptr1, out b, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
                this.baseAdresses.Add(b.BaseAddress.ToString("X8"));
                this.AllocationBase.Add(b.AllocationBase.ToString("X8"));
                this.RegionSize.Add(b.RegionSize.ToString("X8"));
                this.State.Add(b.State.ToString("X6"));
                this.AllocationProtect.Add(b.AllocationProtect.ToString("X3"));
                this.Protect.Add(b.Protect.ToString("X3"));
                this.Type.Add(b.Type.ToString("X7"));
                ptr1Count = ptr1Count + (int)b.RegionSize;
                ptr1 = (IntPtr)ptr1Count;
            }
        }

    }
}
