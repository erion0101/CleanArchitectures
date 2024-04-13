using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

namespace q.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFature = context.Features.Get<IExceptionHandlerFeature>();
                    var exeception = errorFature.Error;

                    if(!(exeception is ValidationException validationException))
                    {
                        throw exeception;
                    }

                    var errors = validationException.InnerException.Message.Split('\n');
                   
                    var errorText = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText,Encoding.UTF8);   
                });
            });

        }
    }
}
