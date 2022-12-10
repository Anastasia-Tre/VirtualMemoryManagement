

namespace VirtualMemoryManagement
{
    internal class PageTable
    {
        public VirtualPage[] Pages;

        public PageTable(int size)
        {
            Pages = new VirtualPage[size];
            for (var i = 0; i < size; i++)
            {
                Pages[i] = new VirtualPage();
            }
        }
    }
}
