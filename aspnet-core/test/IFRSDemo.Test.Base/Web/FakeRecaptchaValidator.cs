using System.Threading.Tasks;
using IFRSDemo.Security.Recaptcha;

namespace IFRSDemo.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
