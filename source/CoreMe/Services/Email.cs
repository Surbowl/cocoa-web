using System.Net;
using System.Net.Mail;

namespace CoreMe.Services
{
    public class Email
    {
        private readonly EmailOptions _options;

        public Email(EmailOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// 发送Email
        /// </summary>
        /// <param name="subject">Email标题</param>
        /// <param name="body">Email正文</param>
        /// <returns>发送成功？</returns>
        public bool Send(string subject, string body)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return false;
            }
            try
            {
                //发件邮箱、收件邮箱
                MailMessage mailMessage = new MailMessage(_options.From, _options.To, subject, body);
                //邮件优先级
                mailMessage.Priority = MailPriority.Normal;
                //smtp服务器的url与端口号
                new SmtpClient(_options.SmtpHost, _options.SmtpPort)
                {
                    //smtp账号与密码
                    Credentials = new NetworkCredential(_options.SmtpUser, _options.SmtpPassword),
                    //是否启用SSL
                    EnableSsl = _options.EnableSsl
                }.Send(mailMessage);
                return true;
            }
            catch
            {
            }
            return false;
        }
    }
}
