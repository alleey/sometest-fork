using System.Runtime.CompilerServices;
using System.ComponentModel;

using TwoSense.Core;

namespace TwoSense.UI;

public class EmailViewModel : IEmailViewModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly IEnumerable<IUserInputObserver> _observers;
    private readonly IEnumerable<IEmailValidator> _validators;

    public EmailViewModel(
        IEnumerable<IUserInputObserver> observers,
        IEnumerable<IEmailValidator> validators)
    {
        _validators = validators;
        _observers = observers;
        ValidateFields();
    }

    private string _to = string.Empty;
    private string _subject = string.Empty;
    private string _message = string.Empty;
    private ValidationResult _validationResult = ValidationResult.Success();
    private bool _isSendButtonEnabled;

    public string To
    {
        get => _to;
        set
        {
            if (_to != value)
            {
                _to = value;
                OnPropertyChanged();
                ValidateFields();
            }
        }
    }

    public string Subject
    {
        get => _subject;
        set
        {
            if (_subject != value)
            {
                _subject = value;
                OnPropertyChanged();
                ValidateFields();
            }
        }
    }

    public string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                _message = value;
                OnPropertyChanged();
                ValidateFields();
            }
        }
    }

    public ValidationResult ValidationResult
    {
        get => _validationResult;
        set
        {
            if (_validationResult != value)
            {
                _validationResult = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsSendButtonEnabled
    {
        get => _isSendButtonEnabled;
        private set
        {
            if (_isSendButtonEnabled != value)
            {
                _isSendButtonEnabled = value;
                OnPropertyChanged();
            }
        }
    }

    private void ValidateFields()
    {
        IsSendButtonEnabled = !string.IsNullOrWhiteSpace(To) &&
                              !string.IsNullOrWhiteSpace(Subject) &&
                              !string.IsNullOrWhiteSpace(Message);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void OnKeyPressed()
    {
        foreach(var observer in _observers) {
            // Ugly/Fake as there is no way to get the key here, but it works for our purpose
            observer.Observe(' ');
        }
    }

    public void OnSendEmailClicked()
    {
        var message = new EmailMessage(To, Message) {
            Subject = Subject
        };
        ValidationResult = _validators.Select(v => v.Validate(message)).Aggregate((a, b) => a.CombineWith(b));
    }


    public void Reset()
    {
        foreach(var observer in _observers) {
            observer.Reset();
        }
        To = Subject = Message = string.Empty;
        _validationResult = ValidationResult.Success();
    }
}
