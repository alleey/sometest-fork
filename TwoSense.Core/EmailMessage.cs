namespace TwoSense.Core;

public record EmailMessage {
    public string To {get;set;}
    public string Subject {get;set;}
    public string Message {get;set;}

    public EmailMessage(string to, string message)
    {
        To = to;
        Message = message;
    }
}
