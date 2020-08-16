using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace NominaEmailsV2
{
    public partial class Form1 : MetroForm
    {
        private Correo _correo = new Correo();

        public Form1()
        {
            InitializeComponent();
            Text = "Nómina Emails V2";

            CheckForIllegalCrossThreadCalls = false;

            // Leemos
            _correo = JsonConvert.DeserializeObject<Correo>(Fichero.Leer(Fichero.Tipo.Sermatick_Correo)) ?? new Correo();

            // Seteamos
            txtCorreo.Text = _correo.Email;
            txtUsuario.Text = _correo.Usuario;
            txtContrasenia.Text = _correo.Contrasenia;
            txtServidorSalida.Text = _correo.Servidor;
            txtPuertoSalida.Text = _correo.Puerto;
            chSsl.Checked = _correo.Ssl;

            // Volvemos a leer
            txtRuta.Text = Fichero.Leer(Fichero.Tipo.Sermatick_Ruta) ?? string.Empty;
        }

        async Task<bool> ValidarEmailAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (txtCorreo.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un correo electrónico", string.Empty, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtUsuario.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un usuario", string.Empty, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtContrasenia.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar una contraseña", string.Empty, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtServidorSalida.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un servidor de salida", string.Empty, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtPuertoSalida.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un puerto de salida", string.Empty, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    // probamos
                    _correo = new Correo();
                    _correo.Email = txtCorreo.Text;
                    _correo.Usuario = txtUsuario.Text;
                    _correo.Contrasenia = txtContrasenia.Text;
                    _correo.Servidor = txtServidorSalida.Text;
                    _correo.Puerto = txtPuertoSalida.Text;
                    _correo.Ssl = chSsl.Checked;

                    if (await _correo.ProbarAsync(_correo) == false)
                    {
                        return false;
                    }

                    // Libre de pecados
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });
        }

        private async void metroButton2_Click(object sender, EventArgs e)
        {
            bool exitoso = await ValidarEmailAsync();

            if (exitoso)
            {
                MessageBox.Show("Se ha valido el correo de manera exitosa", string.Empty, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtRuta_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtRuta.Text = $"{dialog.FileName}";
            }
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                // Validamos el directorio
                if (!Directory.Exists(txtRuta.Text))
                {
                    MessageBox.Show("La ruta no es válida, selecciona una ruta.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si la ruta es válida, la guardamos
                Fichero.Guardar(Fichero.Tipo.Sermatick_Ruta, txtRuta.Text);

                // probamos
                _correo = new Correo();
                _correo.Email = txtCorreo.Text;
                _correo.Usuario = txtUsuario.Text;
                _correo.Contrasenia = txtContrasenia.Text;
                _correo.Servidor = txtServidorSalida.Text;
                _correo.Puerto = txtPuertoSalida.Text;
                _correo.Ssl = chSsl.Checked;

                if (await _correo.ProbarAsync(_correo) == false)
                {
                    return;
                }

                // Leemos el directorio
                List<Pdf> files = new List<Pdf>();

                // formateamos
                foreach (var row in Directory.GetFiles(txtRuta.Text).ToList())
                {
                    // pdf
                    Pdf pdf = new Pdf();

                    // Validamos que sea extensión .pdf
                    if (row.ToLower().Contains("pdf"))
                    {
                        // Seteamos el nombre
                        string email = row;

                        // Eliminamos el directorio
                        email = email.Replace(txtRuta.Text, string.Empty);

                        // Pasamos a minusculas
                        email = email.ToLower();

                        // Eliminamos el 202012_
                        email = email.Substring(8, email.Length - 8);

                        // Quitamos el .pdf
                        email = email.Replace(".pdf", string.Empty);

                        // validamos el correo eletrónico
                        if (Pdf.Validar(email))
                        {
                            // Seteamos
                            pdf.Filename = row;
                            pdf.Email = email;

                            // Añadimos
                            files.Add(pdf);
                        }
                        else
                        {
                            MessageBox.Show($"El archivo .pdf {row} no es válido.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                metroButton1.Enabled = false;

                int exitosos = 0;
                int fallidos = 0;

                // Recorremos y enviamos
                foreach (var row in files)
                {
                    if (Send(row.Email, row.Filename, _correo))
                    {
                        exitosos++;
                    }
                    else
                    {
                        fallidos++;
                    }

                    lblExitosos.Text = $"Exitosos: {exitosos:n0}";
                    lblFallidos.Text = $"Fallidos: {fallidos:n0}";
                    lblTotal.Text = $"Total: {files.Count:n0}";
                    lblFaltantes.Text = $"Faltantes: {files.Count - (exitosos + fallidos):n0}";
                }

                // Proceso terminado
                MessageBox.Show("Se ha terminado el proceso");
            });
        }

        public bool Send(string receptor, string file, Correo correo)
        {
            try
            {
                // Prioridad
                ServicePointManager.ServerCertificateValidationCallback = (delegate { return true; });

                FileInfo fileInfo = new FileInfo(file);

                // Construimos el correo
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.To.Add(receptor);
                    mailMessage.From = new MailAddress(correo.Email, correo.Email, Encoding.UTF8);

                    switch (fileInfo.Name.Substring(4, 2))
                    {
                        case "01":
                            mailMessage.Subject = $"ROL DE PAGOS de Enero {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "02":
                            mailMessage.Subject = $"ROL DE PAGOS de Febrero {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "03":
                            mailMessage.Subject = $"ROL DE PAGOS de Marzo {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "04":
                            mailMessage.Subject = $"ROL DE PAGOS de Abril {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "05":
                            mailMessage.Subject = $"ROL DE PAGOS de Mayo {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "06":
                            mailMessage.Subject = $"ROL DE PAGOS de Junio {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "07":
                            mailMessage.Subject = $"ROL DE PAGOS de Julio {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "08":
                            mailMessage.Subject = $"ROL DE PAGOS de Agosto {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "09":
                            mailMessage.Subject = $"ROL DE PAGOS de Septiembre {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "10":
                            mailMessage.Subject = $"ROL DE PAGOS de Octumbre {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "11":
                            mailMessage.Subject = $"ROL DE PAGOS de Noviembre {fileInfo.Name.Substring(0, 4)}";
                            break;
                        case "12":
                            mailMessage.Subject = $"ROL DE PAGOS de Diciembre {fileInfo.Name.Substring(0, 4)}";
                            break;
                    }

                    mailMessage.Subject = mailMessage.Subject.ToUpper();
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Body = $"Adjunto se encuentra su {mailMessage.Subject.ToLower()}.";
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = true;

                    // Adjuntamos
                    mailMessage.Attachments.Add(new Attachment(file));

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
                MessageBox.Show($"No se ha pidodo enviar el correo electrónca a {receptor}\n\nAh ocurrido un error; {ex.Message}");
                return false;
            }
        }
    }
}
