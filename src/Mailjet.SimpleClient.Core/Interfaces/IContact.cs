namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A contact
    /// </summary>
    public interface IContact
    {
        /// <summary>
        /// Should contact be excluded from campaigns
        /// </summary>
        bool IsExcludedFromCampaigns { get; set; }

        /// <summary>
        /// Contact name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Contact email
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Contact Id
        /// </summary>
        double? Id { get; set; }
    }
}
