using System.Net.Mail;
using System.Text.RegularExpressions;

namespace NominaEmailsV2
{
    public class Pdf
    {
        public string Email { set; get; } = string.Empty;
        public string Filename { set; get; } = string.Empty;

        public static bool Validar(string email)
        {
            try
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.([\w\-]+){2,})+)$");
                Match match = regex.Match(email.Trim());
                if (match.Success)
                {
                    new MailAddress(email);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}