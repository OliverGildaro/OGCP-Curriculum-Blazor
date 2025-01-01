using System.Net.Mime;
using System.Net;
using System.Text.Json;

namespace OGCP.Curriculums.BlazorServer.Helpers;
public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleCustomExceptionResponseAsync(context, ex);
        }
    }

    //private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception ex)
    //{
    //    context.Response.ContentType = MediaTypeNames.Application.Json;
    //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    //    var response = new
    //    {
    //        StatusCode = (int)context.Response.StatusCode,
    //        Message = "An expected error ocurred, catched in the midleware exception",
    //        StackTrace = ex.StackTrace?.ToString() // Avoid exposing internal details in production
    //    };
    //    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    //    var json = JsonSerializer.Serialize(response, options);
    //    await context.Response.WriteAsync(json);
    //}

    private async Task HandleCustomExceptionResponseAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Método auxiliar para obtener excepciones anidadas
        static IEnumerable<object> GetExceptionDetails(Exception exception)
        {
            var currentException = exception;
            while (currentException != null)
            {
                yield return new
                {
                    Message = currentException.Message,
                    StackTrace = currentException.StackTrace
                };
                currentException = currentException.InnerException;
            }
        }

        var response = new
        {
            StatusCode = (int)context.Response.StatusCode,
            Message = "An unexpected error occurred, caught in the middleware exception handler.",
            Exceptions = GetExceptionDetails(ex)
        };

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var json = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(json);
    }

}
