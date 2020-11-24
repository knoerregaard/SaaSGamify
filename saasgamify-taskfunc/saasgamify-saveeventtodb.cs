using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using saasgamify_taskfunc.Models;
/// <summary>
/// Picks a message from the storage queue and saves it to sql db
/// </summary>

namespace saasgamify_taskfunc
{
    public static class saasgamify_saveeventtodb
    {   
        //Save event to SQL DB
        [FunctionName("saasgamify_saveeventtodb")]
        public static void Run([QueueTrigger("events", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            DAL.SaveEventToDb(JsonConvert.DeserializeObject<Event>(myQueueItem));
        }
    }
}
