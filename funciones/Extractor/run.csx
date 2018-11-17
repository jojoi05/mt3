using System;

public static void Run(string myQueueItem, ICollector<string> inputTable, ILogger log)
{
    inputTable.Add(myQueueItem);
    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
}