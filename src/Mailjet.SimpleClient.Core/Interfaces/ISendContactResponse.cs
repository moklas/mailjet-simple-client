using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendContactResponse : IResponse<IEnumerable<ISendContactResponseEntry>>
    {
    }
}
