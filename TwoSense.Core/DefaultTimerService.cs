namespace TwoSense.Core;

public class DefaultTimerService : ITimerService
{
    public DateTime Now() => DateTime.Now;
}
