namespace MessageBusTest.MessageBus.Abstraction
{
    public interface IQuery : IMessageBusMessage
    {

    }

    public interface IQuery<T> : IQuery where T : class
    {
    }
}
