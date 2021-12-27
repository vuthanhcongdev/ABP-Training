using Abp.Authorization;
using myProject.Authorization.Roles;
using myProject.Authorization.Users;

namespace myProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
