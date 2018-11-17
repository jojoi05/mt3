#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ICollector<Person> outputQueueItem, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    Person p = new Person();
    p.Name=req.Query["name"];
    p.Address=req.Query["address"];
    p.Phone=req.Query["phone"];
    p.Email=req.Query["email"];
    p.Age=req.Query["age"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    p.Name = p.Name ?? data?.name;
    p.Address = p.Address ?? data?.address;
    p.Phone = p.Phone ?? data?.phone;
    p.Email = p.Email ?? data?.email;
    p.Age = p.Age ?? data?.age;
    outputQueueItem.Add(p);
    return p != null && p.Name != null && p.Address != null && p.Phone !=null && p.Email!=null && p.Age !=null
        ? (ActionResult)new OkObjectResult($"Hello, {p}")
        : new BadRequestObjectResult("Please pass name, address, phone, email and age in the request body");
}

public class Person
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Age { get; set; }
}