using Microsoft.AspNetCore.Mvc;
using IFRSDemo.Web.Controllers;

namespace IFRSDemo.Web.Public.Controllers
{
    public class HomeController : IFRSDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}