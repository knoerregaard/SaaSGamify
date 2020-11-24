using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

/// <summary>
/// RegisterEvent
/// All incomming events will be registered in the Storage queue as raw json objects
/// The queue attribute sets the name of the queue on storage.
/// The msg is the output binding
/// </summary>

namespace saasgamify_taskfunc
{
    public static class saasgamify_registerevent
    {
        [FunctionName("saasgamify_registerevent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, //Only posts allowed
            [Queue("events"), //Name of the queue on azure, will be converted to function.json on depature
            StorageAccount("AzureWebJobsStorage")] ICollector<string> msg,  //the output binding, will be converted to function.json on depature
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
         
            //Direcyle add the message to the queue as raw json
            if (!string.IsNullOrEmpty(requestBody))
            {
                // Add a message to the output collection.
                msg.Add(requestBody);
                return new OkResult();
            }

            return new NotFoundObjectResult("No object");
        }
    }
}
