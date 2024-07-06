using System.ComponentModel;
using System.Runtime.CompilerServices;
using TwoSense.Core;

namespace TwoSense.UI;

public interface IEmailViewModel : INotifyPropertyChanged
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

    public bool IsSendButtonEnabled { get; }
    public ValidationResult ValidationResult { get; }

    public void Reset();
    public void OnKeyPressed();
    public void OnSendEmailClicked();
}
