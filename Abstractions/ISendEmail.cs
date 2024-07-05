namespace Abstractions;
public interface ISendEmail
{
    public string ToTextBox { get; set; }
    public string SubjectTextBox { get; set; }
    public string BodyTextBox { get; set; }
    public bool IsButtonEnabled { get; set; }
    public string ShowMessage { get; set; }
    public CustomStopwatch Stopwatch { get; set; }
    public int KeyStrokes { get; set; }
    public System.Timers.Timer AngerTimer { get; set; }
    public event EventHandler SendButtonEvent;
    public event EventHandler KeyDownEvent;
    public event EventHandler TextChangedEvent;
}