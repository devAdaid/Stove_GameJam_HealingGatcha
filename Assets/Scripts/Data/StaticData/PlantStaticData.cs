using UnityEngine;

public class PlantStaticData
{
    public readonly string Id;
    public readonly int Order;
    public readonly string DisplayName;
    public readonly ItemRarity Rarity;
    public readonly int GoldReward;
    public readonly Sprite IconSprite;

    public PlantStaticData(PlantScriptableData data)
    {
        Id = data.Id;
        Order = data.Order;
        DisplayName = data.DisplayName;
        Rarity = data.Rarity;
        GoldReward = data.GoldReward;
        IconSprite = data.IconSprite;
    }
}