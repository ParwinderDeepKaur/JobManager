using Azure.Storage.Blobs;
using JobManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace JobManager.Services
{
    class BlobStorageServiceAzure : IBlobStorageService
    {
        private readonly BlobServiceClient service = new BlobServiceClient(ConnectionString);

        private static string ConnectionString => "DefaultEndpointsProtocol=https;AccountName=isp1004example;AccountKey=m2fGXOU8vUMOr/hCp7YGfBFcwyb1vYZKXLXO0GrsDyuMnZkOyYsSgJCUA/D5XgpTKcyAjHTxuTl5+AStkc5gVQ==;EndpointSuffix=core.windows.net";
        private static string Container => "a00237487";

        public async Task<MemoryStream> DownloadStreamAsync(string name)
        {
            BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(name);

            if (blob.Exists())
            {
                var stream = new MemoryStream();
                await blob.DownloadToAsync(stream);

                stream.Position = 0;
                return stream;
            }

            return null;
        }

        public async Task<bool> UploadStreamAsync(string name, MemoryStream stream)
        {
            try
            {
                stream.Position = 0;
                BlobClient blob = service.GetBlobContainerClient(Container).GetBlobClient(name);
                await blob.UploadAsync(stream);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}