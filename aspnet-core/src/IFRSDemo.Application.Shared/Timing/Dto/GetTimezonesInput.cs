using Abp.Configuration;

namespace IFRSDemo.Timing.Dto
{
    public class GetTimezonesInput
    {
        public SettingScopes DefaultTimezoneScope { get; set; }
    }
}
