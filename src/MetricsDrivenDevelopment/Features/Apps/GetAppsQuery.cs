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
    public class GetAppsQuery
    {
        public class GetAppsRequest : IRequest<GetAppsResponse> { 
            public Guid TenantUniqueId { get; set; }       
        }

        public class GetAppsResponse
        {
            public ICollection<AppApiModel> Apps { get; set; } = new HashSet<AppApiModel>();
        }

        public class GetAppsHandler : IAsyncRequestHandler<GetAppsRequest, GetAppsResponse>
        {
            public GetAppsHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetAppsResponse> Handle(GetAppsRequest request)
            {
                var apps = await _context.Apps
                    .Include(x => x.Tenant)
                    .Where(x => x.Tenant.UniqueId == request.TenantUniqueId )
                    .ToListAsync();

                return new GetAppsResponse()
                {
                    Apps = apps.Select(x => AppApiModel.FromApp(x)).ToList()
                };
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }

    }

}
