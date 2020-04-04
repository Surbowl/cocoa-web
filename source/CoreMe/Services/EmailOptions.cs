namespace CoreMe.Services
{
    public class EmailOptions
    {
        public string From { get; set; }
        public string To { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
    }
}
