using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prpts.Models
{
    public class EmailBody
    {
        public string? ContentType { get; set; }
        public string? Content { get; set; }

        public EmailBody()
        {
                
        }

        public EmailBody(string? content = null, string? contentType = "text" )
        {
            Content = content;
            ContentType = contentType;
        }
    }
}
