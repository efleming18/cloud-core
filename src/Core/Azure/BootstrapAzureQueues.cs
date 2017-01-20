using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Core.Azure
{
    public class BootstrapAzureQueues
    {
        public static void CreateKnownAzureQueues(string azureConnectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            foreach (var queueName in AzureQueues.KnownQueues)
            {
                queueClient.GetQueueReference(queueName).CreateIfNotExists();
            }
        }
    }
}
