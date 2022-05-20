public class TimingGameContext
{
    public bool IsPlaying { get; private set; }
    public int RemainCount { get; private set; }
    public int MaxCount { get; private set; }
    public int TotalPoint { get; private set; }
    public int TargetPoint { get; private set; }

    public TimingGameContext()
    {
        IsPlaying = false;
    }

    public void TrySucceeded(int point)
    {
        RemainCount -= 1;
        TotalPoint += point;
    }

    public void TryFailed()
    {
        RemainCount -= 1;
    }
}
