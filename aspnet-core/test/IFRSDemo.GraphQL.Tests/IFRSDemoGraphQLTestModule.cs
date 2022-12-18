using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using IFRSDemo.Configure;
using IFRSDemo.Startup;
using IFRSDemo.Test.Base;

namespace IFRSDemo.GraphQL.Tests
{
    [DependsOn(
        typeof(IFRSDemoGraphQLModule),
        typeof(IFRSDemoTestBaseModule))]
    public class IFRSDemoGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IFRSDemoGraphQLTestModule).GetAssembly());
        }
    }
}