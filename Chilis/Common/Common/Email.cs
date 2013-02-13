using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.IO;
using System.Configuration;
using EnEntidad;
namespace Common
{
    public class Email
    { public string strSMTP;
        public Email()
        {
            strSMTP = "mail.globtechs.com";
        }
        public void EnviarEmail(string strSubject, string strContenido,string dest)
        {
             //  ' declaro variables de cada uno de los campos del correo
            //string SMTP;
            string Usuario;
            string Contraseña;
            Int32 Puerto;


            Usuario = "franquicia@globtechs.com";
            Contraseña = "franquicia";
            Puerto = 25;//465;
            
            //'Declaro la variable para enviar el correo
            MailMessage correo =new MailMessage();
            correo.IsBodyHtml = true;
            correo.From = new MailAddress(Usuario);
            correo.Subject = strSubject;
            
           
            correo.To.Add(dest);
            
           

            correo.Body = strContenido;

            // 'Configuracion del servidor
            SmtpClient Servidor =new SmtpClient();
            Servidor.Host = strSMTP;
            //Servidor.Port = Puerto;
            Servidor.EnableSsl = false;
            
            Servidor.Credentials = new NetworkCredential(Usuario, Contraseña);
            Servidor.Send(correo);

        }
    }
}
