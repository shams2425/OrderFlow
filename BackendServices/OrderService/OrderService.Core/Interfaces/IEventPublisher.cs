namespace OrderService.Core.Interfaces;

public interface IEventPublisher
{
    Task Publish<T>(T eventMessage, string queueName);
}
