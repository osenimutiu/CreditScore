using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}