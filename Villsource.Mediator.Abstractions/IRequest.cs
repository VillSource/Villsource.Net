namespace Villsource.Mediator.Abstractions;

/// <summary>
/// Request object
/// </summary>
public interface IRequest: IMediatorSubject { }


/// <summary>
/// Request object with response
/// </summary>
public interface IRequest<out TResponse>: IMediatorSubject { }