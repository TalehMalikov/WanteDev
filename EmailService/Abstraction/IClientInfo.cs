using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSending.Abstraction
{
    public interface IClientInfo
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string SMTPServerHost { get; set; }
        public int STMPServerPort { get; set; }

    }
}
