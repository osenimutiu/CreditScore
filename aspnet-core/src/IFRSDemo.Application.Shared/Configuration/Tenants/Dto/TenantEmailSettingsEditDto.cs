using Abp.Auditing;
using IFRSDemo.Configuration.Dto;

namespace IFRSDemo.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}