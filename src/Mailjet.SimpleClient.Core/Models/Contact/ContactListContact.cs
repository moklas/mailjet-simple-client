using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Contact
{
    public class ContactListContact : IContactListContact
    {
        /// <inheritdoc />
        public string Name { get; set; }
        public object Properties { get; set; }
        public string Action { get; set; }
        public string Email { get; set; }
    }
}
