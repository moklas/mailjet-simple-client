namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendContactListContactResponseResult
    {
        string Name { get; set; }
        string Email { get; set; }
        ContactListAction Action { get; set; }
        object Properties { get; set; }
    }
}
