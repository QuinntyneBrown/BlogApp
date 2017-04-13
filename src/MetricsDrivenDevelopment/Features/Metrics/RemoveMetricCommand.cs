using MediatR;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using MetricsDrivenDevelopment.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Features.Metrics
{
    public class RemoveMetricCommand
    {
        public class RemoveMetricRequest : IRequest<RemoveMetricResponse>
        {
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; } 
        }

        public class RemoveMetricResponse { }

        public class RemoveMetricHandler : IAsyncRequestHandler<RemoveMetricRequest, RemoveMetricResponse>
        {
            public RemoveMetricHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveMetricResponse> Handle(RemoveMetricRequest request)
            {
                var metric = await _context.Metrics.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                metric.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveMetricResponse();
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }
    }
}
