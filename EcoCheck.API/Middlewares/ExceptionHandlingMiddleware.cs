using EcoCheck.Domain.Exceptions;

namespace EcoCheck.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                success = false,
                mensaje = exception.Message,
               
            };

            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    _logger.LogWarning(exception, "Recurso no encontrado");
                    break;

                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    _logger.LogWarning(exception, "Solicitud incorrecta");
                    break;

                case UnauthorizedException:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    _logger.LogWarning(exception, "No autorizado");
                    break;

                case ForbiddenException:
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    _logger.LogWarning(exception, "Acceso prohibido");
                    break;
                case ConflictException:
                    context.Response.StatusCode=StatusCodes.Status409Conflict;
                    _logger.LogWarning(exception, "Usuario duplicado");
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response = new
                    {
                        success = false,
                        mensaje = "Error interno del servidor",
                       
                    };
                    _logger.LogError(exception, "Error interno del servidor");
                    break;
            }

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
