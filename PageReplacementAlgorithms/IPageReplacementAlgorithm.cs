namespace VirtualMemoryManagement.PageReplacementAlgorithms
{
    internal interface IPageReplacementAlgorithm
    {
        public PhysicalPage GetFreePhysicalPage();
    }
}
