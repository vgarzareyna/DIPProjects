namespace DIPProjects.Documents
{
    // Documents owns the interface; the Storage projects reference Documents, not the other way around.
    public interface IReadStorage
    {
        string Read(string name);
    }
}
