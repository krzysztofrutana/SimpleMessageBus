using MessageBusTest.MessageBus.Abstraction;

namespace MessageBusTest.MessageBus
{
    public interface IMessageBus
    {
        T Query<T>(IQuery<T> query) where T : class;
        T Command<T>(ICommand<T> command) where T : class;
    }
}
