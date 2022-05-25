using EmailSending.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSending
{
    public abstract class BaseEmailSender
    {
        protected readonly IClientInfo clientInfo;

        public BaseEmailSender(IClientInfo clientInfo)
        {
            this.clientInfo = clientInfo;
        }

        public abstract EmailSendResult SendEmail(EmailMessage Message);
    }
}
