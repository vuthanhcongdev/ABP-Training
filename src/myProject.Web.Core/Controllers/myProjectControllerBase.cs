using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace myProject.Controllers
{
    public abstract class myProjectControllerBase: AbpController
    {
        protected myProjectControllerBase()
        {
            LocalizationSourceName = myProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
