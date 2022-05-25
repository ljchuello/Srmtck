using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NominaEmailsV2
{
    public class Fichero
    {
        public static void Guardar(Correo correo)
        {
            try
            {
                File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\reribos.json", JsonConvert.SerializeObject(correo, Formatting.Indented));
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static Correo Leer()
        {
            try
            {
                string json = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\reribos.json");
                Correo correo = JsonConvert.DeserializeObject<Correo>(json) ?? new Correo();
                return correo;
            }
            catch (Exception)
            {
                return new Correo();
            }
        }

        public static void Mover(FileInfo fileInfo, string destino)
        {
            try
            {
                if (!Directory.Exists(destino))
                {
                    Directory.CreateDirectory(destino);
                }
                string origen = fileInfo.FullName;
                destino = $"{destino}\\{fileInfo.Name}";

                // Sobreescribimso
                if (File.Exists(destino))
                {
                    File.Delete(destino);
                }

                File.Move(origen, destino);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mover el archivo; {ex.Message}");
                Console.WriteLine(ex);
            }
        }
    }
}
