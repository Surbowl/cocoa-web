using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMe.Models;
using Microsoft.Extensions.Options;
using CoreMe.Func;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Microsoft.AspNetCore.Http;

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
        private readonly IHttpContextAccessor _accessor;
        private readonly Email _email;
        private readonly IDistributedCache _cache;

        public HomeController(IHttpContextAccessor accessor, IOptions<Email> email, IDistributedCache cache)
        {
            this._accessor = accessor;
            //获取Smtp发送Email的类
            this._email = email.Value;
            //Redis缓存实现
            this._cache = cache;
        }

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 发送留言
        /// 请注意，如果未启动Redis服务，将产生错误500
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Api/Message")]
        public async Task<JsonResult> Message(MessageViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //获取用户ip（ipv4 or ipv6）
                    string userIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString() ?? "::0";
                    //访问Redis，根据用户ip判断用户是否在20秒内发表过了留言
                    //Redis中的键值对为  UserIpAddress : DateTime
                    var value = await _cache.GetAsync(userIpAddress);
                    if (value != null)
                    {
                        //次ip与允许发表下一个评论的时间
                        DateTime lastTime = DateTime.FromBinary(BitConverter.ToInt64(value, 0));
                        //距离现在多少秒
                        double seconds = (lastTime - DateTime.Now).TotalSeconds;
                        if (seconds > 0)
                        {
                            return Json(new
                            {
                                state = "wait",
                                //告诉前台还需要倒计时几秒，向上取整
                                timeo = (int)Math.Ceiling(seconds)
                            });
                        }
                    }
                    //将留言通过Smtp发送至Email
                    //邮件标题
                    string subject = "core-me打招呼_" + DateTime.Now.ToString("f");
                    //邮件正文
                    string body = $"来自：{model.name}\nEmail：{model.email}\n联系电话：{model.phone}\n\n{model.content}";
                    //发送邮件
                    if (this._email.Send(subject, body))
                    {
                        //发送成功
                        //向Redis写入用户ip与允许发表下一个评论的时间，并设置数据有效期
                        var options = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(20));
                        await _cache.SetAsync(userIpAddress, BitConverter.GetBytes(DateTime.Now.AddSeconds(20).ToBinary()), options);
                        return Json(new
                        {
                            state = "succeed",
                            timeo = 20
                        }); ;
                    }
                    else
                    {
                        //发送失败
                        return Json(new
                        {
                            state = "faild",
                            timeo = 3
                        });
                    }

                }
                return Json(new
                {
                    state = "invalid",
                    timeo = 5
                });
            }
            catch
            {

            }
            return Json(new
            {
                state = "error",
                timeo = 5
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