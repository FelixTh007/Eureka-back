namespace Eureka.Api.Errors;

public sealed record ApiError(
    string Code,
    string Message,
    string? TraceId = null
);