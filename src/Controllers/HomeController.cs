using Microsoft.AspNetCore.Mvc;

namespace Cocoa.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// SPA entry point
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}