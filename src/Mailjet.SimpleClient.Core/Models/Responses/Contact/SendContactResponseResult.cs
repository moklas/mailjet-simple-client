using Mailjet.SimpleClient.Core.Interfaces;
using System;

namespace Mailjet.SimpleClient.Core.Models.Responses.Contact
{
    public class SendContactResponseResult : ISendContactResponseResult
    {
        public bool IsExcludedFromCampaigns { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DeliveredCount { get; set; }
        public DateTime? ExclusionFromCampaignsUpdatedAt { get; set; }
        public double ID { get; set; }
        public bool IsOptInPending { get; set; }
        public bool IsSpamComplaining { get; set; }
        public DateTime? LastActivityAt { get; set; }
        public DateTime? LastUpdateAt { get; set; }
        public string Email { get; set; }
    }
}
