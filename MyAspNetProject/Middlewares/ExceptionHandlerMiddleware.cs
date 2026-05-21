using System.Diagnostics;
using MyAspNetProject.Exceptions;

namespace MyAspNetProject.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            await next(context);
            logger.LogInformation(
                $"{context.TraceIdentifier}. Method {context.Request.Method} took {sw.ElapsedMilliseconds} ms"
            );
        }
        catch (NotFoundException)
        {
            
        }
        catch (Exception e)
        {
            if (e is NotFoundException)
            {
                logger.LogError("Something went wrong. Object was not found");
                context.Response.StatusCode = 404;
            }
        }
    }
}