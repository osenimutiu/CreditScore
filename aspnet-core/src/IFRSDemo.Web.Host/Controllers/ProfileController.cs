using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using IFRSDemo.Authorization.Users.Profile;
using IFRSDemo.Storage;

namespace IFRSDemo.Web.Controllers
{
    [Authorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService) :
            base(tempFileCacheManager, profileAppService)
        {
        }
    }
}