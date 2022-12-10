namespace VirtualMemoryManagement
{
    internal class VirtualPage
    {
        public int PresenceBit;
        public int ReferenceBit;
        public int ModificationBit;
        public int PhysicalPageNumber;

        public VirtualPage()
        {
            PresenceBit = 0;
            ReferenceBit = 0;
            ModificationBit = 0;
        }
    }
}
