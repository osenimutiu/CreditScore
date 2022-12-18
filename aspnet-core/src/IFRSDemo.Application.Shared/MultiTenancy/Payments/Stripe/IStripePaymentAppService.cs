using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.MultiTenancy.Payments.Dto;
using IFRSDemo.MultiTenancy.Payments.Stripe.Dto;

namespace IFRSDemo.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}