using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MediaService.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
namespace MediaService.Services
{

    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobService(IOptions<BlobStorageSettings> azureBlobStorageSettings)
        {
            var settings = azureBlobStorageSettings.Value;
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={settings.AccountName};AccountKey={settings.AccountKey};EndpointSuffix=core.windows.net";
            _blobServiceClient = new BlobServiceClient(connectionString);
            _containerName = settings.ContainerName;
        }

        public async Task<string> UploadBlobAsync(string blobName, Stream content, string contentType)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            var blobHttpHeaders = new BlobHttpHeaders { ContentType = contentType };
            await blobClient.UploadAsync(content, new BlobUploadOptions { HttpHeaders = blobHttpHeaders });
            return blobClient.Uri.ToString();
        }

        public async Task<Stream> DownloadBlobAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            var blobDownloadInfo = await blobClient.DownloadAsync();
            return blobDownloadInfo.Value.Content;
        }

        public async Task DeleteBlobAsync(string blobUri)
        {
            // Check if the URI is valid
            if (!Uri.TryCreate(blobUri, UriKind.Absolute, out Uri uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new UriFormatException("Invalid Blob URI.");
            }

            var blobClient = new BlobClient(uriResult);

            // Attempt to delete the blob if it exists
            await blobClient.DeleteIfExistsAsync();
        }

    }
}
