using Abstractions;
using System;
using System.Diagnostics;

namespace UnitTests;
public class DummySendEmail : ISendEmail
{
    public CustomStopwatch Stopwatch { get; set; }
    public System.Timers.Timer AngerTimer { get; set; }
    public string ToTextBox { get; set; }
    public string SubjectTextBox { get; set; }
    public string BodyTextBox { get; set; }
    public int KeyStrokes { get; set; }
    public bool IsButtonEnabled { get; set; }
    public string ShowMessage { get; set; }
    public event EventHandler? SendButtonEvent;
    public event EventHandler? KeyDownEvent;
    public event EventHandler? TextChangedEvent;

    public void SendButtonAction()=> this.SendButtonEvent?.Invoke(this, EventArgs.Empty);
    public void KeyDownAction() => this.KeyDownEvent?.Invoke(this, EventArgs.Empty);
    public void TextChangedAction() => this.TextChangedEvent?.Invoke(this, EventArgs.Empty);
}
