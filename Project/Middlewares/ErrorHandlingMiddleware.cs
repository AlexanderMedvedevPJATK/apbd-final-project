

using System.Net;
using Project.Exceptions;

namespace Project.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (ClientNotFoundException ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
    {
        // Set the status code and response content
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        // Create a response model
        var response = new
        {
            error = new
            {
                message = "An error occurred while processing your request.",
                detail = exception.Message
            }
        };

        // Serialize the response model to JSON
        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);

        // Write the JSON response to the HTTP response
        return context.Response.WriteAsync(jsonResponse);
    }

}