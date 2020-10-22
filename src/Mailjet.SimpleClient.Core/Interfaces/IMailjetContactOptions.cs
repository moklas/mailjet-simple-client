using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Options for Mailjet's contact API
    /// </summary>
    public interface IMailjetContactOptions
    {
        /// <summary>
        /// Contact API version
        /// </summary>
        ContactApiVersion ContactApiVersion { get; set; }
    }
}