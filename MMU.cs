using System;

namespace VirtualMemoryManagement
{
    internal class MMU
    {
        public bool CheckPresenceBit(VirtualPage virtualPage)
        {
            if (virtualPage.PresenceBit == 0)
            {
                throw new PageFaultException();
            }
            return true;
        }

        public void SetPresenceBit(VirtualPage virtualPage)
        {
            virtualPage.PresenceBit = 1;
        }

        public void SetReferenceBit(VirtualPage virtualPage)
        {
            virtualPage.ReferenceBit++;
            //SetLastUsedTime(virtualPage);
        }

        public void SetModificationBit(VirtualPage virtualPage)
        {
            virtualPage.ModificationBit = 1;
        }

        public void SetPhysicalPageNumber(VirtualPage virtualPage, int pageNumber)
        {
            virtualPage.PhysicalPageNumber = pageNumber;
        }

        public void SetLastUsedTime(VirtualPage virtualPage)
        {
            virtualPage.LastUsedTime = Kernel.Time;
        }

        public void MapVirtualAndPhysicalPages(VirtualPage virtualPage, PhysicalPage physicalPage)
        {
            physicalPage.SetVirtualPage(virtualPage);
            SetPhysicalPageNumber(virtualPage, physicalPage.Id);
        }
    }
}
