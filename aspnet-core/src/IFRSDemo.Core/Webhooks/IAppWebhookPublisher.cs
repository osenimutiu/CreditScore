using System.Threading.Tasks;
using IFRSDemo.Authorization.Users;

namespace IFRSDemo.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
