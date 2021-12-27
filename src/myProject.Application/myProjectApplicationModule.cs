using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myProject.Authorization;

namespace myProject
{
    [DependsOn(
        typeof(myProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class myProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<myProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(myProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
