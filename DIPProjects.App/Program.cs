using DIPProjects.Documents;
using DIPProjects.Storage.SharePoint;

namespace DIPProjects.App
{
    // Composition root: the only project that knows every concrete storage.
    // Switching Azure <-> SharePoint is one line here (add `using DIPProjects.Storage.Azure;`).
    // DIPProjects.Documents references nothing: it compiles without any storage project.
    public static class Program
    {
        public static void Main()
        {
            SharePointStorage storage = new("https://contoso.sharepoint.com/sites/docs");
            // AzureBlobStorage storage = new("documents");   // the Azure alternative

            new DocumentEditor(storage).AddNote("contract.docx", "Reviewed by Legal.");
            new DocumentViewer(storage).Show("contract.docx");
            new CleanupJob(storage).Run(["old-1.docx", "old-2.docx"]);
        }
    }
}