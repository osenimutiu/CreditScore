using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    [DependsOn(typeof(IFRSDemoClientModule), typeof(AbpAutoMapperModule))]
    public class IFRSDemoXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoXamarinSharedModule).GetAssembly());
        }
    }
}