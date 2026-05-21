using System.Diagnostics;

namespace WebApplication2;

public class PerformanceCheckMiddleware(RequestDelegate next, ILogger<PerformanceCheckMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch st = new Stopwatch();
        st.Start();
        await next(context);
        if (st.ElapsedMilliseconds > 500)
        {
            logger.LogError($"{context.Request.Method} got long time");
            st.Stop();
        }
    }
}
