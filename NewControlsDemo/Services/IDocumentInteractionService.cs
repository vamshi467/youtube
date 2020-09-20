using System;
namespace NewControlsDemo.Services
{
    public interface IDocumentInteractionService
    {
        void DownloadFile(string url, string folder);
    }
}
