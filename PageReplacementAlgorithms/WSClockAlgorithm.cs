

using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualMemoryManagement.PageReplacementAlgorithms
{
    internal class WSClockAlgorithm : IPageReplacementAlgorithm
    {
        private int _lastInd;
        private const int TimeDelta = 5;

        public PhysicalPage GetFreePhysicalPage(List<PhysicalPage> freePhysicalPages, List<PhysicalPage> busyPhysicalPages)
        {
            PhysicalPage page = busyPhysicalPages.FirstOrDefault();
            if (freePhysicalPages.Count != 0)
            {
                page = freePhysicalPages[new Random().Next(freePhysicalPages.Count)];
            } else
            {
                for (var i = _lastInd; i < busyPhysicalPages.Count; i++)
                {
                    if (busyPhysicalPages[i].VirtualPage.ReferenceBit >= 1)
                    {
                        busyPhysicalPages[i].VirtualPage.LastUsedTime = Kernel.Time;
                    }
                    else
                    {
                        if ((Kernel.Time - busyPhysicalPages[i].VirtualPage.LastUsedTime) >= TimeDelta)
                        {
                            page = busyPhysicalPages[i];
                            _lastInd = i + 1;
                            break;
                        }
                    }
                }

                if (page.VirtualPage.ModificationBit != 0)
                {
                    page.SaveToFileSystem();
                    Console.WriteLine($"Save physical page {page.Id} to file system");
                }

                Console.WriteLine($"Release physical page {page.Id}");
            }

            Console.WriteLine($"Decision of algorithm: use physical page {page.Id}");
            return page;
        }

        public override string ToString()
        {
            return "WSClockAlgorithm";
        }
    }
}
