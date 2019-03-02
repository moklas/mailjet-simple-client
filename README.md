# Mailjet Simple Client
> A simple, yet customisable, client for interacting with Mailjet

Note that currently transactional emails, V3.1, is supported but you can easily customise/add behaviour yourself, see [Customise](#customise).

At the moment the code base is work in progress but contributions are very welcome still.

![](assets/LogoMJ_Yellow_RVB.png)

## Prerequisites

- Mailjet account, with public/private key and/or token for SMS API (V4). [How to get API keys](https://www.mailjet.com/support/what-are-the-api-key-and-secret-keys-how-should-i-use-them,109.htm)
- Targets `.NET Standard 2.0`

## Installing

Coming soon: Nuget package.

For now, you'd need to download and install it manually into your solution.

## Usage
### Basic
#### Email client
```
var emailClient = new MailjetEmailClient((opt) => {});
```
```
var emailClient = new MailjetEmailClient(new MailjetEmailOptions() {});
```

#### Low level client
```
var simpleClient = new MailjetSimpleClient();
```

### Dependency injection
See `MailjetSimpleClientAspNetSample` for more samples

#### MailjetEmailClient
Registers a service implementing `IMailjetEmailClient`
```
//Register default email client with action configuration
services.AddMailjetEmailClient((opt) => {});
```
```
//Register default email client with options instance
services.AddMailjetEmailClient(new MailjetEmailOptions());
```
**Custom implementation of IMailjetEmailClient**

Note that no other service but your implementation is added, you will need to add/configure any dependencies.
```
services.AddMailjetEmailClient<YourIMailjetEmailClient>();
```

#### MailjetSimpleClient
Register a service implementing `IMailjetSimpleClient`
```
services.AddMailjetSimpleClient();
```

#### Send emails
> More to come
```C#
var emailClient = new MailjetEmailClient(options);
await emailClient.SendAsync(new EmailMessage());
await emailClient.SendAsync(new TemplateEmailMessage());
```

#### Customise
`MailjetSimpleClient` is the low-level class responsible for interacting with Mailjet. Pass anything implementing `IRequestFactory` into `SendRequestAsync` to send any type of request.

You can also extend `MailjetSimpleClient` into a subclass, like `MailjetEmailClient` does, to provide an easy wrapper.

## Authors

* [Max Str�lin](https://github.com/maxstralin)

See also the list of [contributors](https://github.com/maxstralin/mailjet-simple-client/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details