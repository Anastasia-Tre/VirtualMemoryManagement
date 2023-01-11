using System;

namespace VirtualMemoryManagement
{
    internal class Process
    {
        public const int MaxProcessesNumber = 7;
        public const int MaxWorkingTime = 10;

        public PageTable PageTable;
        public WorkingSet WorkingSet;
        public int WorkingTime;

        public int PageFaultCount;

        public Process(PageTable pageTable, WorkingSet workingSet)
        {
            WorkingTime = new Random().Next(5, MaxWorkingTime);
            WorkingSet = workingSet;
            PageTable = pageTable;
        }

        public VirtualPage GetVirtualPage()
        {
            // 90% pages from WorkingSet, 10% - others
            var pageNum = new Random().Next(100);
            VirtualPage page;
            if (pageNum < 90)
            {
                page = WorkingSet.GetRandomVirtualPage();
            } else
            {
                page = PageTable.GetRandomVirtualPage();
            }
            return page;
        }

        public override string ToString()
        {
            return $"Working time: {WorkingTime}; " +
                   $"Size of page table: {PageTable.Pages.Length}; " +
                   $"Size of working set: {WorkingSet.Pages.Length}";
        }
    }
}
