using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NominaEmailsV2
{
    public class Correo
    {
        public string Email { set; get; } = string.Empty;
        public string Usuario { set; get; } = string.Empty;
        public string Contrasenia { set; get; } = string.Empty;
        public string Servidor { set; get; } = string.Empty;
        public string Puerto { set; get; } = string.Empty;
        public bool Ssl { set; get; } = true;
        public string RutaOrigen { set; get; } = string.Empty;
        public string RutaDestino { set; get; } = string.Empty;

        public async Task<bool> ProbarAsync(Correo correo)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // Prioridad
                    ServicePointManager.ServerCertificateValidationCallback = (delegate { return true; });

                    // Construimos el correo
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.To.Add("noresponder@sermatick.com");
                        mailMessage.From = new MailAddress(correo.Email, $"Sermatick", Encoding.UTF8);
                        mailMessage.Subject = "Resumen rol de pago";
                        mailMessage.SubjectEncoding = Encoding.UTF8;
                        mailMessage.Body = "<p>Estimado Cliente reciba un cordial saludo de Grupo ANCON le informamos que se ha procedido al registro de su abono, el mismo que se detalla en el Recibo de Caja adjunto." +
                                           "<br/>Agradecemos su pago" +
                                           "<br/>Estamos para brindarle un excelente servicio, Saludos.<p>";
                        mailMessage.BodyEncoding = Encoding.UTF8;
                        mailMessage.IsBodyHtml = true;

                        // Enviamos
                        using (SmtpClient smtpClient = new SmtpClient())
                        {
                            smtpClient.Credentials = new NetworkCredential(correo.Usuario, correo.Contrasenia);
                            smtpClient.Port = Convert.ToInt32(correo.Puerto);
                            smtpClient.Host = correo.Servidor;
                            smtpClient.EnableSsl = correo.Ssl;
                            smtpClient.Send(mailMessage);
                        }
                    }

                    // Libre de pecados
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha pidodo enviar el correo electrónco\n\nAh ocurrido un error; {ex.Message}");
                    return false;
                }
            });
        }
    }
}
