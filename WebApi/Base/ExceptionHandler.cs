using Newtonsoft.Json;
using System.Net;

namespace WebApi.Base
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception ex) 
            {
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                switch (ex)
                {
                    case NoDataException:
                        {
                            statusCode = HttpStatusCode.NoContent; 
                            break;
                        }
                }
                var response = JsonConvert.SerializeObject(new { statusCode = statusCode, message = ex.Message });
                await context.Response.WriteAsync(response);
            }
        }
    }

    public class NoDataException : Exception 
    { 
        public NoDataException() : base("No data")
        {
        }
    }
}
