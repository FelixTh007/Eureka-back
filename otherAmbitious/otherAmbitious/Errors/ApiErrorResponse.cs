namespace Eureka.Api.Errors;

public sealed record ApiErrorResponse(
    string Code,
    string Message,
    string TraceId,
    IDictionary<string, string[]>? Errors = null
);
