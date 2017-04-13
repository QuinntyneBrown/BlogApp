using MediatR;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Features.Metrics
{
    public class GetMetricsQuery
    {
        public class GetMetricsRequest : IRequest<GetMetricsResponse> { 
            public Guid TenantUniqueId { get; set; }       
        }

        public class GetMetricsResponse
        {
            public ICollection<MetricApiModel> Metrics { get; set; } = new HashSet<MetricApiModel>();
        }

        public class GetMetricsHandler : IAsyncRequestHandler<GetMetricsRequest, GetMetricsResponse>
        {
            public GetMetricsHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetMetricsResponse> Handle(GetMetricsRequest request)
            {
                var metrics = await _context.Metrics
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new GetMetricsResponse()
                {
                    Metrics = metrics.Select(x => MetricApiModel.FromMetric(x)).ToList()
                };
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }

    }

}
