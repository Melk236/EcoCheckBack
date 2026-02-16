using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace EcoCheck.API.Middleware
{
    public class RateLimitAttribute : Attribute, IAsyncActionFilter
    {
        private const string RateLimitKey = "RateLimit_";
        private readonly int _maxRequests;
        private readonly int _windowSeconds;

        public RateLimitAttribute(int maxRequests, int windowSeconds = 60)
        {
            _maxRequests = maxRequests;
            _windowSeconds = windowSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ipAddress = GetIpAddress(context);
            var endpointName = GetEndpointName(context);
            var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            var now = DateTime.UtcNow;

            var cacheKey = $"{RateLimitKey}{ipAddress}_{endpointName}";
            
            if (cache.TryGetValue(cacheKey, out int requestCount))
            {
                if (requestCount >= _maxRequests)
                {
                    var retryAfter = (int)(_windowSeconds - (now - cache.GetEntry(cacheKey)?.ExpirationTime?.Value ?? now).TotalSeconds);
                    context.Result = new ContentResult
                    {
                        StatusCode = 429,
                        Content = $"Too many requests. Try again in {retryAfter} seconds."
                    };
                    return;
                }
                cache.Set(cacheKey, requestCount + 1, new DateTimeOffset(now.AddSeconds(_windowSeconds)));
            }
            else
            {
                cache.Set(cacheKey, 1, new DateTimeOffset(now.AddSeconds(_windowSeconds)));
            }

            await next();
        }

        private string GetIpAddress(ActionExecutingContext context)
        {
            var ip = context.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            }
            return ip ?? "127.0.0.1";
        }

        private string GetEndpointName(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
            var controllerName = actionDescriptor?.ControllerName ?? "unknown";
            var actionName = actionDescriptor?.ActionName ?? "unknown";
            return $"{controllerName}_{actionName}";
        }
    }
}
