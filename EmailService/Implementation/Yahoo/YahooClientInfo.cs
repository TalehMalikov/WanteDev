using EmailSending.Abstraction;

namespace EmailSending
{
    public class YahooClientInfo : IClientInfo
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string SMTPServerHost { get; set; } = "smtp.mail.yahoo.com";
        public int STMPServerPort { get; set; } = 587; 
    }
}