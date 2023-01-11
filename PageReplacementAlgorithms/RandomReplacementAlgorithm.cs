using System;
using System.Collections.Generic;

namespace VirtualMemoryManagement.PageReplacementAlgorithms
{
    internal class RandomReplacementAlgorithm : IPageReplacementAlgorithm
    {
        public PhysicalPage GetFreePhysicalPage(List<PhysicalPage> freePhysicalPages, List<PhysicalPage> busyPhysicalPages)
        {
            PhysicalPage page;
            if (freePhysicalPages.Count != 0)
            {
                page = freePhysicalPages[new Random().Next(freePhysicalPages.Count)];
            }
            else
            {
                page = busyPhysicalPages[new Random().Next(busyPhysicalPages.Count)];
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
            return "RandomReplacementAlgorithm";
        }
    }
}
