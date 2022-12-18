using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IFRSDemo.Configuration;
using IFRSDemo.Web;

namespace IFRSDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class IFRSDemoDbContextFactory : IDesignTimeDbContextFactory<IFRSDemoDbContext>
    {
        public IFRSDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IFRSDemoDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            IFRSDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(IFRSDemoConsts.ConnectionStringName));

            return new IFRSDemoDbContext(builder.Options);
        }
    }
}