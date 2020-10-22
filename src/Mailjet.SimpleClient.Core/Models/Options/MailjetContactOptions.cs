using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Options
{
    public class MailjetContactOptions : IMailjetContactOptions
    {
        public ContactApiVersion ContactApiVersion { get; set; } = ContactApiVersion.V3;
    }
}
