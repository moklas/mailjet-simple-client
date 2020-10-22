using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Contact
{
    public class Contact : IContact
    {
        /// <inheritdoc />
        public bool IsExcludedFromCampaigns { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double? Id { get; set; }
    }
}
