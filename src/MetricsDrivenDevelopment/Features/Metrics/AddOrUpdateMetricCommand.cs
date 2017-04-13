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
    public class AddOrUpdateMetricCommand
    {
        public class AddOrUpdateMetricRequest : IRequest<AddOrUpdateMetricResponse>
        {
            public MetricApiModel Metric { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class AddOrUpdateMetricResponse { }

        public class AddOrUpdateMetricHandler : IAsyncRequestHandler<AddOrUpdateMetricRequest, AddOrUpdateMetricResponse>
        {
            public AddOrUpdateMetricHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateMetricResponse> Handle(AddOrUpdateMetricRequest request)
            {
                var entity = await _context.Metrics
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.Metric.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Metrics.Add(entity = new Metric() { TenantId = tenant.Id });
                }

                entity.Name = request.Metric.Name;
                
                await _context.SaveChangesAsync();

                return new AddOrUpdateMetricResponse();
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }

    }

}
