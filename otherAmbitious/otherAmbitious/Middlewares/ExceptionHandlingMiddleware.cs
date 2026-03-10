using System.Net;
using Eureka.Api.Errors;

namespace Eureka.Api.Middlewares;

public sealed class ExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            // Client a coupé la requête -> pas une erreur serveur
            context.Response.StatusCode = StatusCodes.Status499ClientClosedRequest; // dispo selon version; sinon 400/408
        }
        catch (Exception ex)
        {
            var traceId = context.TraceIdentifier;
            var (status, body) = MapException(ex, traceId);
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(body);

        }
    }

    private static (int Status, string Code, string Message) MapException(Exception ex)
    {
        // ✅ Ton service lève InvalidOperationException pour validation et conflits email :contentReference[oaicite:1]{index=1}
        if (ex is InvalidOperationException ioe)
        {
            // petite distinction "conflit" vs "validation"
            if (ioe.Message.Contains("déjà utilisé", StringComparison.OrdinalIgnoreCase))
                return (StatusCodes.Status409Conflict, "email_already_used", ioe.Message);

            return (StatusCodes.Status400BadRequest, "validation_error", ioe.Message);
        }

        // Exemple : si tu ajoutes plus tard des exceptions métiers dédiées
        // if (ex is DomainException de) return ((int)de.StatusCode, de.Code, de.Message);

        return (StatusCodes.Status500InternalServerError, "server_error", "Une erreur interne est survenue.");
    }

    private static (int Status, ApiErrorResponse Body) MapException(Exception ex, string traceId)
    {
        if (ex is InvalidOperationException ioe)
        {
            // même règle que ton message "Cet email est déjà utilisé." :contentReference[oaicite:2]{index=2}
            if (ioe.Message.Contains("déjà utilisé", StringComparison.OrdinalIgnoreCase))
            {
                return (StatusCodes.Status409Conflict,
                    new ApiErrorResponse("email_already_used", ioe.Message, traceId));
            }

            return (StatusCodes.Status400BadRequest,
                new ApiErrorResponse("validation_error", ioe.Message, traceId));
        }

        return (StatusCodes.Status500InternalServerError,
            new ApiErrorResponse("server_error", "Une erreur interne est survenue.", traceId));
    }


}
