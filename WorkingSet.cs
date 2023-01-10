using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualMemoryManagement
{
    internal class WorkingSet
    {
        public VirtualPage[] Pages;
        private readonly int _size;

        public WorkingSet(int size)
        {
            _size = size;
        }

        public WorkingSet ChangeWorkingSet(List<VirtualPage> allVirtualPages)
        {
            Pages = new VirtualPage[_size];
            for (var i = 0; i < _size; i++)
            {
                VirtualPage page;
                do
                {
                    page = allVirtualPages[new Random().Next(allVirtualPages.Count)];
                } while (Pages.Contains(page));
                Pages[i] = page;
            }

            return this;
        }

        public VirtualPage GetRandomVirtualPage()
        {
            return Pages[new Random().Next(_size)];
        }
    }
}
