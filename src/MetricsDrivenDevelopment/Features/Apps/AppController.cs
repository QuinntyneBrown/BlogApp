using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MetricsDrivenDevelopment.Features.Core;
using static MetricsDrivenDevelopment.Features.Apps.AddOrUpdateAppCommand;
using static MetricsDrivenDevelopment.Features.Apps.GetAppsQuery;
using static MetricsDrivenDevelopment.Features.Apps.GetAppByIdQuery;
using static MetricsDrivenDevelopment.Features.Apps.RemoveAppCommand;

namespace MetricsDrivenDevelopment.Features.Apps
{
    [Authorize]
    [RoutePrefix("api/app")]
    public class AppController : ApiController
    {
        public AppController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateAppResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateAppRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateAppResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateAppRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetAppsResponse))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetAppsRequest();
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetAppByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetAppByIdRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveAppResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveAppRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
