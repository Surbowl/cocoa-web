using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CoreMe.Func
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }

        /// <summary>
        /// 发送Email
        /// </summary>
        /// <param name="subject">Email标题</param>
        /// <param name="body">Email正文</param>
        /// <returns>发送成功？</returns>
        public bool Send(string subject, string body)
        {
            try
            {
                //发件邮箱、收件邮箱
                MailMessage mailMessage = new MailMessage(this.From, this.To, subject, body);
                //邮件优先级
                mailMessage.Priority = MailPriority.Normal;
                //smtp服务器的url与端口号
                SmtpClient smtpClient = new SmtpClient(this.SmtpHost, this.SmtpPort);
                //smtp账号与密码
                smtpClient.Credentials = new NetworkCredential(this.SmtpUser, this.SmtpPassword);
                //是否启用SSL
                smtpClient.EnableSsl = this.EnableSsl;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {

            }
            return false;
        }
    }
}
