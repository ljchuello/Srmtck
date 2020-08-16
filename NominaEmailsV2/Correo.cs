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
                        mailMessage.Body = "Rol de pago";
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

                    // Guardamos
                    Fichero.Guardar(Fichero.Tipo.Sermatick_Correo, JsonConvert.SerializeObject(correo));

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
