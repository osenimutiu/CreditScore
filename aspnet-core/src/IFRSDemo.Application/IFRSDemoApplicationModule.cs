using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IFRSDemo.Authorization;

namespace IFRSDemo
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(IFRSDemoApplicationSharedModule),
        typeof(IFRSDemoCoreModule)
        )]
    public class IFRSDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoApplicationModule).GetAssembly());
        }
    }
}