namespace Villsource.Mediator.Abstractions;

public interface ICommand: IRequest { }
public interface ICommand<out TResponse>: IRequest<TResponse> { }
