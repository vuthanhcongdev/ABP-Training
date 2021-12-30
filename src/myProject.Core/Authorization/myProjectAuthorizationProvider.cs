using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace myProject.Authorization
{
    public class myProjectAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var user = context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            user.CreateChildPermission(PermissionNames.Pages_Users_Create);
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, myProjectConsts.LocalizationSourceName);
        }
    }
}
