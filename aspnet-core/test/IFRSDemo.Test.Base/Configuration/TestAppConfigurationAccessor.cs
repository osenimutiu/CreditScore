using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using IFRSDemo.Configuration;

namespace IFRSDemo.Test.Base.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(IFRSDemoTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
