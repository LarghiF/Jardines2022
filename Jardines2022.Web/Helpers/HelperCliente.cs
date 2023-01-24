using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Jardines2022.Web.Helpers
{
    public static class HelperCliente
    {
        public static string GenerarClave()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 6);
        }
        public static string Encriptar(string txt)
        {
            SHA256 sh = SHA256Managed.Create();
            Encoding encoding = Encoding.UTF8;
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sh.ComputeHash(encoding.GetBytes(txt));
            foreach (var t in stream)
            {
                sb.AppendFormat("{0:x2}", t);
            }
            return sb.ToString();
        }
        public static bool EnviarCorreo(string correo,string asunto,string mensaje)
        {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("declareilikelasagna@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("declareilikelasagna@gmail.com", "jipzzrtlzbhtztno"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };
                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }
            return resultado;
        }


    }
}