using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartCentreW104.Helpers
{
    public class CloudClass
    {
        public CloudBlobContainer MyCloudClass()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=thegoofyanatomist2;AccountKey=vSPtuUJeF61Zqn7byU2PNHCn+WQB6NygFUN8eixUqrHXemX3qw4fdvilRmE27TYWue3sP1tcXFZ3MmAxqVJLOg==;EndpointSuffix=core.windows.net");

            //Create the blob client object.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Get a reference to a container to use for the sample code, and create it if it does not exist.
            CloudBlobContainer container = blobClient.GetContainerReference("diagramscontainer2");

            return container;
            //string adHocContainerSAS = GetContainerSasUri(container);
        }

        public string GetContainerSasUri(CloudBlobContainer container, string storedPolicyName = null)
        {
            string sasContainerToken;

            // If no stored policy is specified, create a new access policy and define its constraints.
            if (storedPolicyName == null)
            {
                // Note that the SharedAccessBlobPolicy class is used both to define the parameters of an ad-hoc SAS, and 
                // to construct a shared access policy that is saved to the container's shared access policies. 
                SharedAccessBlobPolicy adHocPolicy = new SharedAccessBlobPolicy()
                {
                    // Set start time to five minutes before now to avoid clock skew.
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMonths(1),
                    Permissions = SharedAccessBlobPermissions.Read,
                };
                sasContainerToken = container.GetSharedAccessSignature(adHocPolicy, null);
            }

            else
            {
                sasContainerToken = container.GetSharedAccessSignature(null, storedPolicyName);
            }

            //Return the URI string for the container, including the SAS token.

            return container.Uri + sasContainerToken;
        }
    }
}
