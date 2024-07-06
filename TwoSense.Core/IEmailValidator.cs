namespace TwoSense.Core;

public interface IEmailValidator
{
    ValidationResult Validate(EmailMessage message);
}
