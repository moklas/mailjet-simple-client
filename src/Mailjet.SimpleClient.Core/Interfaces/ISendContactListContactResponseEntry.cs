using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendContactListContactResponseEntry
    {
        IEnumerable<ISendContactListContactResponseResult> Data { get; set; }
        IEnumerable<ISendContactListContactResponseResult> Count { get; set; }
        IEnumerable<ISendContactListContactResponseResult> Total { get; set; }
    }
}
