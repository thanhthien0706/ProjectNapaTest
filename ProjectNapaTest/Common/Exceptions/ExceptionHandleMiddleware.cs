namespace ProjectNapaTest.Common.Exceptions
{
    public class ExceptionHandleMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var msg = ex.Message.ToString();

                _logger.LogInformation(msg);
                context.Request.Path = "/User/Home/Error";
                context.Response.Redirect("/User/Home/Error");
            }
        }
    }
}
