using Xunit;

namespace IFRSDemo.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        private readonly bool _multiTenancyEnabled = IFRSDemoConsts.MultiTenancyEnabled;

        public MultiTenantFactAttribute()
        {
            if (!_multiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
