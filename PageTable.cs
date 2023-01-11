using System;
using System.Collections.Generic;
using System.Linq;

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

        public PageTable FillPageTable(List<VirtualPage> virtualPages)
        {
            Pages = new VirtualPage[Size];
            for (var i = 0; i < Size; i++)
            {
                VirtualPage page;
                do
                {
                    page = virtualPages[new Random().Next(Size)];
                } while (Pages.Contains(page));
                Pages[i] = page.New();
            }

            return this;
        }

        public VirtualPage GetRandomVirtualPage()
        {
            return Pages[new Random().Next(Size)];
        }
    }
}
