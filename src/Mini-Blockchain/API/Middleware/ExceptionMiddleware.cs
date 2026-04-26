using Microsoft.AspNetCore.Mvc;
namespace Mini_Blockchain.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
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
            context.Response.StatusCode = 500;

            var problem = new ProblemDetails
            {
                Title = "Server error",
                Detail = ex.Message
            };

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}