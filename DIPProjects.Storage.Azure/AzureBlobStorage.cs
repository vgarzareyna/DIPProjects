using DIPProjects.Documents;

namespace DIPProjects.Storage.Azure
{
    public class AzureBlobStorage(string container) : IReadWriteStorage
    {
        public string Read(string name)
        {
            Console.WriteLine($"[Azure] Downloading blob '{name}' from container '{container}'.");
            return $"<content of {name}>";
        }

        public void Write(string name, string content)
        {
            Console.WriteLine($"[Azure] Uploading blob '{name}' to container '{container}'.");
        }

        public void Delete(string name)
        {
            Console.WriteLine($"[Azure] Deleting blob '{name}' from container '{container}'.");
        }
    }
}
