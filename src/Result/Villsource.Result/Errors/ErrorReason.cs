namespace Villsource.Result.Errors;

public class ErrorReason(string message): IError
{
    private string Message { get; } = message;
    public override string ToString() => Message;
    
    public static implicit operator ErrorReason(string message) => new(message);
}