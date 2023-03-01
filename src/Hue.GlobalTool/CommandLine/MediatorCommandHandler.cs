namespace Hue.GlobalTool.CommandLine;

using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using Common.Domain;
using Hue.CommandLine.Rendering.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

public static class MediatorCommandHandler
{
    public static ICommandHandler Create<TRequest, TResponse>()
        where TRequest : IRequest<HueApiResponse<TResponse>>
    {
        return CommandHandler.Create<InvocationContext, IHost, TRequest>(async (ctx, host, request) =>
        {
            var mediator = host.Services.GetService<IMediator>()!;

            var apiResponse = await mediator.Send(request, ctx.GetCancellationToken());

            if (apiResponse.Data.Any())
            {
                var renderableFactory = host.Services.GetService<IRenderableFactory<TResponse>>();
                var renderable = renderableFactory?.Create(apiResponse);

                if (renderable != null)
                {
                    AnsiConsole.Write(renderable);
                }
                else
                {
                    AnsiConsole.Markup("[red]Unable to render response.[/]");
                }
            }
            else if (apiResponse.Errors.Any())
            {
                foreach (var apiResponseError in apiResponse.Errors)
                {
                    AnsiConsole.Markup("[red]{0}[/]", apiResponseError.Description.EscapeMarkup());
                }
            }
            else
            {
                AnsiConsole.Markup("[red]{0}[/]", "Unknown error.".EscapeMarkup());
            }
        });
    }
}
