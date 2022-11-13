using MimeKit;

namespace RFT.Services.DtoModels;

public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IList<(string name, string address)> to, string subject, string content)
    {
        To = new List<MailboxAddress>();

        To.AddRange(to.Select(x => new MailboxAddress(x.name, x.address)));
        Subject = subject;
        Content = content;
    }
}