using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Helpers
{
     public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            Type type;
            string key;
            string  from = _config.("EmailSttings:From");
            Console.WriteLine(from);
           // ["EmailSettings:From"];
           // emailMessage.From.Add(new MailboxAddress("Hobby blog app", from));
            //emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
        }
    }
}
