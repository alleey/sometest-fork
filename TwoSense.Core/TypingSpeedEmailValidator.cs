namespace TwoSense.Core;

public class TypingSpeedEmailValidator : IEmailValidator
{
    const string ErrorText = "Typing speed exceeds 400 keys per minute. Potential anger detected.";
    private readonly ITypingSpeedObserver _speedObserver;
    private readonly int _threshold;

    public TypingSpeedEmailValidator(ITypingSpeedObserver speedObserver, int threshold = 400)
    {
        _speedObserver = speedObserver;
        _threshold = threshold;
    }

    public ValidationResult Validate(EmailMessage message)
    {
        if (_speedObserver.Speed >= _threshold) {
            return ValidationResult.Failed(ErrorText);
        }
        return ValidationResult.Success();
    }
}
