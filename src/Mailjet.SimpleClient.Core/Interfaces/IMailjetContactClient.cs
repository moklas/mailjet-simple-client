using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A client for interacting with Mailjet for the purpose of handling contacts
    /// </summary>
    public interface IMailjetContactClient
    {
        /// <summary>
        /// Contact
        /// </summary>
        Task<ISendContactResponse> GetAsync(IContact contact);
        Task<ISendContactResponse> PostAsync(IContact contact);
        Task<ISendContactResponse> DeleteAsync(double id);

        /// <summary>
        /// ContactListContact
        /// </summary>
        Task<ISendContactListContactResponse> PostAsync(IContactListContact recipient, int contactList);
    }
}