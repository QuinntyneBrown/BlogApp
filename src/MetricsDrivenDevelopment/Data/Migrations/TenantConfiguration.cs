using System.Data.Entity.Migrations;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using System;

namespace MetricsDrivenDevelopment.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(MetricsDrivenDevelopmentContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default",
                UniqueId = new Guid("81d1409a-13b5-43d8-a3b0-bf9d29bc6aa0")
            });

            context.SaveChanges();
        }
    }
}
