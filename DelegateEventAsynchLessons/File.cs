using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventAsynchLessons
{
    internal class File
    {
        public string RemoteUri {  get; set; }
        public string Direction { get; set; }
        public string FileName { get; set; }
        public File(string remoteUri, string direction, string fileName) 
        { 
            RemoteUri = remoteUri;
            Direction = direction;
            FileName = fileName;
        }
    }
}
