using Core.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using IModel = RabbitMQ.Client.IModel;

namespace Core.Service;

public class ConsumerService: IConsumerService, IDisposable
{
    private readonly IModel _model;
    private readonly IConnection _connection;
    public ConsumerService(IRabbitMqService rabbitMqService)
    {
        _connection = rabbitMqService.CreateChannel();
        _model = _connection.CreateModel();
        _model.QueueDeclare(QueueName, durable: true, exclusive: false, autoDelete: false);
        _model.ExchangeDeclare("your.exchange.name", ExchangeType.Fanout, durable: true, autoDelete: false);
        _model.QueueBind(QueueName, "your.exchange.name", string.Empty);
    }

    private const string QueueName = "your.queue.name";
    
    public async Task ReadMessages()
    {
        var consumer = new AsyncEventingBasicConsumer(_model);
        consumer.Received += async (ch, ea) =>
        {
            var body = ea.Body.ToArray();
            var text = System.Text.Encoding.UTF8.GetString(body);
            Console.WriteLine(text);
            await Task.CompletedTask;
            _model.BasicAck(ea.DeliveryTag, false);
        };
        _model.BasicConsume(QueueName, false, consumer);
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        if (_model.IsOpen)
            _model.Close();
        if (_connection.IsOpen)
            _connection.Close();
    }
}