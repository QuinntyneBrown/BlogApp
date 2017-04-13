using MediatR;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Features.Apps
{
    public class GetAppByIdQuery
    {
        public class GetAppByIdRequest : IRequest<GetAppByIdResponse> { 
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class GetAppByIdResponse
        {
            public AppApiModel App { get; set; } 
        }

        public class GetAppByIdHandler : IAsyncRequestHandler<GetAppByIdRequest, GetAppByIdResponse>
        {
            public GetAppByIdHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetAppByIdResponse> Handle(GetAppByIdRequest request)
            {                
                return new GetAppByIdResponse()
                {
                    App = AppApiModel.FromApp(await _context.Apps
                    .Include(x => x.Tenant)				
					.SingleAsync(x=>x.Id == request.Id &&  x.Tenant.UniqueId == request.TenantUniqueId))
                };
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }

    }

}
