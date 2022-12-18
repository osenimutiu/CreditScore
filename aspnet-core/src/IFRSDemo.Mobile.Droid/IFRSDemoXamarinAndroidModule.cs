using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    [DependsOn(typeof(IFRSDemoXamarinSharedModule))]
    public class IFRSDemoXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoXamarinAndroidModule).GetAssembly());
        }
    }
}