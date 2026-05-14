using System.Text.Json;
using InventoryManagement.Application.Interfaces;

namespace InventoryManagement.Infrastructure.Messaging;

public class ConsoleEventPublisher : IEventPublisher
{
    public Task PublishAsync<T>(string eventName, T payload)
    {
        Console.WriteLine("EVENT PUBLISHED:");
        Console.WriteLine(eventName);
        Console.WriteLine(JsonSerializer.Serialize(payload, new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        return Task.CompletedTask;
    }
}