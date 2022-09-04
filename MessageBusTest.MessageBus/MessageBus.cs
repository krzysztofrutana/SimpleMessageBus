using System.Reflection;
using MessageBusTest.MessageBus.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBusTest.MessageBus
{
    public class MessageBus : IMessageBus
    {
        public static readonly Dictionary<Type, Type> _configurations = new Dictionary<Type, Type>();
        private readonly IServiceProvider _serviceProvider;

        public MessageBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var assemlbies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(x => x.GetName().Name.StartsWith("MessageBusTest"))
            .ToList();

            var messageBusAssembly = assemlbies.FirstOrDefault(x => x.GetName().Name == "MessageBusTest.MessageBus");
            if (messageBusAssembly is not null)
            {
                foreach (var item in messageBusAssembly.GetTypes())
                {
                    if (item.IsClass && typeof(IQuery).IsAssignableFrom(item))
                    {
                        _configurations.Add(item, null);
                    }
                    else if (item.IsClass && typeof(ICommand).IsAssignableFrom(item))
                    {
                        _configurations.Add(item, null);
                    }
                }
            }

            foreach (var item in assemlbies)
            {
                var assemblyTypes = item.GetTypes();

                foreach (var assemblyItem in assemblyTypes)
                {
                    if (assemblyItem.IsClass && typeof(IMessageBusHandler).IsAssignableFrom(assemblyItem))
                    {
                        var handlerName = assemblyItem.Name.Replace("Handler", "");

                        var typeForHandler = _configurations.FirstOrDefault(x => x.Key.Name.Replace("Query", "").Replace("Command", "") == handlerName).Key;
                        if (typeForHandler is not null)
                        {
                            _configurations[typeForHandler] = assemblyItem;
                        }
                    }
                }
            }
        }


        public T Command<T>(ICommand<T> command) where T : class
        {
            if (_configurations.TryGetValue(command.GetType(), out Type handler))
            {
                MethodInfo methodInfo = handler.GetMethod("Handle");
                if (methodInfo is null)
                    throw new NullReferenceException(nameof(methodInfo));

                if (handler is null)
                    throw new NullReferenceException(nameof(handler));

                var handlerInstance = ActivatorUtilities.CreateInstance(_serviceProvider, handler);

                if (handlerInstance is not null)
                {
                    object[] parameters = new object[] { command };

                    var result = (T)methodInfo.Invoke(handlerInstance, parameters);
                    return result;
                }
            }
            return null;
        }

        public T Query<T>(IQuery<T> query) where T : class
        {
            if (_configurations.TryGetValue(query.GetType(), out Type handler))
            {
                if (handler is null)
                    throw new NullReferenceException(nameof(handler));

                MethodInfo methodInfo = handler.GetMethod("Handle");
                if (methodInfo is null)
                    throw new NullReferenceException(nameof(methodInfo));

                var handlerInstance = ActivatorUtilities.CreateInstance(_serviceProvider, handler);

                if (handlerInstance is not null)
                {
                    object[] parameters = new object[] { query };

                    var result = (T)methodInfo.Invoke(handlerInstance, parameters);
                    return result;
                }
            }
            return null;
        }
    }
}
