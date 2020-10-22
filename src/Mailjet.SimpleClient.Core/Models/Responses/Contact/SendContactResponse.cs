using Mailjet.SimpleClient.Core.Interfaces;
using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Models.Responses.Contact
{
    public class SendContactResponse : ResponseBase, ISendContactResponse
    {
        public SendContactResponse(IEnumerable<ISendContactResponseEntry> data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }
        public SendContactResponse(IEnumerable<ISendContactResponseEntry> data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        public IEnumerable<ISendContactResponseEntry> Data { get; }
    }
}
