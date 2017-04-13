using MetricsDrivenDevelopment.Data.Model;

namespace MetricsDrivenDevelopment.Features.Apps
{
    public class AppApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromApp<TModel>(App app) where
            TModel : AppApiModel, new()
        {
            var model = new TModel();
            model.Id = app.Id;
            model.TenantId = app.TenantId;
            model.Name = app.Name;
            return model;
        }

        public static AppApiModel FromApp(App app)
            => FromApp<AppApiModel>(app);

    }
}
