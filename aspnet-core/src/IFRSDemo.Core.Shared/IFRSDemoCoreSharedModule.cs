using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    public class IFRSDemoCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoCoreSharedModule).GetAssembly());
        }
    }
}