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
            Directory.CreateDirectory("logs"); // Asegura que exista la carpeta
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Continua la cadena de middlewares
            }
            catch (Exception ex)
            {
                var message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {ex.Message} {Environment.NewLine}";
                await File.AppendAllTextAsync(logFilePath, message);

                _logger.LogError(ex, "Ocurrió una excepción no controlada.");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Error interno del servidor.");
            }
        }
    }

}

