﻿using System;
using System.Collections.Generic;
using System.Linq;
using VirtualMemoryManagement.PageReplacementAlgorithms;

namespace VirtualMemoryManagement
{
    internal class Kernel
    {
        private readonly IPageReplacementAlgorithm _pageReplacementAlgorithm;
        private readonly MMU MMU;

        private readonly List<PhysicalPage> _freePhysicalPages;
        private readonly List<PhysicalPage> _busyPhysicalPages;
        private readonly List<VirtualPage> _virtualPages;

        private int _time;

        public Kernel(IPageReplacementAlgorithm pageReplacementAlgorithm)
        {
            _pageReplacementAlgorithm = pageReplacementAlgorithm;
            MMU = new MMU();

            Console.WriteLine($"Create {PhysicalPage.MaxPhysicalPagesNumber} physical pages");
            _freePhysicalPages = new List<PhysicalPage>();
            _busyPhysicalPages = new List<PhysicalPage>();
            for (var i = 0; i < PhysicalPage.MaxPhysicalPagesNumber; i++)
            {
                _freePhysicalPages.Add(new PhysicalPage(i));
            }

            Console.WriteLine($"Create {VirtualPage.MaxVirtualPagesNumber} virtual pages");
            _virtualPages = new List<VirtualPage>();
            for (var i = 0; i < VirtualPage.MaxVirtualPagesNumber; i++)
            {
                _virtualPages.Add(new VirtualPage());
            }
        }

        public Process GenerateProcess()
        {
            var pageTableSize = new Random().Next(VirtualPage.MaxVirtualPagesNumber);
            var pageTable = new PageTable(pageTableSize).FillPageTable(_virtualPages);

            var workingSetSize = new Random().Next(pageTableSize);
            var workingSet = new WorkingSet(workingSetSize).ChangeWorkingSet(pageTable);
            
            return new Process(pageTable, workingSet);
        }

        public bool StartProcess(Process process)
        {
            for (var i = 0; i < process.WorkingTime; i++)
            {
                if (i == process.WorkingTime / 2)
                {
                    Console.WriteLine($"Change working set of process\n");
                    process.WorkingSet.ChangeWorkingSet(process.PageTable);
                }

                ActionWithMemory(process);
            }
            return true;
        }

        private void ActionWithMemory(Process process)
        {
            var page = process.GetVirtualPage();

            var action = new Random().Next(2);
            if (action == 1)
            {
                ReadPage(page);
            } else
            {
                WritePage(page);
            }
        }

        public void ReadPage(VirtualPage virtualPage)
        {
            Console.WriteLine("Read Action");
            Console.WriteLine($"Virtual page attributes before action - {virtualPage}");
            var page = GetPhysicalPage(virtualPage);
            MMU.SetReferenceBit(virtualPage);
            _time++;
            Console.WriteLine($"Virtual page attributes after action - {virtualPage}\n");
            // smt do with page
        }

        public void WritePage(VirtualPage virtualPage)
        {
            Console.WriteLine("Write Action");
            Console.WriteLine($"Virtual page attributes before action - {virtualPage}");
            var page = GetPhysicalPage(virtualPage);
            MMU.SetReferenceBit(virtualPage);
            MMU.SetModificationBit(virtualPage);
            _time++;
            Console.WriteLine($"Virtual page attributes after action - {virtualPage}\n");
            // smt do with page
        }

        private PhysicalPage GetPhysicalPage(VirtualPage virtualPage)
        {
            PhysicalPage page;
            try
            {
                MMU.CheckPresenceBit(virtualPage);
                page = _freePhysicalPages.FirstOrDefault(p =>
                    p.Id == virtualPage.PhysicalPageNumber);
            } catch (PageFaultException e)
            {
                Console.WriteLine("PageFaultException");
                page = _pageReplacementAlgorithm.GetFreePhysicalPage(_freePhysicalPages);

                _freePhysicalPages.Remove(page);
                if (!_busyPhysicalPages.Contains(page))
                    _busyPhysicalPages.Add(page);

                MMU.MapVirtualAndPhysicalPages(virtualPage, page);
                MMU.SetPresenceBit(virtualPage);
            }
            return page;
        }
    }
}
