﻿using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class SendEmailResponseResult : ISendEmailResponseResult
    {
        public string Email { get; set; }
        [JsonProperty(PropertyName = "MessageUUID")]
        public string MessageUuid { get; set; }
        [JsonProperty(PropertyName = "MessageID")]
        public long MessageId { get; set; }
        public string MessageHref { get; set; }
    }
}
