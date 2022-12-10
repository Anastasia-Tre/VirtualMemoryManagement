using System;
using System.Linq;
using VirtualMemoryManagement.PageReplacementAlgorithms;

namespace VirtualMemoryManagement
{
    internal class Kernel
    {
        private readonly IPageReplacementAlgorithm _pageReplacementAlgorithm;
        private readonly MMU MMU;
        private PhysicalPage[] _physicalPages;

        public Kernel(IPageReplacementAlgorithm pageReplacementAlgorithm)
        {
            _pageReplacementAlgorithm = pageReplacementAlgorithm;
            MMU = new MMU();

            _physicalPages = new PhysicalPage[PhysicalPage.MaxPhysicalPagesNumber];
            for (var i = 0; i < PhysicalPage.MaxPhysicalPagesNumber; i++)
            {
                _physicalPages[i] = new PhysicalPage(i);
            }
        }

        private PhysicalPage GetPhysicalPage(VirtualPage virtualPage)
        {
            PhysicalPage page;
            try
            {
                MMU.CheckPresenceBit(virtualPage);
                page = _physicalPages.FirstOrDefault(p =>
                    p.Id == virtualPage.PhysicalPageNumber);
            } catch (PageFaultException e)
            {
                Console.WriteLine("PageFaultException");
                page = _pageReplacementAlgorithm.GetFreePhysicalPage();
                MMU.SetPresenceBit(virtualPage);
                MMU.SetPhysicalPageNumber(virtualPage, page.Id);
            }
            return page;
        }

        public void ReadPage(VirtualPage virtualPage)
        {
            var page = GetPhysicalPage(virtualPage);
            MMU.SetReferenceBit(virtualPage);
            // smt do with page
        }

        public void WritePage(VirtualPage virtualPage)
        {
            var page = GetPhysicalPage(virtualPage);
            MMU.SetReferenceBit(virtualPage);
            MMU.SetModificationBit(virtualPage);
            // smt do with page
        }
    }
}
