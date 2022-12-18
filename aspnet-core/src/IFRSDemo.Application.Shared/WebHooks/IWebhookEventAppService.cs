using System.Threading.Tasks;
using Abp.Webhooks;

namespace IFRSDemo.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
