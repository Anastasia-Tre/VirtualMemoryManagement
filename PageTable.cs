

using System;

namespace VirtualMemoryManagement
{
    internal class PageTable
    {
        public VirtualPage[] Pages;
        public int Size;

        public PageTable(int size)
        {
            Size = size;
        }

        public VirtualPage GetRandomVirtualPage()
        {
            return Pages[new Random().Next(Size)];
        }
    }
}
