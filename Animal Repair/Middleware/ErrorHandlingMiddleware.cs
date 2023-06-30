using Animal_Repair.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Razor;

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
                // Здесь можно выполнить дополнительные действия по обработке исключения, если требуется

                // Установите нужный статус код для ошибки
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Создайте модель данных с информацией об ошибке
                var errorModel = new ErrorViewModel
                {
                    ErrorCode = context.Response.StatusCode,
                    ErrorMessage = ex.Message
                };

                // Отобразите окно с информацией об ошибке
                await context.Response.WriteAsync($"<html>\r\n<head>\r\n    <meta charset=\"utf-8\">\r\n    <title>Error</title>\r\n</head>\r\n<body><h1>Error {context.Response.StatusCode}</h1><p>{ex.Message}</p></body>\r\n</html>");
            }
        }
    }


    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }

    // Пример пользовательского исключения
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
