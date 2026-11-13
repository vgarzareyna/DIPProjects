namespace DIPProjects.Documents
{
    // Takes IWriteStorage, so it also sees Write. Deliberate: interfaces are split by client role,
    // not one per method. Split further only if this causes trouble.
    public class CleanupJob(IWriteStorage storage)
    {
        public void Run(IEnumerable<string> expiredNames)
        {
            foreach (string name in expiredNames)
            {
                storage.Delete(name);
            }
            Console.WriteLine("Cleanup: done.");
        }
    }
}
