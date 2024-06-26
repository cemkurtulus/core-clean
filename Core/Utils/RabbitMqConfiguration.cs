namespace Core.Utils;

public class RabbitMqConfiguration
{
    public required string HostName { get; init; }
    
    public required string Username { get; init; }
    
    public required string Password { get; init; }
}
