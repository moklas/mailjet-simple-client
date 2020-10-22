using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public class SendContactListRequest : RequestBase
    {
        public SendContactListRequest(IContactListContact clc, IMailjetOptions options, RequestOptions reqOptions)
        {
            if (clc == null)
            {
                throw new ArgumentNullException(nameof(clc));
            }

            Options = options ?? throw new ArgumentNullException(nameof(options));

            if (Options.ContactOptions.ContactApiVersion != ContactApiVersion.V3) throw new UnsupportedApiVersionException();

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}")));
            SetRequestBody(clc);
            HttpMethod = reqOptions.HttpMethod;
            Path = $"v3/rest/contactslist{reqOptions.AddedPath}";
        }

        public IMailjetOptions Options { get; }
    }
}
