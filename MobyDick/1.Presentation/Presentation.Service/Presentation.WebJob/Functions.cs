using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Infrastructure.Cross.IoC;
using Application.MainModule.Administration.RolesManagement;



namespace Presentation.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("HelloWorld")] string message, TextWriter log)
        {
            Console.WriteLine("WebJob HelloWorld: " + message);

            // Nos conectamos a EF para validar funcionalidad
            var dtos = FactoryIoC.Container.Resolve<IServiceUsers>().GetDTOCulture();
            dtos.ToList();

            log.WriteLine("This is A diagnostic message: " + message);
        }

        /// <summary>
        /// Reads a message as string for the queue named "inputtext"
        /// Outputs the text in the blob helloworld/out.txt
        /// </summary>
        //public static void HelloWorldFunction(
        //   
        //    [Blob("hellowor [QueueTrigger("inputText")] string inputText,ld/out.txt")] out string output)
        //{
        //    output = inputText;
        //}

    }
}
