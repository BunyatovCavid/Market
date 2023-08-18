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
                        //switch (contextFeature.Error)
                        //{
                        //    case ApplicationException:
                        //        await context.Response.WriteAsync(new ErrorDetails()
                        //        {
                        //            StatusCode = context.Response.StatusCode,
                        //            Message = "Application  Error."
                        //        }.ToString());
                        //        break;

                        //    case Exception:
                        //        await context.Response.WriteAsync(new ErrorDetails()
                        //        {
                        //            StatusCode = context.Response.StatusCode,
                        //            Message = "You Have An Error."
                        //        }.ToString());
                        //        break;

                        //}
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            Message = contextFeature.Error.Message
                        }.ToString());

                    }
                });
            });
        }
    }

}
