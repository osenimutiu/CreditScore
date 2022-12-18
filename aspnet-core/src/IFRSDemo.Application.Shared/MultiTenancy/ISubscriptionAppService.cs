using System.Threading.Tasks;
using Abp.Application.Services;

namespace IFRSDemo.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
