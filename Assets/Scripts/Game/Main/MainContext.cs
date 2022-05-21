using System.Collections.Generic;

public class MainContext
{
    public bool IsPlaying { get; private set; }
    public int Gold { get; private set; }
    public string SelectedSeedId { get; private set; }
    public Dictionary<string, int> SeedCounts { get; private set; } = new Dictionary<string, int>();

    public MainContext() { }

    public void SetSelectedSeedId(string seedId)
    {
        SelectedSeedId = seedId;
    }

    public void AddGold(int value)
    {
        Gold += value;
        GameSystem.I.Event.InvokeEvent(new GoldUpdated(Gold));
    }

    public bool CanDecreaseGold(int value)
    {
        return Gold >= value;
    }

    public bool DecreaseGold(int value)
    {
        var result = CanDecreaseGold(value);
        if (result)
        {
            Gold -= value;
            GameSystem.I.Event.InvokeEvent(new GoldUpdated(Gold));
        }

        return result;
    }

    public int GetSeedCount(string seedId)
    {
        if (SeedCounts.TryGetValue(seedId, out var currentCount))
        {
            return currentCount;
        }
        return 0;
    }

    public void AddSeed(string seedId, int value)
    {
        if (SeedCounts.TryGetValue(seedId, out var currentCount))
        {
            SeedCounts[seedId] = currentCount + value;
        }
        else
        {
            SeedCounts.Add(seedId, value);
        }
        GameSystem.I.Event.InvokeEvent(new SeedUpdated(seedId));
    }

    public bool CanDecreaseSeed(string seedId, int value)
    {
        if (value == 0) return false;

        if (SeedCounts.TryGetValue(seedId, out var currentCount))
        {
            return currentCount >= value;
        }

        return false;
    }

    public bool DecreaseSeed(string seedId, int value)
    {
        var result = CanDecreaseSeed(seedId, value);
        if (result)
        {
            SeedCounts[seedId] -= value;
            GameSystem.I.Event.InvokeEvent(new SeedUpdated(seedId));
        }

        return result;
    }
}