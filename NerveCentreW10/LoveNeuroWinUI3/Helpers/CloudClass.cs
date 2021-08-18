using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveNeuroWinUI3.Helpers
{
    public class CloudClass
    {

        public string GetBlobSasUri(string cloudBlockBlob)
        {
            string storedPolicyName = null;
            string containerName = "diagramscontainer2";
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=thegoofyanatomist2;AccountKey=vSPtuUJeF61Zqn7byU2PNHCn+WQB6NygFUN8eixUqrHXemX3qw4fdvilRmE27TYWue3sP1tcXFZ3MmAxqVJLOg==;EndpointSuffix=core.windows.net";

            var blobClient = new BlobClient(storageConnectionString, containerName, cloudBlockBlob);
            // Check whether this BlobClient object has been authorized with Shared Key.
            if (blobClient.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one hour.
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                    BlobName = blobClient.Name,
                    Resource = "b"
                };

                if (storedPolicyName == null)
                {
                    sasBuilder.StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5);
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(2);
                    sasBuilder.SetPermissions(BlobSasPermissions.Read);
                }
                else
                {
                    sasBuilder.Identifier = storedPolicyName;
                }

                string sasUri = blobClient.GenerateSasUri(sasBuilder).ToString();
                return sasUri;
            }
            else
            {
                return null;
            }
        }
    }
}
