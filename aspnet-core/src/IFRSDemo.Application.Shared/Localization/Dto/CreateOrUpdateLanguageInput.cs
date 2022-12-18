using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}