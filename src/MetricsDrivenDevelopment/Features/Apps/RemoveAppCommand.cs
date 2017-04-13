using MediatR;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using MetricsDrivenDevelopment.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Features.Apps
{
    public class RemoveAppCommand
    {
        public class RemoveAppRequest : IRequest<RemoveAppResponse>
        {
            public int Id { get; set; }
            public Guid TenantUniqueId { get; set; } 
        }

        public class RemoveAppResponse { }

        public class RemoveAppHandler : IAsyncRequestHandler<RemoveAppRequest, RemoveAppResponse>
        {
            public RemoveAppHandler(MetricsDrivenDevelopmentContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<RemoveAppResponse> Handle(RemoveAppRequest request)
            {
                var app = await _context.Apps.SingleAsync(x=>x.Id == request.Id && x.Tenant.UniqueId == request.TenantUniqueId);
                app.IsDeleted = true;
                await _context.SaveChangesAsync();
                return new RemoveAppResponse();
            }

            private readonly MetricsDrivenDevelopmentContext _context;
            private readonly ICache _cache;
        }
    }
}
