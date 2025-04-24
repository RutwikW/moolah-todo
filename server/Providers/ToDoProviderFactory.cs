using System;
using server.Interfaces;

namespace server.Providers
{
    public class ToDoProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ToDoProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IToDoProvider GetProvider(string? provider)
        {
            return provider?.ToLower() switch
            {
                "memory" => _serviceProvider.GetRequiredService<InMemoryToDoProvider>(),
                _ => _serviceProvider.GetRequiredService<DbToDoProvider>(),
            };
        }
    }
}