using Mailjet.SimpleClient.Core.Models.Options;
using System.Net.Http;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Options for send Http request
    /// </summary>
    public interface IRequestOptions
    {
        /// <summary>
        /// Http method choice
        /// </summary>
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Path part for endpoint
        /// </summary>
        public string AddedPath { get; set; }
    }
}