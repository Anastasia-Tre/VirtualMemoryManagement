using System;
using System.Collections.Generic;
using VirtualMemoryManagement.PageReplacementAlgorithms;

namespace VirtualMemoryManagement
{
    internal class Program
    {
        static Dictionary<IPageReplacementAlgorithm, int> AlgorithmsComparison;
        static Dictionary<IPageReplacementAlgorithm, List<Process>> WorkingSetSizeComparison;

        static void Main(string[] args)
        {
            AlgorithmsComparison = new Dictionary<IPageReplacementAlgorithm, int>();
            WorkingSetSizeComparison = new Dictionary<IPageReplacementAlgorithm, List<Process>>();

            var processesNumber = new Random().Next(2, Process.MaxProcessesNumber);
            Console.WriteLine("\nRandomReplacementAlgorithm\n");
            TestAlgorithm(new RandomReplacementAlgorithm(), processesNumber);

            Console.WriteLine("\nWSClockAlgorithm\n");
            TestAlgorithm(new WSClockAlgorithm(), processesNumber);

            Console.WriteLine($"\nResults comparison\n");
            Console.WriteLine($"Algorithm - Number of page faults");
            foreach (var algorithm in AlgorithmsComparison)
            {
                Console.WriteLine($"{algorithm.Key} - {algorithm.Value}");
            }

            Console.WriteLine($"\nSize of working set - Number of page faults");
            foreach (var algorithm in WorkingSetSizeComparison)
            {
                Console.WriteLine($"\n{algorithm.Key}");
                foreach (var process in algorithm.Value)
                {
                    Console.WriteLine($"{process.WorkingSet.Pages.Length} - {process.PageFaultCount}");
                }
            }


        }

        static void TestAlgorithm(IPageReplacementAlgorithm algorithm, int processesNumber)
        {
            AlgorithmsComparison.Add(algorithm, 0);
            WorkingSetSizeComparison.Add(algorithm, new List<Process>());

            var kernel = new Kernel(algorithm);

            Console.WriteLine($"Create {processesNumber} processes\n");
            for (var i = 0; i < processesNumber; i++)
            {
                var process = kernel.GenerateProcess();
                Console.WriteLine($"Start the process {i + 1} with characteristics - {process}");
                kernel.StartProcess(process);
                Console.WriteLine($"Finish the process {i + 1}");
                WorkingSetSizeComparison[algorithm].Add(process);
                Console.WriteLine($"Total number of page faults for process = {process.PageFaultCount}\n");
            }

            AlgorithmsComparison[algorithm] = kernel.PageFaultCount;
            Console.WriteLine($"Total number of page faults = {kernel.PageFaultCount}\n");
        }


    }
}
