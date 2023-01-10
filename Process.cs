using System;

namespace VirtualMemoryManagement
{
    internal class Process
    {
        public const int MaxProcessesNumber = 10;
        public const int MaxWorkingTime = 20;

        public PageTable PageTable;
        public WorkingSet WorkingSet;
        public int WorkingTime;

        public Process(WorkingSet workingSet)
        {
            WorkingTime = new Random().Next(MaxWorkingTime);
            WorkingSet = workingSet;
            PageTable = new PageTable(); 
        }

    }
}
