
namespace Shared.Contracts.CQRS;

public class ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}