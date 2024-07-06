using System.Diagnostics;

namespace TwoSense.Core;
public class CustomStopwatch : Stopwatch
{
    public TimeSpan StartOffset { get; set; }

    public CustomStopwatch()
    {
        StartOffset = TimeSpan.Zero;
    }

    public CustomStopwatch(TimeSpan startOffset)
    {
        StartOffset = startOffset;
    }

    public TimeSpan ElapsedSeconds
    {
        get
        {
            return base.Elapsed + new TimeSpan(0, 0, Convert.ToInt32(StartOffset.TotalSeconds));
        }
    }
}
