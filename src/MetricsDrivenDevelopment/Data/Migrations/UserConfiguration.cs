using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using MetricsDrivenDevelopment.Security;

namespace MetricsDrivenDevelopment.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(MetricsDrivenDevelopmentContext context) {

            var systemRole = context.Roles.First(x => x.Name == Roles.SYSTEM);
            var roles = new List<Role>();
            var tenant = context.Tenants.Single(x => x.Name == "Default");

            roles.Add(systemRole);

            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = "system",
                Password = new EncryptionService().TransformPassword("system"),
                Roles = roles,
                TenantId = tenant.Id
            });
                        
            context.SaveChanges();
        }
    }
}
