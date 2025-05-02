namespace APIs.MiddleWares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _maxRequestsPerWindow = 20;
        private static TimeSpan _window = TimeSpan.FromSeconds(5);

        private static int _requestCount = 0;
        private static DateTime _windowStart = DateTime.UtcNow;
        private static readonly object _lock = new();

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            lock (_lock)
            {
                var now = DateTime.UtcNow;
                if (now - _windowStart > _window)
                {
                    _windowStart = now;
                    _requestCount = 0;
                }

                _requestCount++;

                if (_requestCount > _maxRequestsPerWindow)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.Response.ContentType = "text/plain";
                    context.Response.WriteAsync("Rate limit exceeded. Try again later.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
