using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Configuration;
using Infrastructure.Cross.IoC;
using Application.MainModule.Administration.RolesManagement;


namespace Presentation.WebJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString);
            //CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            //CloudQueue queue = queueClient.GetQueueReference("inputtext");
            //queue.CreateIfNotExists();
            //queue.AddMessage(new CloudQueueMessage("Hello World!"));
            Console.WriteLine("WebJob HelloWorld: Console " + DateTime.Now);
            // The connection string is read from App.config
            //JobHost host = new JobHost();




            //host.RunAndBlock();
        }
    }
}
