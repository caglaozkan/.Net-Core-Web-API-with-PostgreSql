using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NLayer.API.Middlewares
{
    public static class useCustomExceptionHandler  // extension methodlar static olur parametresi this ile başlar
    {
        public static void UserCustomException(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(config =>
            {



                config.Run(async context =>                          // sonlandırıcı middleware request daha ileri girmicek.
                {
                    context.Response.ContentType = "application/json";


                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,   // ClientSideException ise 400 bunun dışında bişeyse default olarak _ dedik 500 ata
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message); // response bir tip döner bunu geri dönebilmek için jsona serilize ederiz.
                    // middleware larda controllerdaki gibi oto jsona döndürme olayı yok. kendim yazarım.
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));


                });




            });



        }
    }
}
