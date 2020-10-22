using Mailjet.SimpleClient.Core.Interfaces;
using System.Net.Http;

namespace Mailjet.SimpleClient.Core.Models.Options
{
    public class RequestOptions : IRequestOptions
    {
        public HttpMethod HttpMethod { get; set; }

        public string AddedPath { get; set; }
    }
}
