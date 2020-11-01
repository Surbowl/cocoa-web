using Cocoa.Web.Entities;
using Cocoa.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cocoa.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// SPA entry point
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Message Api
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<JsonResult> PostMessage([FromBody] MessageDto message )
        {
            if (message == null)
            {
                return Json(new ApiResult(400, "Bad request"));
            }
            if (string.IsNullOrWhiteSpace(message.Name))
            {
                return Json(new ApiResult(401, "请输入昵称"));
            }
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                return Json(new ApiResult(401, "请输入内容"));
            }

            // Process message here
            _logger.LogInformation($"Receive new message:\n${message}");
#if RELEASE
            throw new NotImplementedException();
#endif
            //

            return Json(new ApiResult(200, "发送成功"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}