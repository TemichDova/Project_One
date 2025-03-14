using FluentValidation;
using Project_Transaction.Application.Models.Common;
using Project_Transaction.Domain.Exceptions;

namespace Project_Transaction.WebApi.Middleware
{
    public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IWebHostEnvironment env)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandler> _logger = logger;
        private readonly IWebHostEnvironment _env = env;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Провалена валидация ({RequestId})", context.TraceIdentifier);
                await HandleException(context, ex, ex.Errors.Select(s=>new ExceptionResponse.ProblemDetail() { Field=s.PropertyName,Reason =s.ErrorMessage}).ToArray(), "/validation-error", "Ошибка валидации", "В одном или нескольких полях есть ошибки проверки. Проверьте и попробуйте еще раз.", StatusCodes.Status400BadRequest);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Сущность не найдена ({RequestId})", context.TraceIdentifier);
                await HandleException(context, ex, [new ExceptionResponse.ProblemDetail() { Field = "Id", Reason= ex.Message }], "transaction-not-found", "Not Found", "Объект не найден, проверьте корректность ссылки" );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Внутреннее исключение ({RequestId})", context.TraceIdentifier);
                await HandleException(context, ex, [], "internal-server-error", "Internal Server Error");
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex, ExceptionResponse.ProblemDetail[] problemDetails, string type, string title, string? message = null, int? statusCode = null )
        {
            context.Response.ContentType = "application/problem+json";

            if (statusCode is null)
            {
                context.Response.StatusCode = int.TryParse(ex.Data["status"]?.ToString(), out int code) ? code : StatusCodes.Status500InternalServerError;
            }
            else
            {
                context.Response.StatusCode = statusCode.Value;
            }

            await context.Response.WriteAsJsonAsync(new ExceptionResponse
            {
                Type =  $"https://example.net/{type}",
                Title = title,                
                Status = context.Response.StatusCode,
                Detail = message ?? ex.Message,
                Instance = context.Request.Path,
                ProblemDetails = problemDetails
            });
        }
    }
}
