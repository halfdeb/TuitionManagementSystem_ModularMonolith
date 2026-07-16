namespace Shared.Contracts.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}