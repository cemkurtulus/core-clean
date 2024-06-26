using Core.Interfaces;
using Core.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Core.Service;

public class RabbitMqService(IConfiguration configuration) : IRabbitMqService
{
    public IConnection CreateChannel()
    {
        var config = configuration.GetSection("RabbitMqConfiguration").Get<RabbitMqConfiguration>();
        
        var factory = new ConnectionFactory
        {
            UserName = config?.Username,
            Password = config?.Password,
            HostName = config?.HostName,
            DispatchConsumersAsync = true
        };
        var channel = factory.CreateConnection();
        return channel;
    }
}