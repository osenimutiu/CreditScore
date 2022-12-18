using Microsoft.AspNetCore.Mvc;
using IFRSDemo.Web.Controllers;

namespace IFRSDemo.Web.Public.Controllers
{
    public class AboutController : IFRSDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}