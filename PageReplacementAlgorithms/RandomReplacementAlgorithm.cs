using System;
using System.Collections.Generic;

namespace VirtualMemoryManagement.PageReplacementAlgorithms
{
    internal class RandomReplacementAlgorithm : IPageReplacementAlgorithm
    {
        public PhysicalPage GetFreePhysicalPage(List<PhysicalPage> physicalPages)
        {
            return physicalPages[new Random().Next(physicalPages.Count)];
        }

        // add if no free page: save page to file system
    }
}
