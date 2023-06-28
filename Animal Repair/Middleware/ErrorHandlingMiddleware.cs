using Amazon.Runtime.Internal;
using Newtonsoft.Json;
using System.Net;

namespace Animal_Repair.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Пропустить запрос дальше в конвейер
                await _next(context);
            }
            catch (Exception ex)
            {
                // Обработка исключений и формирование ответа
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Логика обработки исключений, формирование сообщения об ошибке и т.д.

            // Например, можно установить код состояния и вернуть сообщение в формате JSON
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Message = "Произошла ошибка",
                // Дополнительные поля, такие как код ошибки, трассировка стека и т.д.
            };

            var json = JsonConvert.SerializeObject(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}
