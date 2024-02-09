using Newtonsoft.Json;

namespace Weight.Config
{
    public class Middleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<Middleware> _looger;
        public Middleware(RequestDelegate next, ILogger<Middleware> looger)
        {
            this.next = next;
            _looger = looger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
                _looger.LogInformation($"the function: {context.Request.Method} finished ");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
