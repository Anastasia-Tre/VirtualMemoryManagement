﻿namespace VirtualMemoryManagement
{
    internal class VirtualPage
    {
        public const int MaxVirtualPagesNumber = 50;

        public int PresenceBit;
        public int ReferenceBit;
        public int ModificationBit;
        public int? PhysicalPageNumber = null;

        public VirtualPage()
        {
            PresenceBit = 0;
            ReferenceBit = 0;
            ModificationBit = 0;
        }

        public VirtualPage New()
        {
            PresenceBit = 0;
            ReferenceBit = 0;
            ModificationBit = 0;
            PhysicalPageNumber = null;
            return this;
        }

        public override string ToString()
        {
            return $"P:{PresenceBit} " + 
                   $"R:{ReferenceBit} " + 
                   $"M:{ModificationBit} " + 
                   $"PPN:{PhysicalPageNumber}";
        }
    }
}
