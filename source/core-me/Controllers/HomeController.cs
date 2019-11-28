using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSI_website.Models;

namespace SSI_website.Controllers
{
    public class HomeController : Controller
    {
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
                string subject = "core-me打招呼_" + DateTime.Now.ToString("f");
                string body = $"来自：{model.name}\nEmail：{model.email}\n联系电话：{model.phone}\n\n{model.content}";
                Task<bool> sendEMailTask = Task.Run(() => SendEMail(subject, body));
                //Debug.WriteLine(model.name);
                //Debug.WriteLine(model.email);
                //Debug.WriteLine(model.phone);
                //Debug.WriteLine(model.content);
                string state = await sendEMailTask ? "succeed" : "faild";
                return Json(new
                {
                    state = state
                });
            }
            else
            {
                return Json(new
                {
                    state = "invalid"
                });
            }
        }

        /// <summary>
        /// 发送Email
        /// </summary>
        /// <param name="subject">Email标题</param>
        /// <param name="body">Email正文</param>
        /// <returns>fs</returns>
        private bool SendEMail(string subject, string body)
        {
            try
            {
                //发件邮箱、收件邮箱
                MailMessage mailMessage = new MailMessage("email@qq.com", "email@qq.com", subject, body);
                //邮件优先级
                mailMessage.Priority = MailPriority.Normal;
                //smtp服务器的url与端口号
                //小提示：阿里云等运营商禁用了25端口，建议使用其他端口
                SmtpClient smtpClient = new SmtpClient("smtp.qq.com", 587);
                //smtp账号与密码
                //通常smtp账号与发件邮箱相同
                smtpClient.Credentials = new NetworkCredential("email@qq.com", "password");
                //启用SSL
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {

            }
            return false;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
