using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Contact;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses.Contact;
using Mailjet.SimpleClient.Core.Models.Responses.ContactListContact;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient
{
    public class MailjetContactClient : IMailjetContactClient
    {
        private readonly IMailjetSimpleClient client;
        private static readonly ILog Log = LogProvider.For<MailjetContactClient>();

        public MailjetContactClient(IMailjetSimpleClient client, IMailjetOptions options)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public IMailjetOptions Options { get; private set; }

        // Contact
        public async Task<ISendContactResponse> GetAsync(IContact contact)
        {
            return await SendAsync(contact, new RequestOptions { HttpMethod = HttpMethod.Get, AddedPath = $"/{contact.Email}" });
        }

        public async Task<ISendContactResponse> PostAsync(IContact contact)
        {
            return await SendAsync(contact, new RequestOptions { HttpMethod = HttpMethod.Post });
        }

        public async Task<ISendContactResponse> DeleteAsync(double id)
        {
            return await DeleteAsync(new Contact { Id = id }, new RequestOptions { HttpMethod = HttpMethod.Delete, AddedPath = $"/{id}" });
        }

        private async Task<ISendContactResponse> SendAsync(IContact contact, RequestOptions reqOptions)
        {
            try
            {
                Log.Info($"Handling a contact via {reqOptions.HttpMethod}");
                Log.Debug("Contact options: " + LogSerialiser.Serialise(Options.ContactOptions));

                var req = new SendContactRequest(contact, Options, reqOptions);
                var res = await client.SendRequestAsync(req);

                if (res == null)
                    throw new Exception($"res is null + {contact?.Email} {contact?.Id}");

                if (!res.Successful)
                    return new SendContactResponse(null, res);

                var token = JToken.Parse(res?.RawResponse);

                return new SendContactResponse(
                    token["Data"]?.ToObject<List<SendContactResponseEntry>>(),
                    res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when handling a contact via {reqOptions.HttpMethod}");
                throw;
            }
        }

        private async Task<ISendContactResponse> DeleteAsync(IContact contact, RequestOptions reqOptions)
        {
            try
            {
                Log.Info($"Handling a contact via {reqOptions.HttpMethod}");
                Log.Debug("Contact options: " + LogSerialiser.Serialise(Options.ContactOptions));

                var req = new SendContactRequest(contact, Options, reqOptions);
                var res = await client.SendRequestAsync(req);

                if (!res.Successful)
                    return new SendContactResponse(null, res);

                return new SendContactResponse(null, res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error when handling a contact via {reqOptions.HttpMethod}");
                throw;
            }
        }

        public async Task<ISendContactListContactResponse> PostAsync(IContactListContact clc, int listId)
        {
            return await SendAsync(clc, new RequestOptions { HttpMethod = HttpMethod.Post, AddedPath = $"/{listId}/managecontact" });
        }

        private async Task<ISendContactListContactResponse> SendAsync(IContactListContact clc, RequestOptions reqOptions)
        {
            try
            {
                Log.Info($"Handling a contact list contact");
                Log.Debug("ContactListContact options: " + LogSerialiser.Serialise(Options.ContactOptions));
                var req = new SendContactListRequest(clc, Options, reqOptions);
                var res = await client.SendRequestAsync(req);

                var token = JToken.Parse(res.RawResponse);

                return new SendContactListContactResponse(token["ContactListContact"]?.ToObject<ISendContactListContactResponseEntry>(), res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error adding contactlistcontact");
                throw;
            }
        }
    }
}