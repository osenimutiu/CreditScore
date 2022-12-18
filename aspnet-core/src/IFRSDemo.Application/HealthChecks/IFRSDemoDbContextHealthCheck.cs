using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using IFRSDemo.EntityFrameworkCore;

namespace IFRSDemo.HealthChecks
{
    public class IFRSDemoDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public IFRSDemoDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("IFRSDemoDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("IFRSDemoDbContext could not connect to database"));
        }
    }
}
