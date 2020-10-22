using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendContactResponseEntry
    {
        IEnumerable<ISendContactResponseResult> Data { get; set; }
        IEnumerable<ISendContactResponseResult> Count { get; set; }
        IEnumerable<ISendContactResponseResult> Total { get; set; }
    }
}
