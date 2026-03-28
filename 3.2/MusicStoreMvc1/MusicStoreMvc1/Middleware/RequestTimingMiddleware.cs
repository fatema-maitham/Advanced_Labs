using System.Diagnostics;

namespace MusicStoreMvc1.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            Console.WriteLine(
                $"{context.Request.Method} {context.Request.Path} " +
                $"- {stopwatch.ElapsedMilliseconds}ms " +
                $"[{context.Response.StatusCode}]");
        }
    }
}
