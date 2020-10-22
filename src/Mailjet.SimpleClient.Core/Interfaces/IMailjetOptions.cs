namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMailjetOptions : IMailjetKeys, IMailjetToken
    {
        IMailjetEmailOptions EmailOptions { get; }
        IMailjetSmsOptions SmsOptions { get; }
        IMailjetContactOptions ContactOptions { get; }
    }
}
