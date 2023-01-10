namespace VirtualMemoryManagement
{
    internal class VirtualPage
    {
        public const int MaxVirtualPagesNumber = 50;

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
