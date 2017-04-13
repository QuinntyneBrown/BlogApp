using MediatR;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MetricsDrivenDevelopment.Features.Core;
using static MetricsDrivenDevelopment.Features.Metrics.AddOrUpdateMetricCommand;
using static MetricsDrivenDevelopment.Features.Metrics.GetMetricsQuery;
using static MetricsDrivenDevelopment.Features.Metrics.GetMetricByIdQuery;
using static MetricsDrivenDevelopment.Features.Metrics.RemoveMetricCommand;

namespace MetricsDrivenDevelopment.Features.Metrics
{
    [Authorize]
    [RoutePrefix("api/metric")]
    public class MetricController : ApiController
    {
        public MetricController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateMetricResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateMetricRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateMetricResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateMetricRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetMetricsResponse))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetMetricsRequest();
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetMetricByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetMetricByIdRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveMetricResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveMetricRequest request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
