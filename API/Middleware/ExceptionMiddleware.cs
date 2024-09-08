using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly ILogger<ExceptionMiddleware> logger1;
        private readonly IHostEnvironment environment;

        public ExceptionMiddleware(RequestDelegate requestDelegate,
        ILogger<ExceptionMiddleware> logger1,
        IHostEnvironment environment)
        {
            this.requestDelegate = requestDelegate;
            this.logger1 = logger1;
            this.environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                this.logger1.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var Response = environment.IsDevelopment()
                ? new ApiException(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString())
                : new ApiException(StatusCodes.Status500InternalServerError);

                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(Response,jsonOptions);

                await context.Response.WriteAsync(json);
            }

        }
    }
}