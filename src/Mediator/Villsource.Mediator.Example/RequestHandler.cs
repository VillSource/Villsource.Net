using Villsource.Mediator.Abstractions;
using Villsource.Result;

namespace Villsource.Mediator.Example;

public class RequestHandler: IRequestHandler<Request, int>
{
    public async Task<Result<int>> Handle(Request request, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        return Result.Result.Ok(1000);
    }
}