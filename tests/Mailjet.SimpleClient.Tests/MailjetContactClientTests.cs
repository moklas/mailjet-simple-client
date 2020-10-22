using Mailjet.SimpleClient.Core.Models.Contact;
using Mailjet.SimpleClient.Core.Models.Errors;
using Mailjet.SimpleClient.Core.Models.Responses.Contact;
using Mailjet.SimpleClient.Core.Serialisers;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetContactClientTests : ConfigurationFixture
    {
        [Fact]
        public async Task Test_DeleteContactAsync()
        {
            double contactId = 12345678;
            var testUri = $"https://api.mailjet.com/v4/contacts/{contactId}";

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.DeleteAsync(contactId);

            Assert.True(res.Successful);
        }

        [Fact]
        public async Task Test_DeleteContactAsyncWithIncorrectContactIdReturnsNotFound()
        {
            double contactId = 12;
            var testUri = $"https://api.mailjet.com/v4/contacts/{contactId}";

            string errorMessage = "The resource with the specified ID you are trying to reach does not exist.";
            var entry = new SendContactResponseEntry
            {
                Count = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Total = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Data = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Errors = new List<Error> { new Error { ErrorMessage = errorMessage } },
                Status = "failed",
            };
            var contactResponse = new SendContactResponse(new List<SendContactResponseEntry> { entry }, MailjetSerialiser.Serialise(entry).ToString(), 404, false);
            var httpResponse = new HttpResponseMessage((HttpStatusCode)contactResponse.StatusCode)
            {
                Content = new StringContent(contactResponse.RawResponse.ToString())
            };

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.DeleteAsync(contactId);

            Assert.False(res.Successful);
        }

        [Fact]
        public async Task Test_AddContactAsync()
        {
            var contact = new Contact { Email = "my@email.com", Name = "User Name" };
            var testUri = $"https://api.mailjet.com/v3/rest/contact";

            var entry = new SendContactResponseEntry
            {
                Count = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Total = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Data = new List<SendContactResponseResult> { new SendContactResponseResult { CreatedAt = DateTime.Now } },
                Errors = new List<Error> { },
                Status = "success",
            };

            var contactResponse = new SendContactResponse(new List<SendContactResponseEntry> { entry }, MailjetSerialiser.Serialise(entry).ToString(), 201, true);
            var httpResponse = new HttpResponseMessage((HttpStatusCode)contactResponse.StatusCode)
            {
                Content = new StringContent(contactResponse.RawResponse.ToString())
            };

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.PostAsync(contact);

            Assert.True(res.Successful);
        }

        [Fact]
        public async Task Test_AddContactAsyncWithBadEmailReturnsBadRequest()
        {
            var contact = new Contact { Email = "my@email.com", Name = "User Name" };
            var testUri = $"https://api.mailjet.com/v3/rest/contact";

            string errorMessage = "Internal error: Invalid email address...";
            var entry = new SendContactResponseEntry
            {
                Count = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Total = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Data = new List<SendContactResponseResult> { new SendContactResponseResult { CreatedAt = DateTime.Now } },
                Errors = new List<Error> { new Error { ErrorMessage = errorMessage } },
                Status = "failed",
            };

            var contactResponse = new SendContactResponse(new List<SendContactResponseEntry> { entry }, MailjetSerialiser.Serialise(entry).ToString(), 400, false);
            var httpResponse = new HttpResponseMessage((HttpStatusCode)contactResponse.StatusCode)
            {
                Content = new StringContent(contactResponse.RawResponse.ToString())
            };

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.PostAsync(contact);

            Assert.False(res.Successful);
        }

        [Fact]
        public async Task Test_GetContactAsync()
        {
            var contact = new Contact { Email = $"my@email.com" };
            var testUri = $"https://api.mailjet.com/v3/rest/contact/{contact.Email}";

            var entry = new SendContactResponseEntry
            {
                Count = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Total = new List<SendContactResponseResult> { new SendContactResponseResult { } },
                Data = new List<SendContactResponseResult> { new SendContactResponseResult { CreatedAt = DateTime.Now } },
                Errors = new List<Error> { },
                Status = "success",
            };

            var contactResponse = new SendContactResponse(new List<SendContactResponseEntry> { entry }, MailjetSerialiser.Serialise(entry).ToString(), 200, true);
            var httpResponse = new HttpResponseMessage((HttpStatusCode)contactResponse.StatusCode)
            {
                Content = new StringContent(contactResponse.RawResponse.ToString())
            };

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.GetAsync(contact);

            Assert.True(res.Successful);
        }

        [Fact]
        public async Task Test_GetContactAsyncWithBadInputReturnsUnsuccessfully()
        {
            var contact = new Contact { Email = "invalidValue" };
            var testUri = $"https://api.mailjet.com/v3/rest/contact/{contact.Email}";

            var contactResponse = new SendContactResponse(new List<SendContactResponseEntry> { null }, string.Empty, 404, false);
            var httpResponse = new HttpResponseMessage((HttpStatusCode)contactResponse.StatusCode)
            {
                Content = new StringContent(contactResponse.RawResponse.ToString())
            };

            var messageHandler = CreateMessageHandler("SendAsync", testUri, httpResponse);
            var client = CreateContactClient(messageHandler);
            var res = await client.GetAsync(contact);

            Assert.False(res.Successful);
        }

        private static Mock<HttpMessageHandler> CreateMessageHandler(string methodName, string testUri, HttpResponseMessage httpResponse)
        {
            var messageHandler = new Mock<HttpMessageHandler>();
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(methodName,
                ItExpr.Is<HttpRequestMessage>(a => a.RequestUri.ToString() == testUri),
                ItExpr.IsAny<CancellationToken>()).Returns(Task.FromResult(httpResponse));
            return messageHandler;
        }

        private MailjetContactClient CreateContactClient(Mock<HttpMessageHandler> messageHandler)
        {
            var httpClient = new HttpClient(messageHandler.Object);
            var simpleClient = new MailjetSimpleClient();
            simpleClient.UseHttpClient(httpClient);
            return new MailjetContactClient(simpleClient, MailjetOptions);
        }
    }
}
