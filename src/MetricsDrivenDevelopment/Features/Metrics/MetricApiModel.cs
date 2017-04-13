using MetricsDrivenDevelopment.Data.Model;

namespace MetricsDrivenDevelopment.Features.Metrics
{
    public class MetricApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromMetric<TModel>(Metric metric) where
            TModel : MetricApiModel, new()
        {
            var model = new TModel();
            model.Id = metric.Id;
            model.TenantId = metric.TenantId;
            model.Name = metric.Name;
            return model;
        }

        public static MetricApiModel FromMetric(Metric metric)
            => FromMetric<MetricApiModel>(metric);

    }
}
