using DllExporter.Core;
using System;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exportor exportor = new Exportor();

            exportor.Export(@"C:\Users\depin\Desktop\appeon.coreservice.data.0.6.2-alpha\lib\netstandard2.0\Appeon.CoreService.Data.dll");

            Console.ReadKey();
        }
    }
}
