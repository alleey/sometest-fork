namespace TwoSense.Core;

public class MaxTypingSpeedPerMinuteObserver : ITypingSpeedObserver
{
    private ITimerService _timerService;
    private List<DateTime> _inputs;
    private int _maxSpeed;

    public MaxTypingSpeedPerMinuteObserver(ITimerService timerService)
    {
        _timerService = timerService;
        _inputs = new List<DateTime>();
    }

    public int Speed => _maxSpeed;

    public void Observe(char keyStroke)
    {
        var now = _timerService.Now();
        _inputs.Add(now);
        _inputs = _inputs.Where(t => t > now.AddMinutes(-1)).ToList();
        _maxSpeed = Math.Max(_maxSpeed, _inputs.Count);
    }

    public void Reset()
    {
        _inputs = new List<DateTime>();
        _maxSpeed = 0;
    }
}
