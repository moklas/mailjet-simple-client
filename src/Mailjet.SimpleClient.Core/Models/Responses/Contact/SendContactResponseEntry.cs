using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;
using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Models.Responses.Contact
{
    public class SendContactResponseEntry : ISendContactResponseEntry
    {
        public bool Successful => Status == "success";
        public string Status { get; set; }
        public IEnumerable<ISendContactResponseResult> Data { get; set; } = new List<SendContactResponseResult>();
        public IEnumerable<ISendContactResponseResult> Count { get; set; } = new List<SendContactResponseResult>();
        public IEnumerable<ISendContactResponseResult> Total { get; set; } = new List<SendContactResponseResult>();
        public IEnumerable<IError> Errors { get; set; } = new List<Error>();
    }
}
