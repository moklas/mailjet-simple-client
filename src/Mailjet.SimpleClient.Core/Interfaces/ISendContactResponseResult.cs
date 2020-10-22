using System;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendContactResponseResult
    {
        bool IsExcludedFromCampaigns { get; set; }
        string Name { get; set; }
        DateTime CreatedAt { get; set; }
        int DeliveredCount { get; set; }
        string Email { get; set; }
        DateTime? ExclusionFromCampaignsUpdatedAt { get; set; }
        double ID { get; set; }
        bool IsOptInPending { get; set; }
        bool IsSpamComplaining { get; set; }
        DateTime? LastActivityAt { get; set; }
        DateTime? LastUpdateAt { get; set; }
    }
}