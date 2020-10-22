using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.ContactListContact
{
    public class SendContactListContactResponseResult : ISendContactListContactResponseResult
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ContactListAction Action { get; set; }
        public object Properties { get; set; }
    }
}
