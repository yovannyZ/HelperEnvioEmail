using HelperEnvioEmail.Intercambio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperEnvioEmail.Interface
{
    public interface IMail
    {
        MailResponse EnviarEmail(MailRequest request);

    }
}
