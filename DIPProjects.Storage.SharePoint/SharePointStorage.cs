using DIPProjects.Documents;

namespace DIPProjects.Storage.SharePoint
{
    // A storage that references Documents and implements its interface.
    // Adding it requires no change in Documents.
    public class SharePointStorage(string siteUrl) : IReadWriteStorage
    {
        public string Read(string name)
        {
            Console.WriteLine($"[SharePoint] Downloading '{name}' from '{siteUrl}'.");
            return $"<content of {name}>";
        }

        public void Write(string name, string content)
        {
            Console.WriteLine($"[SharePoint] Uploading '{name}' to '{siteUrl}'.");
        }

        public void Delete(string name)
        {
            Console.WriteLine($"[SharePoint] Deleting '{name}' from '{siteUrl}'.");
        }
    }
}