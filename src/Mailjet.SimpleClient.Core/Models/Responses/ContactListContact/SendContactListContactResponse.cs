using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.ContactListContact
{
    public class SendContactListContactResponse : ResponseBase, ISendContactListContactResponse
    {
        public SendContactListContactResponse(ISendContactListContactResponseEntry data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }
        public SendContactListContactResponse(ISendContactListContactResponseEntry data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        public ISendContactListContactResponseEntry Data { get; }
    }
}
