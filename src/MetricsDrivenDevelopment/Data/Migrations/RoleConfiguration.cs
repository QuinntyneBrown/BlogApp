using System.Data.Entity.Migrations;
using MetricsDrivenDevelopment.Data;
using MetricsDrivenDevelopment.Data.Model;
using MetricsDrivenDevelopment.Features.Users;

namespace MetricsDrivenDevelopment.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(MetricsDrivenDevelopmentContext context) {

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.SYSTEM
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.ACCOUNT_HOLDER
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.DEVELOPMENT
            });

            context.SaveChanges();
        }
    }
}
