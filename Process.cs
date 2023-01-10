using System;
using System.Diagnostics;

namespace VirtualMemoryManagement
{
    internal class Process
    {
        public const int MaxProcessesNumber = 10;
        public const int MaxWorkingTime = 20;

        public PageTable PageTable;
        public WorkingSet WorkingSet;
        public int WorkingTime;

        public Process(PageTable pageTable, WorkingSet workingSet)
        {
            WorkingTime = new Random().Next(MaxWorkingTime);
            WorkingSet = workingSet;
            PageTable = pageTable;
        }

        public VirtualPage GetVirtualPage()
        {
            // 90% звернень до сторінок з робочого набору, 10% звернень до будь-яких сторінок
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

    }
}
