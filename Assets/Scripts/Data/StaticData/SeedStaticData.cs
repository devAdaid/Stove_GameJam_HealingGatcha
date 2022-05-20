using UnityEngine;

public class SeedStaticData
{
    public readonly string Id;
    public readonly int Order;
    public readonly string DisplayName;
    public readonly ItemRarity Rarity;
    public readonly int GoldCost;
    public readonly Sprite IconSprite;
    public PlantProbabilityTable PlantProbabilityTable;

    public SeedStaticData(SeedScriptableData data)
    {
        Id = data.Id;
        Order = data.Order;
        DisplayName = data.DisplayName;
        Rarity = data.Rarity;
        GoldCost = data.GoldCost;
        IconSprite = data.IconSprite;
        PlantProbabilityTable = new PlantProbabilityTable(data.ProbabilityDataList);
    }
}