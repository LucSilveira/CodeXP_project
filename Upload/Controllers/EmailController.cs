using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace Upload.Controllers
{
    public class EmailController : ControllerBase
    {

        public bool Email(string  email, string corpoEmail, string tituloEmail){

            try{

                MailMessage _message = new MailMessage();

                _message.From = new MailAddress("TechCycle.FCode@gmail.com");
                
                //Contrói o MailMessage
                _message.CC.Add(email);
                _message.Subject = tituloEmail;
                _message.IsBodyHtml = true;
                _message.Body = corpoEmail;


                //CONFIGURAÇÃO COM PORTA
                  SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));


                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação);
                _smtpClient.UseDefaultCredentials = false;

                _smtpClient.Credentials = new NetworkCredential("TechCycle.FCode@gmail.com", "techcycle132");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send (_message);

                return true;

            } catch (Exception ex) {
                throw ex;
            }

            // return email;
        }
        
    }
}