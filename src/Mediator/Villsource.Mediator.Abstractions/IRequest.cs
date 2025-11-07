namespace Villsource.Mediator.Abstractions;

public interface IRequest<TRequest, TResponse> where TRequest : IRequest<TRequest, TResponse>;
