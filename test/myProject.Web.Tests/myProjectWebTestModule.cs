using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myProject.EntityFrameworkCore;
using myProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace myProject.Web.Tests
{
    [DependsOn(
        typeof(myProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class myProjectWebTestModule : AbpModule
    {
        public myProjectWebTestModule(myProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(myProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(myProjectWebMvcModule).Assembly);
        }
    }
}