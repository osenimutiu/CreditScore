using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using IFRSDemo.Configuration;
using IFRSDemo.EntityFrameworkCore;
using IFRSDemo.Migrator.DependencyInjection;

namespace IFRSDemo.Migrator
{
    [DependsOn(typeof(IFRSDemoEntityFrameworkCoreModule))]
    public class IFRSDemoMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public IFRSDemoMigratorModule(IFRSDemoEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(IFRSDemoMigratorModule).GetAssembly().GetDirectoryPathOrNull(),
                addUserSecrets: true
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                IFRSDemoConsts.ConnectionStringName
                );
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}