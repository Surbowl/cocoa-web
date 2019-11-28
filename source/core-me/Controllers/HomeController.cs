using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMe.Models;
using Microsoft.Extensions.Options;
using CoreMe.Func;

/// <summary>
/// 
/// ASP.NET Core 2.1 MVC
/// Microsoft Visual Studio Community 2019 v16.3.10
/// Open Source on https://github.com/Surbowl/core-me
/// by:Surbowl
/// 
/// </summary>

namespace CoreMe.Controllers
{
    public class HomeController : Controller
    {
        private Email myEmail;

        public HomeController(IOptions<Email> emailOptions)
        {
            this.myEmail = emailOptions.Value;
        }

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Message(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                //将留言通过Smtp发送至Email
                //邮件标题
                string subject = "core-me打招呼_" + DateTime.Now.ToString("f");
                //邮件正文
                string body = $"来自：{model.name}\nEmail：{model.email}\n联系电话：{model.phone}\n\n{model.content}";
                //发送
                Task<bool> sendEMailTask = Task.Run(() => this.myEmail.Send(subject, body));
                //Debug.WriteLine(model.name);
                //Debug.WriteLine(model.email);
                //Debug.WriteLine(model.phone);
                //Debug.WriteLine(model.content);
                //邮件发送状态
                string state = await sendEMailTask ? "succeed" : "faild";
                return Json(new
                {
                    state = state
                });
            }
            return Json(new
            {
                state = "invalid"
            });
        }

        #endregion Index

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
