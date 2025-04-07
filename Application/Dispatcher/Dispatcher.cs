
namespace Application.CommandDispatcher;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
        var handlers = serviceProvider.GetServices<IEventHandler<TEvent>>();
        foreach (var handler in handlers)
        {
            await handler.HandleAsync(@event);
        }
    }

    public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
        return await handler.HandleAsync(query);
    }

    public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command);
    }
}
