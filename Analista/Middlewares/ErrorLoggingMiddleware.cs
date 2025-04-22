using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Analista.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorLoggingMiddleware> _logger;
        private readonly string logFilePath = "logs/errors.txt";

        public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            Directory.CreateDirectory("logs");
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            try
            {
                await _next(context);

                if (context.Response.StatusCode == 400)
                {
                    context.Response.Body = originalBodyStream;
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    var customResponse = new
                    {
                        status = 400,
                        mensaje = "Error en el objeto JSON enviado",
                        data = (object)null
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(customResponse));
                }
                else
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {ex.Message}{Environment.NewLine}";
                await File.AppendAllTextAsync(logFilePath, message);
                _logger.LogError(ex, "Ocurrió una excepción no controlada.");

                context.Response.Body = originalBodyStream;
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var customResponse = new
                {
                    status = 500,
                    message = $"Error de servidor: {ex.Message}",
                    data = (object)null
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(customResponse));
            }
        }
    }
}
