using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;

namespace Api.Logging;

using Serilog;
using Serilog.Debugging;
using Elastic.Serilog.Sinks;

public static class LoggingExtension
{
    public static void RegisterLogger(this IConfiguration configuration)
    {
        var model = configuration.GetSection("SerilogConfig").Get<SerilogConfigModel>();
        ArgumentNullException.ThrowIfNull(model);
        SelfLog.Enable(Console.Error);
        Log.Logger = new LoggerConfiguration()
            .PrepareLoggerConfig(model)
            .CreateLogger();
    }

    private static LoggerConfiguration PrepareLoggerConfig(this LoggerConfiguration loggerConfiguration, SerilogConfigModel model)
    {
        return loggerConfiguration.MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("Elastic.Apm", Serilog.Events.LogEventLevel.Warning)
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new [] { new Uri(model.ElasticUri)}, opts =>
            {
                opts.DataStream = new DataStreamName("logs", "console-example", "demo");
                opts.BootstrapMethod = BootstrapMethod.Failure;
                opts.ConfigureChannel = channelOpts =>
                {
                    channelOpts.BufferOptions = new BufferOptions
                    {
                        // ConcurrentConsumers = 10
                    };
                };

            }, configureTransport =>
            {
                configureTransport.Authentication(new BasicAuthentication(model.ElasticUser, model.ElasticPassword));
            }) 
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProperty("Environment", model.Environment);}
}