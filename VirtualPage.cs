namespace VirtualMemoryManagement
{
    internal class VirtualPage
    {
        public int PresenceBit;
        public int ReferenceBit;
        public int ModificationBit;
        public int PhysicalPageNumber;
    }
}
