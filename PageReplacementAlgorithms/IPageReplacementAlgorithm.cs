﻿using System.Collections.Generic;

namespace VirtualMemoryManagement.PageReplacementAlgorithms
{
    internal interface IPageReplacementAlgorithm
    {
        public PhysicalPage GetFreePhysicalPage(List<PhysicalPage> freePhysicalPages, List<PhysicalPage> busyPhysicalPages);
    }
}
