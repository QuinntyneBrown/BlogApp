using MetricsDrivenDevelopment.Data.Model;
using System.Threading.Tasks;
using System.Security.Principal;
using MetricsDrivenDevelopment.Data;
using System.Data.Entity;

namespace MetricsDrivenDevelopment.Security
{
    public interface IUserManager
    {
        Task<User> GetUserAsync(IPrincipal user);
    }

    public class UserManager : IUserManager
    {
        public UserManager(IMetricsDrivenDevelopmentContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(IPrincipal user) => await _context
            .Users
            .Include(x=>x.Tenant)
            .SingleAsync(x => x.Username == user.Identity.Name);

        protected readonly IMetricsDrivenDevelopmentContext _context;
    }
}
