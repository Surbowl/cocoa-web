using Cocoa.Web.Models;

namespace Cocoa.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// SPA entry point
    /// </summary>
    /// <returns></returns>
    public IActionResult Index([FromQuery(Name = "lang")] string? language, [FromHeader(Name = "Accept-Language")] string? acceptLanguage)
    {
        if (!string.IsNullOrWhiteSpace(language))
        {
            switch (language.Trim().ToLower())
            {
                case "zh": return View("Zh");
                case "en": return View("En");
                default: break;
            }
        }

        if (acceptLanguage != null && acceptLanguage.Trim().StartsWith("zh", StringComparison.OrdinalIgnoreCase))
        {
            return View("Zh");
        }

        return View("En");
    }

    /// <summary>
    /// Message Board Api
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("api/[controller]/[action]")]
    public JsonResult Message([FromBody] MessageModel message)
    {
        _logger.LogInformation($"You have received a message:\n{message}");

        // process email here

        //return Json(new
        //{
        //    Code = 200,
        //    Message = "succeed",
        //    Countdown = 20
        //});

        return Json(new
        {
            Code = 500,
            Message = "Not Implemented Exception",
            Countdown = 20
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}