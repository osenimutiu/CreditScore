using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
