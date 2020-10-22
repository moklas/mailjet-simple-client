using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public class SendContactRequest : RequestBase
    {
        public SendContactRequest(IContact contact, IMailjetOptions options, RequestOptions reqOptions)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            Options = options ?? throw new ArgumentNullException(nameof(options));

            if (Options.ContactOptions.ContactApiVersion != ContactApiVersion.V3) throw new UnsupportedApiVersionException();

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}")));
            SetRequestBody(contact);
            HttpMethod = reqOptions.HttpMethod;

            if (reqOptions.HttpMethod == System.Net.Http.HttpMethod.Delete)
                Path = $"v4/contacts/{contact.Id}"; // there is no contact delete in V3
            else
                Path = $"v3/rest/contact{reqOptions.AddedPath}";
        }

        public IMailjetOptions Options { get; }
    }
}
