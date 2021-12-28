using System;
using System.Diagnostics;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("ConsoleServer.exe");
            Process.Start("Client.exe");
        }
    }
}