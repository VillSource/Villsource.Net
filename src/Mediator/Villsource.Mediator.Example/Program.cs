using Villsource.Mediator;
using Villsource.Mediator.Abstractions;
using Villsource.Mediator.Example;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddVillsourceMediator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/mediator/send", async (IMediator mediator) =>
    {
        var req = new Request();
        IRequest<Request, int> req2 = new Request();
        
        var res = await mediator.Send(req);
        var res2 = await mediator.Send(req2);
        if (res.IsFail()) throw new Exception();
        return Results.Ok(res);
    })
    .WithGroupName("Mediator") .WithName("send");

app.Run();
