using Amazon.Runtime.Internal;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace Animal_Repair.Middleware
{
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
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            // Определение статусного кода и сообщения об ошибке на основе исключения
            // Можно настроить обработку различных типов исключений

            if (exception is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = "Ресурс не найден.";
            }
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = "Недостаточно прав для доступа к ресурсу.";
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Произошла внутренняя ошибка сервера.";
            }

            // Запись ошибки в логи или другие операции обработки

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ErrorResponse
            {
                StatusCode = (int)statusCode,
                Message = message,
                // Дополнительные поля, если необходимо
            };

            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = System.Text.Json.JsonSerializer.Serialize(errorResponse, jsonOptions);

            return context.Response.WriteAsync(json);
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    // Пример пользовательского исключения
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
