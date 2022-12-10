

namespace VirtualMemoryManagement
{
    internal class PhysicalPage
    {
        public const int MaxPhysicalPagesNumber = 500;

        public int Id;

        public PhysicalPage(int id)
        {
            Id = id;
        }
    }
}
