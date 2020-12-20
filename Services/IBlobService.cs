﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBook.Models;

namespace OpenBook.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task UploadContentBlobAsync(string content, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
