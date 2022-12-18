using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.MultiTenancy.Payments.PayPal.Dto;

namespace IFRSDemo.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
