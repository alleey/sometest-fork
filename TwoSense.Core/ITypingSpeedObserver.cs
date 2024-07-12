namespace TwoSense.Core;

public interface ITypingSpeedObserver : IUserInputObserver {
    int Speed { get; }
}
