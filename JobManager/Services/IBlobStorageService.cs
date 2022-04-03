using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JobManager.Services
{
    public interface IBlobStorageService
    {
        Task<bool> UploadStreamAsync(string name, MemoryStream stream);
        Task<MemoryStream> DownloadStreamAsync(string name);
    }
}