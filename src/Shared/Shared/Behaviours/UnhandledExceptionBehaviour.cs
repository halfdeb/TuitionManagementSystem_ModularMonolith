using MediatR;
using Microsoft.Extensions.Logging;

namespace Shared.Behaviours;

public sealed class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> _logger;

    public UnhandledExceptionBehaviour(ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> logger) =>
        _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (System.Exception ex) when (ex is not Shared.Exception.DomainException)
        {
            _logger.LogError(ex, "Unhandled exception for request {RequestName}", typeof(TRequest).Name);
            throw;
        }
    }
}