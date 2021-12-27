using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace myProject.EntityFrameworkCore
{
    public static class myProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<myProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<myProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
