using Abp.Modules;
using IFRSDemo.Test.Base;

namespace IFRSDemo.Tests
{
    [DependsOn(typeof(IFRSDemoTestBaseModule))]
    public class IFRSDemoTestModule : AbpModule
    {
       
    }
}
