using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    [DependsOn(typeof(IFRSDemoCoreSharedModule))]
    public class IFRSDemoApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoApplicationSharedModule).GetAssembly());
        }
    }
}