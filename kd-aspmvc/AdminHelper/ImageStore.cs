﻿using DataModel;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace kd_aspmvc.AdminHelper
{
    public class ImageStore
    {
        CloudBlobClient _client;
        Uri _baseuri = new Uri("https://kdaspmvcstore.blob.core.windows.net/");
        public ImageStore()
        {
            _client = new CloudBlobClient(_baseuri, new StorageCredentials("kdaspmvcstore", "mrwZQytWB/Abilsaca975Z6JVaIxV5NEM0XohvCUv8KIRJAkHmGE1jGZJ1Ym4Dq+UpevknvW686mQxckT/ji9Q=="));
        }
        public async Task<string> SaveImage(Stream stream, string name)
        {
            var id = Guid.NewGuid().ToString();
            var container = _client.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(id);
            await blob.UploadFromStreamAsync(stream);
            return id;
        }
        public Uri UriFor(string id)
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30),
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15)
            };
            var container = _client.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(id);
            var sasToken = blob.GetSharedAccessSignature(sasPolicy);
            
            return new Uri(_baseuri, $"/images/{id}{sasToken}");
        }
        public List<Uri> GetAllImages()
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30),
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15)
            };
            var container = _client.GetContainerReference("images");
            var blobs = container.ListBlobs().OfType<CloudBlockBlob>().Select(m => m.Name).ToList();
            List<Uri> uris = new List<Uri>();
            foreach (var blob in blobs)
            {
                var ablob = container.GetBlockBlobReference(blob);
                var sasToken = ablob.GetSharedAccessSignature(sasPolicy);
                uris.Add(new Uri(_baseuri, $"/images/{blob}{sasToken}"));
            }
            return uris;
        }
        public List<Uri> GetFeaturedItems()
        {
            var sasPolicy = new SharedAccessBlobPolicy
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30),
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15)
            };
            var container = _client.GetContainerReference("images");
            var blobs = container.ListBlobs().OfType<CloudBlockBlob>().Select(m => m.Name).ToList();
            List<Uri> uris = new List<Uri>();
            foreach (var blob in blobs)
            {
                var ablob = container.GetBlockBlobReference(blob);
                var sasToken = ablob.GetSharedAccessSignature(sasPolicy);
                uris.Add(new Uri(_baseuri, $"/images/{blob}{sasToken}"));
            }
            return uris;
        }
    }
}