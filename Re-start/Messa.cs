using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Re_start
{
    class Messa
    {
        public static void MySendMail(string bodyMail, string komy, string nameAuthor, string subject)
        {
            //Отправитель
            var from = new MailAddress("kirvik12122000@gmail.com", nameAuthor);
            //Получатель
            var to = new MailAddress(komy);
            //Адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //Логин и пароль от нашей почты
            smtp.Credentials = new NetworkCredential("kirvik12122000@gmail.com", "1740068kvng");
            //Шифрование соединения
            smtp.EnableSsl = true;
            //Создание экземпляра класса сообщения
            MailMessage mail = new MailMessage(from, to);
            //Тема письма
            mail.Subject = subject;
            //Текст содержит язык HTML
            mail.IsBodyHtml = true;
            //Изменение стиля сообщения
            mail.Body =
            "<center><big><h1>" + subject + "</h1></big></center>" +
            "<p>" + bodyMail + "</p></html>" +
            "<br><br><em><p>RE-START " + DateTime.Now.Year.ToString() + "<p></em>";
            //Отправка
            smtp.Send(mail);
        }
    }
}
