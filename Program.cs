using System;
using VirtualMemoryManagement.PageReplacementAlgorithms;

namespace VirtualMemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RandomReplacementAlgorithm\n");

            var algorithm = new RandomReplacementAlgorithm();
            var kernel = new Kernel(algorithm);

            var processesNumber = new Random().Next(5, Process.MaxProcessesNumber);
            Console.WriteLine($"Create {processesNumber} processes\n");
            for (var i = 0; i < processesNumber; i++)
            {
                var process =  kernel.GenerateProcess();
                Console.WriteLine($"Start the process {i + 1} with characteristics {process}");
                kernel.StartProcess(process);
                Console.WriteLine($"Finish the process {i + 1}\n");
            }



        }
    }
}
