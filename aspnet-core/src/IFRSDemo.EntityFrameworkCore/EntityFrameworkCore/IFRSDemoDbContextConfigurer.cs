using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.EntityFrameworkCore
{
    public static class IFRSDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IFRSDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IFRSDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}