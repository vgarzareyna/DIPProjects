namespace DIPProjects.Documents
{
    // Depends only on reading. A test fake needs one method, not three.
    public class DocumentViewer(IReadStorage storage)
    {
        public void Show(string name)
        {
            Console.WriteLine($"Viewer: showing {storage.Read(name)}");
        }
    }
}
