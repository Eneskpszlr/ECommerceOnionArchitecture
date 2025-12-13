using OnionVb02.Application.Exceptions;
using OnionVb02.WebApi.ExceptionModels;
using System.Net;
using System.Text.Json;

namespace OnionVb02.WebApi.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            HttpStatusCode status = ex switch
            {
                ValidationException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                BusinessException => HttpStatusCode.Conflict,
                UnauthorizedException => HttpStatusCode.Unauthorized,
                ForbiddenException => HttpStatusCode.Forbidden,
                _ => HttpStatusCode.InternalServerError
            };

            var response = new ExceptionResponse
            {
                Success = false,
                Message = _env.IsDevelopment() ? ex.Message : GetUserFriendlyMessage(status),
                ExceptionType = _env.IsDevelopment() ? ex.GetType().Name : null,
                Errors = ex is ValidationException ve ? ve.Errors : null
            };

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private string GetUserFriendlyMessage(HttpStatusCode status)
        {
            return status switch
            {
                HttpStatusCode.BadRequest => "Geçersiz istek.",
                HttpStatusCode.NotFound => "Aranan kaynak bulunamadı.",
                HttpStatusCode.Conflict => "İş kuralı hatası.",
                HttpStatusCode.Unauthorized => "Yetkisiz erişim.",
                HttpStatusCode.Forbidden => "Bu işlem için yetkiniz yok.",
                _ => "Sunucuda beklenmeyen bir hata oluştu."
            };
        }
    }
}
