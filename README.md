# DIP as separate projects

A small .NET example of the Dependency Inversion Principle (DIP), split into separate projects so the compiler enforces the direction of the references. It accompanies the Developer CoP talk given on Wednesday (2026-11-11) and is meant as a reference.

The high-level code (`DocumentEditor`, `DocumentViewer`, `CleanupJob`) depends only on storage abstractions. The concrete storages (Azure Blob, SharePoint) depend on those abstractions, never the other way around.

## Projects

| Project | References |
|---|---|
| `DIPProjects.Documents` | nothing |
| `DIPProjects.Storage.Azure` | Documents |
| `DIPProjects.Storage.SharePoint` | Documents |
| `DIPProjects.App` (executable) | all three |

`DIPProjects.Documents` holds the interfaces (`IReadStorage`, `IWriteStorage`, `IReadWriteStorage`) and the classes that use them. `DIPProjects.App` is the composition root: the only place that knows every concrete storage.

> The Azure and SharePoint storages are simulated. They only print to the console, so you don't need an Azure or SharePoint account, credentials or configuration.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Run

```powershell
dotnet run --project DIPProjects.App
```

Expected output:

```
[SharePoint] Downloading 'contract.docx' from 'https://contoso.sharepoint.com/sites/docs'.
[SharePoint] Uploading 'contract.docx' to 'https://contoso.sharepoint.com/sites/docs'.
Editor: saved 'contract.docx'.
[SharePoint] Downloading 'contract.docx' from 'https://contoso.sharepoint.com/sites/docs'.
Viewer: showing <content of contract.docx>
[SharePoint] Deleting 'old-1.docx' from 'https://contoso.sharepoint.com/sites/docs'.
[SharePoint] Deleting 'old-2.docx' from 'https://contoso.sharepoint.com/sites/docs'.
Cleanup: done.
```

You can also open `DIPProjects.slnx` in Visual Studio and run `DIPProjects.App`.

## Switch the storage

Open `DIPProjects.App/Program.cs`. Switching between SharePoint and Azure is one line:

```csharp
using DIPProjects.Storage.Azure;   // replaces the SharePoint using

AzureBlobStorage storage = new("documents");
```

Nothing in `DIPProjects.Documents` changes.

## Delete test

Remove `DIPProjects.Storage.Azure` (project and reference) and `DIPProjects.Documents` still compiles. The abstractions don't depend on any concrete storage.
