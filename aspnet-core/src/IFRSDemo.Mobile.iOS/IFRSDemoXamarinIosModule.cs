using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    [DependsOn(typeof(IFRSDemoXamarinSharedModule))]
    public class IFRSDemoXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoXamarinIosModule).GetAssembly());
        }
    }
}