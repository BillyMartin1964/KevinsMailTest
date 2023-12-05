using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prpts.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public EmailBody Body { get; set; }
        public EmailUser Recipient { get; set; }
        public EmailUser Sender { get; set; }
        public List<EmailUser>? CC { get; set; }
        public List<EmailAttachment>? Attachments { get; set; }

        public Email()
        {

        }

        public Email(EmailUser recipient, EmailUser sender, string subject, EmailBody body, List<EmailUser>? cc = null, List<EmailAttachment>? attachments = null)
        {
            Recipient = recipient;
            Sender = sender;
            Subject = subject;
            Body = body;
            CC = cc;
            Attachments = attachments;

        }
    }
}
