using System;

namespace VirtualMemoryManagement
{
    internal class WorkingSet
    {
        public VirtualPage[] Pages;

        public WorkingSet()
        {
            var size = new Random().Next(5, 15);
        }
    }
}
