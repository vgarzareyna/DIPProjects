namespace DIPProjects.Documents
{
    // For clients that only change storage content (write and delete), never read it.
    public interface IWriteStorage
    {
        void Write(string name, string content);
        void Delete(string name);
    }
}
