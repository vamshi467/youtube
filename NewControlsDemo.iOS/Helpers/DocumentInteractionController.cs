using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using Foundation;
using NewControlsDemo.iOS.Helpers;
using NewControlsDemo.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DocumentInteractionController))]
namespace NewControlsDemo.iOS.Helpers
{
    public class DocumentInteractionController : IDocumentInteractionService
    {
        public string pathToNewFile;

        public DocumentInteractionController()
        {
        }

        public void DownloadFile(string url, string folder)
        {
            try
            {
                //string pathToNewFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //var directoryname = Path.Combine(pathToNewFolder, "Attachments");

                string pathToNewFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), folder);
                if (!Directory.Exists(pathToNewFolder))
                    Directory.CreateDirectory(pathToNewFolder);

                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                Debug.WriteLine("PDF File Path ====== " + pathToNewFile);
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {

            }
            else
            {
                var previewController = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(pathToNewFile));
                previewController.Delegate = new MyInteractionDelegate(UIApplication.SharedApplication.KeyWindow.RootViewController);
                previewController.PresentPreview(true);
            }
        }
    }

    public class MyInteractionDelegate : UIDocumentInteractionControllerDelegate
    {
        UIViewController rootViewController;

        public MyInteractionDelegate(UIViewController rootViewController)
        {
            this.rootViewController = rootViewController;
        }

        public override UIViewController ViewControllerForPreview(UIDocumentInteractionController controller)
        {
            return rootViewController;
        }
    }
}
