using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo
{
    public class IFRSDemoClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoClientModule).GetAssembly());
        }
    }
}
