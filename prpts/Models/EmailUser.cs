using static prpts.RptSched;

namespace prpts.Models
{
    public class EmailUser
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public EmailUser()
        {

        }

        public EmailUser(string emailAddress, string name = null)
        {
            EmailAddress = emailAddress;
            Name = name == null ? emailAddress : name;
        }
    }
}