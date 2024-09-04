using System.Net;
using System.Text.Json;
using TrainOffice.Infrastructures.Models;

namespace TrainOffice.Core.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected

        var result = JsonSerializer.Serialize(new ApiResponse<object>(
        [
            new ApiError("ServerError", "An unexpected error occurred.")
        ]));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}