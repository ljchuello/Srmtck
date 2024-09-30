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
            MessageBox.Show("Empezando validar la información en intentando enviar un correo de prueba.. Espere..");

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
                List<Pdf> listPdf = new List<Pdf>();

                // formateamos
                foreach (var row in Directory.GetFiles(txtRutaOrigen.Text).ToList())
                {
                    // pdf
                    Pdf pdf = new Pdf();

                    // Validamos que sea extensión .pdf
                    if (row.ToLower().Contains("pdf"))
                    {
                        // Fileinfo
                        FileInfo fileInfo = new FileInfo(row);

                        // Set
                        string full = fileInfo.Name;
                        string proyecto = string.Empty;
                        string nombre = string.Empty;
                        string recibo = string.Empty;
                        string correo = string.Empty;

                        // Validamos si tiene al menos 3 _
                        if (row.Count(x => x == '_') < 3)
                        {
                            MessageBox.Show($"El archivo {fileInfo.Name} no tiene el formato correcto");
                            return;
                        }

                        // proyecto
                        proyecto = full.Substring(0, full.IndexOf("_"));
                        //full = full.Replace($"{proyecto}_", string.Empty);
                        full = ReplaceFirst(full, $"{proyecto}_", string.Empty);

                        // nombre
                        nombre = full.Substring(0, full.IndexOf("_"));

                        //full = full.Replace($"{nombre}_", string.Empty);
                        full = ReplaceFirst(full, $"{nombre}_", string.Empty);

                        //nombre = nombre.Replace("-", " ");
                        nombre = nombre.Replace("-", " ");

                        // proyecto
                        recibo = full.Substring(0, full.IndexOf("_"));
                        //full = full.Replace($"{recibo}_", string.Empty);
                        full = ReplaceFirst(full, $"{recibo}_", string.Empty);

                        // correo
                        correo = full.ToLower();
                        correo = correo.Replace(".pdf", "");

                        // Set
                        listPdf.Add(new Pdf
                        {
                            Proyecto = proyecto,
                            Nombre = nombre,
                            Recibo = recibo,
                            Email = correo,
                            Ruta = row,
                            Carpeta = proyecto.Substring(0, 2).ToUpper()
                        });
                    }
                }

                metroButton1.Enabled = false;

                int exitosos = 0;
                int fallidos = 0;

                // Recorremos y enviamos
                foreach (var row in listPdf)
                {
                    if (Send(row, _correo) == true)
                    {
                        // Sumamos
                        exitosos++;

                        // Movemos
                        FileInfo fileInfo = new FileInfo(row.Ruta);
                        string destino = $"{txtRutaDestino.Text}\\{row.Carpeta}";
                        Fichero.Mover(fileInfo, destino);
                    }
                    else
                    {
                        fallidos++;
                    }

                    lblExitosos.Text = $"Exitosos: {exitosos:n0}";
                    lblFallidos.Text = $"Fallidos: {fallidos:n0}";
                    lblTotal.Text = $"Total: {listPdf.Count:n0}";
                    lblFaltantes.Text = $"Faltantes: {listPdf.Count - (exitosos + fallidos):n0}";
                }

                // Proceso terminado
                MessageBox.Show("Se ha terminado el proceso");
            });
        }

        public bool Send(Pdf pdf, Correo correo)
        {
            try
            {
                // Prioridad
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                // Libertad
                if (Environment.MachineName.ToUpper() == "INDEPENDENCIA")
                {
                    correo.Email = "ljchuello@protonmail.com";
                }

                // Construimos el correo
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.To.Add(pdf.Email);
                    mailMessage.From = new MailAddress(correo.Email, correo.Email, Encoding.UTF8);
                    mailMessage.Subject = $"Recibo de Caja - Grupo ANCON";
                    mailMessage.SubjectEncoding = Encoding.UTF8;
                    mailMessage.Body = $"<p>Estimado Cliente {pdf.Nombre.ToUpper()}, del Proyecto {pdf.Proyecto.ToUpper()}, reciba un cordial saludo de Grupo ANCON le informamos que se ha procedido al registro de su abono con el Recibo {pdf.Recibo.ToUpper()}, el mismo que se detalla en el Recibo de Caja adjunto.</p>" +
                                       "<p>&nbsp;</p>" +
                                       "<p>Atentamente,</p>" +
                                       "<p>&nbsp;</p>" +
                                       "<p>TESORERIA</p>" +
                                       "<p>Grupo ANCON</p>" +
                                       "<p>Agradecemos su pago</p>" +
                                       "<p>Estamos para brindarle un excelente servicio, Saludos.</p>";
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.IsBodyHtml = true;

                    // Adjuntamos
                    mailMessage.Attachments.Add(new Attachment(pdf.Ruta));

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
                MessageBox.Show($"No se ha pidodo enviar el correo electrónca a {pdf.Email}\n\nAh ocurrido un error; {ex.Message}");
                return false;
            }
        }

        string ReplaceFirst(string text, string search, string replace)
        {
            try
            {
                int pos = text.IndexOf(search);
                if (pos < 0)
                {
                    return text;
                }
                return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
