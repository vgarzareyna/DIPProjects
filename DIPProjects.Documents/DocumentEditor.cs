namespace DIPProjects.Documents
{
    // Needs read and write from the same storage. One parameter: reader and writer can't differ.
    public class DocumentEditor(IReadWriteStorage storage)
    {
        public void AddNote(string name, string note)
        {
            string content = storage.Read(name);
            storage.Write(name, $"{content}\n{note}");
            Console.WriteLine($"Editor: saved '{name}'.");
        }
    }
}