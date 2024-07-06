namespace TwoSense.Core;

public record ValidationResult {
    public ValidationResult(List<string>? messages = null)
    {
        Messages = messages ?? new List<string>();
    }

    public bool HasErrors => Messages.Count > 0;
    public List<string> Messages {get;}

    public ValidationResult CombineWith(ValidationResult other) {
        var result = new ValidationResult(Messages);
        result.Messages.AddRange(other.Messages);
        return result;
    }

    public static ValidationResult Failed(string message) => new ValidationResult(Enumerable.Repeat(message, 1).ToList());
    public static ValidationResult Success() => new ValidationResult();
}
