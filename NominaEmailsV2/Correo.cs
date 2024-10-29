using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;

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
        //public string RutaDestino { set; get; } = string.Empty;

        public async Task<bool> ProbarAsync(Correo correo)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var mailMessage = new MimeMessage())
                    {
                        ServicePointManager.ServerCertificateValidationCallback = (delegate { return true; });

                        mailMessage.From.Add(new MailboxAddress("Nómina", correo.Email));
                        mailMessage.To.Add(new MailboxAddress(string.Empty, correo.Email));
                        mailMessage.Subject = "Correo de prueba";

                        BodyBuilder bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody = "Esto es un correo de prueba";
                        mailMessage.Body = bodyBuilder.ToMessageBody();

                        using (var smtpClient = new SmtpClient())
                        {
                            smtpClient.Connect(correo.Servidor, Convert.ToInt32(correo.Puerto), correo.Ssl);
                            smtpClient.Authenticate(correo.Usuario, correo.Contrasenia);
                            smtpClient.Send(mailMessage);
                            smtpClient.Disconnect(true);
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
