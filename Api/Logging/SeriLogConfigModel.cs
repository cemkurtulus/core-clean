namespace Api.Logging;

internal class SerilogConfigModel
{
    public required string ProjectName { get; init; }
    public required string ElasticUri { get; init; }
    public required string Environment { get; init; }
    public required string ElasticUser { get; init; }
    public required string ElasticPassword { get; init; }
};