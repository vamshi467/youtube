using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using Android.Content;
using Android.Webkit;
using AndroidX.Core.Content;
using NewControlsDemo.Droid.Helpers;
using NewControlsDemo.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DocumentInteractionController))]
namespace NewControlsDemo.Droid.Helpers
{
    public class DocumentInteractionController : IDocumentInteractionService
    {
        public string filename;
        public string filePath;

        public DocumentInteractionController()
        {
        }

        [Obsolete]
        public void DownloadFile(string url, string folder)
        {
            try
            {
                string pathToNewFolder;
                //string pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);

                if (Android.OS.Environment.IsExternalStorageEmulated)
                {
                    pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);
                }
                else
                {
                    pathToNewFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folder);
                }

                if (!Directory.Exists(pathToNewFolder))
                    Directory.CreateDirectory(pathToNewFolder);

                filename = url;
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                string pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                filePath = pathToNewFile;
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [Obsolete]
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Java.IO.File file = new Java.IO.File(filePath);

                if (e.Error != null)
                {

                }
                else
                {
                    Android.Net.Uri pdfPath = FileProvider.GetUriForFile(Android.App.Application.Context,
                                    Android.App.Application.Context.PackageName + ".provider",
                                    file);
                    string extension = MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                    string mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);

                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                    intent.SetDataAndType(pdfPath, mimeType); //image/jpeg
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    Forms.Context.StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
