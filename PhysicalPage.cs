namespace VirtualMemoryManagement
{
    internal class PhysicalPage
    {
        public const int MaxPhysicalPagesNumber = 10;

        public int Id;
        public bool IsFree = true;
        public VirtualPage VirtualPage;

        public PhysicalPage(int id)
        {
            Id = id;
        }

        public void SetVirtualPage(VirtualPage virtualPage)
        {
            VirtualPage = virtualPage;
            IsFree = false;
        }

        public void SaveToFileSystem()
        {
            IsFree = true;
            VirtualPage.New();
            VirtualPage = null;
        }
    }
}
