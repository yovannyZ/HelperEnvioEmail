using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperEnvioEmail.Intercambio
{
    public class MailRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public List<string> Files { get; set; }
        public string Subject { get; set; }
        public Credentials Credentials { get; set; }
        public Configuration Configuration { get; set; }
        
    }
}
