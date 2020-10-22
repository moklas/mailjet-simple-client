namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A Contact for a ListContact
    /// </summary>
    public interface IContactListContact
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        public object Properties { get; set; }

        /// <summary>
        /// Action
        /// </summary>
        string Action { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        string Email { get; set; }
    }
}
