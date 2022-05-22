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
    public readonly string PlantId;

    public RequestUseSeed(string seedId, string plantId)
    {
        SeedId = seedId;
        PlantId = plantId;
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
    public readonly bool IsFirst;

    public PlantAdded(string plantId, bool isFirst)
    {
        PlantId = plantId;
        IsFirst = isFirst;
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

public class OpenSeedShopUI : IGameEvent
{
}

public class OpenSeedInventoryUI : IGameEvent
{
}

public class OpenGachaResultUI : IGameEvent
{
    public readonly string PlantId;

    public OpenGachaResultUI(string plantId)
    {
        PlantId = plantId;
    }
}

public class SetGoldUIActive : IGameEvent
{
    public readonly bool Active;

    public SetGoldUIActive(bool active)
    {
        Active = active;
    }
}