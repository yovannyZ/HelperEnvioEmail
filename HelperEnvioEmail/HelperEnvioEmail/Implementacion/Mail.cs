using HelperEnvioEmail.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperEnvioEmail.Intercambio;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace HelperEnvioEmail.Implementacion
{
    public class Mail : IMail
    {
        private MailRequest request;

        /// <summary>
        /// Enviars the email.
        /// </summary>
        /// <param name="request">Los parametros del Email.</param>
        /// <returns></returns>
        public MailResponse EnviarEmail(MailRequest request)
        {
            MailResponse response = new MailResponse();
            this.request = request;
            response = Validate();

            if(!response.Exito)
                return response;

            response = ArmarEmail();

            return response;
        }

        private MailResponse Validate()
        {
            MailResponse response = new MailResponse();
            response.Exito = true;

            if (string.IsNullOrWhiteSpace(request.Body))
            {
                response.Exito = false;
                response.MensajeError = "No ingreso el cuerpo del Email";
                response.Pila = response.MensajeError;
            }
            else if (request.Credentials == null || string.IsNullOrWhiteSpace(request.Credentials.Password) ||
                string.IsNullOrWhiteSpace(request.Credentials.Username))
            {
                response.Exito = false;
                response.MensajeError = "No se ingreso las credenciales del Emisor";
                response.Pila = response.MensajeError;
            }
            else if (request.IsFile && request.Files.Count == 0)
            {
                response.Exito = false;
                response.MensajeError = "No existen archivos adjuntos";
                response.Pila = response.MensajeError;
            }
            else if (string.IsNullOrWhiteSpace(request.From))
            {
                response.Exito = false;
                response.MensajeError = "No existe el email del Emisor";
                response.Pila = response.MensajeError;
            }
            else if (string.IsNullOrWhiteSpace(request.Subject))
            {
                response.Exito = false;
                response.MensajeError = "No existe el asunto del email";
                response.Pila = response.MensajeError;
            }
            else if (string.IsNullOrWhiteSpace(request.To))
            {
                response.Exito = false;
                response.MensajeError = "No existe el destinatario(s) del email";
                response.Pila = response.MensajeError;
            }
            return response;
                   
        }

        private MailResponse ArmarEmail()
        {
            MailResponse response = new MailResponse();
            MailMessage Email = new MailMessage();
            SmtpClient smtpMail = new SmtpClient();

            try
            {
                Email.Subject = request.Subject;
                Email.To.Add(request.To);
                Email.Body = request.Body;

                if (request.IsFile)
                {
                    foreach (string archivo in request.Files)
                    {
                        if (File.Exists(@archivo))
                            Email.Attachments.Add(new Attachment(@archivo));
                    }
                }

                Email.IsBodyHtml = true;
                Email.From = new MailAddress(request.From);

                smtpMail.EnableSsl = request.Configuration.EnableSsl;
                smtpMail.UseDefaultCredentials = false;
                smtpMail.Host = request.Configuration.Host;
                smtpMail.Port = request.Configuration.Port;
                smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpMail.Credentials = new NetworkCredential(request.Credentials.Username, request.Credentials.Password);
                smtpMail.Timeout = 300000;
                smtpMail.Send(Email);
                Email.Attachments.Dispose();
                Email.Dispose();
                smtpMail.Dispose();

                response.Exito = true;

            }
            catch (Exception ex)
            {
                response.Exito = false;
                response.MensajeError = ex.Message;
                response.Pila = ex.StackTrace;
            }

            return response;
        }
    }
}
