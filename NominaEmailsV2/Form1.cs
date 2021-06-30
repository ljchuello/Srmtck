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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace NominaEmailsV2
{
    public partial class Form1 : MetroForm
    {
        private Correo _correo = new Correo();

        public Form1()
        {
            InitializeComponent();
            Text = @"Envio recibos";

            CheckForIllegalCrossThreadCalls = false;

            // Leemos
            _correo = Fichero.Leer();

            // Seteamos
            txtCorreo.Text = _correo.Email;
            txtUsuario.Text = _correo.Usuario;
            txtContrasenia.Text = _correo.Contrasenia;
            txtServidorSalida.Text = _correo.Servidor;
            txtPuertoSalida.Text = _correo.Puerto;
            chSsl.Checked = _correo.Ssl;

            // Rutas
            txtRutaOrigen.Text = _correo.RutaOrigen;
            txtRutaDestino.Text = _correo.RutaDestino;
        }

        async Task<bool> ValidarEmailAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (txtCorreo.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un correo electrónico", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtUsuario.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un usuario", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtContrasenia.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar una contraseña", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtServidorSalida.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un servidor de salida", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtPuertoSalida.Text.Length <= 0)
                    {
                        MessageBox.Show("Debe ingresar un puerto de salida", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _correo.RutaOrigen = txtRutaOrigen.Text;
                    _correo.RutaDestino = txtRutaDestino.Text;

                    if (await _correo.ProbarAsync(_correo) == false)
                    {
                        return false;
                    }

                    // Guardamos
                    Fichero.Guardar(_correo);

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
                MessageBox.Show("Se ha valido el correo de manera exitosa", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtRuta_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtRutaOrigen.Text = $"{dialog.FileName}";
            }
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                // Validamos el directorio origen
                if (!Directory.Exists(txtRutaOrigen.Text))
                {
                    MessageBox.Show("La ruta de origen no es válida, selecciona una ruta.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Validamos el directorio destino
                if (!Directory.Exists(txtRutaDestino.Text))
                {
                    MessageBox.Show("La ruta de destino no es válida, selecciona una ruta.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // probamos
                _correo = new Correo();
                _correo.Email = txtCorreo.Text;
                _correo.Usuario = txtUsuario.Text;
                _correo.Contrasenia = txtContrasenia.Text;
                _correo.Servidor = txtServidorSalida.Text;
                _correo.Puerto = txtPuertoSalida.Text;
                _correo.Ssl = chSsl.Checked;
                _correo.RutaOrigen = txtRutaOrigen.Text;
                _correo.RutaDestino = txtRutaDestino.Text;

                if (await _correo.ProbarAsync(_correo) == false)
                {
                    return;
                }

                // Grabamos
                Fichero.Guardar(_correo);

                // Leemos el directorio
                List<Pdf> files = new List<Pdf>();

                // formateamos
                foreach (var row in Directory.GetFiles(txtRutaOrigen.Text).ToList())
                {
                    // pdf
                    Pdf pdf = new Pdf();

                    // Validamos que sea extensión .pdf
                    if (row.ToLower().Contains("pdf"))
                    {
                        // Seteamos el nombre
                        string carpeta = "";
                        string email = "";
                        string reciboId = "";

                        // File
                        FileInfo fileInfo = new FileInfo(row);

                        // Set recibo
                        reciboId = fileInfo.Name.ToLower();
                        reciboId = reciboId.Replace(" ", string.Empty);
                        reciboId = reciboId.Substring(0, reciboId.IndexOf("_"));

                        // Ruta
                        carpeta = reciboId.Substring(0, 2);

                        // Email
                        email = fileInfo.Name.ToLower();
                        email = email.Replace(" ", string.Empty);
                        email = email.Replace($"{reciboId}_", string.Empty);
                        email = email.Replace(".pdf", string.Empty);

                        // Set final
                        reciboId = reciboId.ToUpper();
                        email = email.ToLower();
                        

                        // validamos el correo eletrónico
                        if (Pdf.Validar(email))
                        {
                            // Seteamos
                            pdf.Filename = row;
                            pdf.Email = email;
                            pdf.Ruta = carpeta;

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

                        // Movemos
                        FileInfo fileInfo = new FileInfo(row.Filename);
                        string destino = $"{txtRutaDestino.Text}\\{row.Ruta}";
                        Fichero.Mover(fileInfo, destino);
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
                    mailMessage.Subject = $"Envío de recibo";
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Body = "<p>Estimado Cliente reciba un cordial saludo de Grupo ANCON le informamos que se ha procedido al registro de su abono, el mismo que se detalla en el Recibo de Caja adjunto.</p>" +
                                       "<p>&nbsp;</p>" +
                                       "<p>Agradecemos su pago</p>" +
                                       "<p>&nbsp;</p>" +
                                       "<p>Estamos para brindarle un excelente servicio, Saludos.</p>";
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
