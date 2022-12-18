using Abp.Configuration;
using Abp.Net.Mail;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Security;

namespace IFRSDemo.Net.Emailing
{
    public class IFRSDemoSmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        public IFRSDemoSmtpEmailSenderConfiguration(ISettingManager settingManager) : base(settingManager)
        {

        }

        public override string Password => SimpleStringCipher.Instance.Decrypt(GetNotEmptySettingValue(EmailSettingNames.Smtp.Password));
    }
}