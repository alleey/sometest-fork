namespace TwoSense.Core;

public interface IUserInputObserver {
    void Observe(char keyStroke);
    void Reset();
}
