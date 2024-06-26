using Core.Interfaces;

namespace Api;

public class ConsumerHostedService(IConsumerService consumerService) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await consumerService.ReadMessages();
    }
}