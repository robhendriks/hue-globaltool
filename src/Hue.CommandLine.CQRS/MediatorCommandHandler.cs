namespace Hue.CommandLine.CQRS;

using System.CommandLine.Invocation;
using System.CommandLine.NamingConventionBinder;
using Common.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rendering.Abstractions;

public static class MediatorCommandHandler
{
    public static ICommandHandler CreateReadHandler<TRequest, TResponse>()
        where TRequest : IRequest<HueApiResponse<TResponse>>
        where TResponse : Resource
    {
        return CommandHandler.Create<InvocationContext, IHost, TRequest>(async (ctx, host, request) =>
        {
            var mediator = host.Services.GetService<IMediator>()!;

            var apiResponse = await mediator.Send(request, ctx.GetCancellationToken());

            if (apiResponse.Errors.Any() || !apiResponse.Data.Any())
            {
                var apiErrorRenderer = host.Services.GetService<IHueApiErrorRenderer>()!;
                apiErrorRenderer.Render(apiResponse.Errors);
                return 1;
            }

            var resourceRenderer = host.Services.GetService<IHueResourceRenderer>()!;
            resourceRenderer.Render(apiResponse.Data);

            return 0;
        });
    }

    public static ICommandHandler CreateWriteHandler<TRequest, TResponse>()
        where TRequest : IRequest<HueApiResponse<TResponse>>
        where TResponse : ResourceIdentifier
    {
        return CommandHandler.Create<InvocationContext, IHost, TRequest>(async (ctx, host, request) =>
        {
            var mediator = host.Services.GetService<IMediator>()!;

            var apiResponse = await mediator.Send(request, ctx.GetCancellationToken());

            if (apiResponse.Errors.Any() || !apiResponse.Data.Any())
            {
                var apiErrorRenderer = host.Services.GetService<IHueApiErrorRenderer>()!;
                apiErrorRenderer.Render(apiResponse.Errors);
                return 1;
            }

            var resourceRenderer = host.Services.GetService<IHueResourceIdentifierRenderer>()!;
            resourceRenderer.Render(apiResponse.Data);

            return 0;
        });
    }
}
