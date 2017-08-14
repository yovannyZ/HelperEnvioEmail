using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperEnvioEmail.Intercambio
{
    /// <summary>
    /// Clase de configuración del envio de Email
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Gets or sets elservidor smtp.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets el puerto de salida del email.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets indica si la conexión es segura.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableSsl { get; set; }
    }
}
