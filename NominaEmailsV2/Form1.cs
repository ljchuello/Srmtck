using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace NominaEmailsV2
{
    public partial class Form1 : MetroForm
    {
        private Correo correo = new Correo();

        public Form1()
        {
            InitializeComponent();
            Text = "Nómina Emails V2";

            CheckForIllegalCrossThreadCalls = false;

            // Leemos
            correo = JsonConvert.DeserializeObject<Correo>(Fichero.Leer(Fichero.Tipo.Sermatick_Correo)) ?? new Correo();

            // Seteamos
            txtCorreo.Text = correo.Email;
            txtContrasenia.Text = correo.Contrasenia;
            txtServidorSalida.Text = correo.Servidor;
            txtPuertoSalida.Text = correo.Puerto;
            chSsl.Checked = correo.Ssl;
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
                    correo = new Correo();
                    correo.Email = txtCorreo.Text;
                    correo.Contrasenia = txtContrasenia.Text;
                    correo.Servidor = txtServidorSalida.Text;
                    correo.Puerto = txtPuertoSalida.Text;
                    correo.Ssl = chSsl.Checked;

                    if (await correo.ProbarAsync(correo) == false)
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
    }
}
