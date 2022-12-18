using System.Threading.Tasks;

namespace IFRSDemo.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}