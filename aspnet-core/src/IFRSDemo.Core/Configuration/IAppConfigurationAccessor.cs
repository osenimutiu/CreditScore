using Microsoft.Extensions.Configuration;

namespace IFRSDemo.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
