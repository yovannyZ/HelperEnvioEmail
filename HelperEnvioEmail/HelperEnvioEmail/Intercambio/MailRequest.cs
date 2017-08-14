using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperEnvioEmail.Intercambio
{
    /// <summary>
    /// Clase de solicitud de envio de email
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// Gets or sets el email del emisor.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public string From { get; set; }
        /// <summary>
        /// Gets or sets emails destinatario(mas de un email separado por ',').
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public string To { get; set; }
        /// <summary>
        /// Gets or sets el cuerpo del mensaje.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets los aarchivos adjuntos.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<string> Files { get; set; }
        /// <summary>
        /// Gets or sets el asunto del email.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets indica si el email contiene archivos adjuntos.
        /// </summary>
        /// <value>
        ///   <c>true</c> si contiene archibos adjuntos; no contiene archivos adjuntos <c>false</c>.
        /// </value>
        public bool IsFile { get; set; }
        /// <summary>
        /// Gets or sets las credenciales del emisor.
        /// </summary>
        /// <value>
        /// The credentials.
        /// </value>
        public Credentials Credentials { get; set; }
        /// <summary>
        /// Gets or sets la configuracion del envio de email.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Configuration Configuration { get; set; }
        
    }
}
