using HelperEnvioEmail.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperEnvioEmail.Intercambio;

namespace HelperEnvioEmail.Implementacion
{
    public class Mail : IMail
    {
        private MailRequest request;
        public MailResponse EnviarEmail(MailRequest request)
        {
            MailResponse response = new MailResponse();
            this.request = request;

            return response;
        }

        private MailResponse Validate()
        {
            MailResponse response = new MailResponse();

            if (string.IsNullOrWhiteSpace(request.Body))
            {
                response.Exito = false;
                response.MensajeError = "No ingreso el cuerpo del Email";
            }
                   
        }
    }
}
