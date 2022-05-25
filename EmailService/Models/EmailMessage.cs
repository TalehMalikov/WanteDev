using System.Collections.Generic;

namespace EmailSending
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> TO { get; set; }
        public bool IsBodyHtml { get; set; }
       
    }

}