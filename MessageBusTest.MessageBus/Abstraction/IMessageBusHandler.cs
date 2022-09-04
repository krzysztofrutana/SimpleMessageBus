namespace MessageBusTest.MessageBus.Abstraction
{
    public interface IMessageBusHandler { }
    public interface IMessageBusHandler<Q, T> : IMessageBusHandler where Q : IMessageBusMessage where T : class
    {
        T Handle(Q query);
    }
}
