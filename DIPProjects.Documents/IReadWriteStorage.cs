namespace DIPProjects.Documents
{
    // For clients that need both capabilities from the same storage.
    public interface IReadWriteStorage : IReadStorage, IWriteStorage
    {
    }
}