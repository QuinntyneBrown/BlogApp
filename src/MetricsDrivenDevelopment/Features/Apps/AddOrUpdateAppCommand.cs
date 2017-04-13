using MediatR;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using MetricsDrivenDevelopment.Features.Core;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Features.Apps
{
    public class AddOrUpdateAppCommand
    {
        public class AddOrUpdateAppRequest : IRequest<AddOrUpdateAppResponse>
        {
            public AppApiModel App { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class AddOrUpdateAppResponse { }

        public class AddOrUpdateAppHandler : IAsyncRequestHandler<AddOrUpdateAppRequest, AddOrUpdateAppResponse>
        {
            public AddOrUpdateAppHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<AddOrUpdateAppResponse> Handle(AddOrUpdateAppRequest request)
            {
                var entity = await _context.Apps
                    .Include(x => x.Tenant)
                    .SingleOrDefaultAsync(x => x.Id == request.App.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                
                if (entity == null) {
                    var tenant = await _context.Tenants.SingleAsync(x => x.UniqueId == request.TenantUniqueId);
                    _context.Apps.Add(entity = new App() { TenantId = tenant.Id });
                }

                entity.Name = request.App.Name;
                
                await _context.SaveChangesAsync();

                return new AddOrUpdateAppResponse();
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }
    }
}