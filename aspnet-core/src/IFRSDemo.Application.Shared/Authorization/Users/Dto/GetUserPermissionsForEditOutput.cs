using System.Collections.Generic;
using IFRSDemo.Authorization.Permissions.Dto;

namespace IFRSDemo.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}