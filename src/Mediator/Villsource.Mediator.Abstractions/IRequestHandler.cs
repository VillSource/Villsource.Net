namespace Villsource.Mediator.Abstractions;

public interface IRequestHandler<in TRequest, TResponse>  
    where TRequest : class, IRequest<TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken = default);
}