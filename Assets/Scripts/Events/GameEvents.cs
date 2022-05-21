public class RequestStartGame : IGameEvent
{
}

public class TimingGameEnded : IGameEvent
{
}

public class RequestBuySeed : IGameEvent
{
    public readonly string SeedId;

    public RequestBuySeed(string seedId)
    {
        SeedId = seedId;
    }
}

public class RequestUseSeed : IGameEvent
{
    public readonly string SeedId;

    public RequestUseSeed(string seedId)
    {
        SeedId = seedId;
    }
}

public class SeedUpdated : IGameEvent
{
    public readonly string SeedId;

    public SeedUpdated(string seedId)
    {
        SeedId = seedId;
    }
}

public class GoldUpdated : IGameEvent
{
    public readonly int Gold;

    public GoldUpdated(int gold)
    {
        Gold = gold;
    }
}

public class PlantAdded : IGameEvent
{
    public readonly string PlantId;

    public PlantAdded(string plantId)
    {
        PlantId = plantId;
    }
}

public class OpenSeedPrepareUI : IGameEvent
{
    public readonly string SeedId;

    public OpenSeedPrepareUI(string seedId)
    {
        SeedId = seedId;
    }
}

public class OpenPlantCollectUI : IGameEvent
{
}