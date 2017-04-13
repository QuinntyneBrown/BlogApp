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
    public class GetMetricByIdQuery
    {
        public class GetMetricByIdRequest : IRequest<GetMetricByIdResponse> { 
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class GetMetricByIdResponse
        {
            public MetricApiModel Metric { get; set; } 
        }

        public class GetMetricByIdHandler : IAsyncRequestHandler<GetMetricByIdRequest, GetMetricByIdResponse>
        {
            public GetMetricByIdHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetMetricByIdResponse> Handle(GetMetricByIdRequest request)
            {                
                return new GetMetricByIdResponse()
                {
                    Metric = MetricApiModel.FromMetric(await _context.Metrics
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }

    }

}
