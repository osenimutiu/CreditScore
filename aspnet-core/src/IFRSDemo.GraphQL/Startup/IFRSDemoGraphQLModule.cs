using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace IFRSDemo.Startup
{
    [DependsOn(typeof(IFRSDemoCoreModule))]
    public class IFRSDemoGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}