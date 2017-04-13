namespace MetricsDrivenDevelopment.Features.Core
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
