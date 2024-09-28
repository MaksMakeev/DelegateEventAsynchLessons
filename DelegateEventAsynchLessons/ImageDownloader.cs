using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventAsynchLessons
{
    internal class ImageDownloader
    {
        public delegate void Notification(string message);
        public event Notification ImageStarted;
        public event Notification ImageCompleted;
        public ImageDownloader() { }
        
        public void Download(string remoteUri, string fileName)
        {
            var MyWebClient = new WebClient();
            ImageStarted?.Invoke("Downloading has been started");
            MyWebClient.DownloadFile(remoteUri, fileName);
            ImageCompleted?.Invoke("Downloading has been completed");
        }

        public async Task DownloadAsync(string remoteUri, string fileName)
        {
            var MyWebClient = new WebClient();
            ImageStarted?.Invoke("Downloading has been started");
            await MyWebClient.DownloadFileTaskAsync(remoteUri, fileName);
            ImageCompleted?.Invoke("Downloading has been completed");
        }
    }
}
