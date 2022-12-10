using System;

namespace VirtualMemoryManagement
{
    internal class Process
    {
        public const int MaxProcessesNumber = 30;

        public PageTable PageTable;
        public WorkingSet WorkingSet;
        public int WorkingTime;

        private readonly int _maxWorkingTime;

        private Kernel _kernel;

        public Process(Kernel kernel)
        {
            _maxWorkingTime = new Random().Next(5, 15);
            PageTable = new PageTable(1); // size of page table?
            _kernel = kernel;
        }

        public void Read(VirtualPage virtualPage)
        {
            _kernel.ReadPage(virtualPage);
        }

        public void Write(VirtualPage virtualPage)
        {
            _kernel.WritePage(virtualPage);
        }

        public bool IsFinished()
        {
            return WorkingTime == _maxWorkingTime;
        }
    }
}
