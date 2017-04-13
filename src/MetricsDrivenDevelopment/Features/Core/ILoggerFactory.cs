using System.Collections.Generic;

namespace MetricsDrivenDevelopment.Features.Core
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        List<ILoggerProvider> GetProviders();
    }
}
