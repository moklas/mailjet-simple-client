using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;
using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Models.Responses.ContactListContact
{
    public class SendContactListContactResponseEntry : ISendContactListContactResponseEntry
    {
        public bool Successful => Status == "success";
        public string Status { get; set; }
        public IEnumerable<ISendContactListContactResponseResult> Data { get; set; } = new List<SendContactListContactResponseResult>();
        public IEnumerable<ISendContactListContactResponseResult> Count { get; set; } = new List<SendContactListContactResponseResult>();
        public IEnumerable<ISendContactListContactResponseResult> Total { get; set; } = new List<SendContactListContactResponseResult>();
        public IEnumerable<IError> Errors { get; set; } = new List<Error>();
    }
}
