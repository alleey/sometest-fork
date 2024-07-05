using System.Timers;

namespace Abstractions;
public class SendEmailPresenter
{
    private readonly ISendEmail _sendEmailForm;

    public SendEmailPresenter(ISendEmail sendEmailForm)
    {
        _sendEmailForm = sendEmailForm;
        _sendEmailForm.SendButtonEvent += _SendButtonPressed;
        _sendEmailForm.KeyDownEvent += _KeyDownEvent;
        _sendEmailForm.TextChangedEvent += _TextChangedEvent;
    }

    private void _SendButtonPressed(object sender, EventArgs e)
    {
        if (_sendEmailForm.Stopwatch.IsRunning)
            _sendEmailForm.Stopwatch.Stop();

        TimeSpan ts = _sendEmailForm.Stopwatch.ElapsedSeconds;

        var keyStrokesPerSecond = _sendEmailForm.KeyStrokes / ts.Seconds;
        _sendEmailForm.KeyStrokes = 0;

        if ((keyStrokesPerSecond * 60) > 400)
            SetCoolOfftimeForAngerManagement();
        else
            _sendEmailForm.ShowMessage = "Sent!";
    }

    private void _KeyDownEvent(object sender, EventArgs e)
    {
        if (!_sendEmailForm.Stopwatch.IsRunning)
            _sendEmailForm.Stopwatch.Start();
        _sendEmailForm.KeyStrokes++;
    }

    private void _TextChangedEvent(object sender, EventArgs e)
    {
        var areAllTextsFilled = !string.IsNullOrWhiteSpace(_sendEmailForm.ToTextBox) && !string.IsNullOrWhiteSpace(_sendEmailForm.SubjectTextBox) && !string.IsNullOrWhiteSpace(_sendEmailForm.BodyTextBox);

        if (!_sendEmailForm.AngerTimer.Enabled)
            _sendEmailForm.IsButtonEnabled = areAllTextsFilled;
    }

    private void SetCoolOfftimeForAngerManagement()
    {
        _sendEmailForm.AngerTimer.Elapsed += new ElapsedEventHandler(EnableSendButton);
        _sendEmailForm.AngerTimer.AutoReset = true;
        _sendEmailForm.AngerTimer.Enabled = true;
        _sendEmailForm.IsButtonEnabled = false;
        _sendEmailForm.ShowMessage = "You cannot send the email at this time, try again later.";
    }

    private void EnableSendButton(object sender, ElapsedEventArgs e)
        =>
        _sendEmailForm.IsButtonEnabled = true;
}
