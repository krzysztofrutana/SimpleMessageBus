namespace MessageBusTest.MessageBus.Abstraction
{
    public interface ICommand : IMessageBusMessage { }
    public interface ICommand<T> : ICommand where T : class
    {
    }
}
