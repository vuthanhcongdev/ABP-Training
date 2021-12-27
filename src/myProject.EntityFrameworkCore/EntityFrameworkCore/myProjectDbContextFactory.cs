using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using myProject.Configuration;
using myProject.Web;

namespace myProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class myProjectDbContextFactory : IDesignTimeDbContextFactory<myProjectDbContext>
    {
        public myProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<myProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            myProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(myProjectConsts.ConnectionStringName));

            return new myProjectDbContext(builder.Options);
        }
    }
}
