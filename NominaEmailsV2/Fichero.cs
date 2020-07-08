using System;
using System.IO;

namespace NominaEmailsV2
{
    public class Fichero
    {
        public static void Guardar(Tipo tipo, string s)
        {
            try
            {
                File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{tipo}.json", s);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public static string Leer(Tipo tipo)
        {
            try
            {
                return File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{tipo}.json");
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public enum Tipo
        {
            Sermatick_Ruta,
            Sermatick_Correo,
        }
    }
}
