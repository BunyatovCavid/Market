using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Market
{ 
    public static class ExceptionHandlingExtension
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                  //  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(contextFeature.Error.Message);
                        await context.Response.WriteAsync(@"

");
                        await context.Response.WriteAsync(contextFeature.Error.StackTrace);

                    }
                });
            });
        }
    }

}
