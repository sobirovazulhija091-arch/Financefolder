using System;
public class RequestTimeMiddelware(RequestDelegate next,ILogger<RequestTimeMiddelware> logger)
{
    private ILogger<RequestTimeMiddelware> _logger = logger;
    private RequestDelegate _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation
        (
            "Incoming request:{Method} {Paht}",
           context.Request.Method,
           context.Request.Path
        );
        var start =  DateTime.Now;
        try
        {
            await _next(context);
        }
        catch (System.Exception)
        {
             _logger.LogError("The request was not successfull");
        }
        var end = DateTime.Now;
       _logger.LogInformation("The request finished!");
     Console.WriteLine($"Request took {(end - start).TotalMilliseconds} ms");
    }
}