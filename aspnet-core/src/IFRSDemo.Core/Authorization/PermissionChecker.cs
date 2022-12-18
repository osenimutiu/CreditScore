using Abp.Authorization;
using IFRSDemo.Authorization.Roles;
using IFRSDemo.Authorization.Users;

namespace IFRSDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
