using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

/// <summary>
///  Aggregate
///  This Azure trigger function will aggregrate data from the SQL database and place the data in a Key Value Storage once a day, in the evening.
/// </summary>

namespace saasgamify_taskfunc
{
    public static class saasgamify_aggregate
    {
        
        [FunctionName("saasgamify_aggregate")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer,  ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
