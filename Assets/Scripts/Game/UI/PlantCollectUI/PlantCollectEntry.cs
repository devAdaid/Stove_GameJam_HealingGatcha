using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantCollectEntryUIData
{
    public readonly string PlantId;
    public readonly string DisplayName;
    public readonly ItemRarity Rarity;
    public readonly Sprite IconSprite;
    public readonly int CollectCount;
    public readonly int GoldReward;

    public PlantCollectEntryUIData(
        string plantId, string displayName,
        ItemRarity rarity, Sprite iconSprite,
        int currentCount, int goldReward)
    {
        PlantId = plantId;
        DisplayName = displayName;
        Rarity = rarity;
        IconSprite = iconSprite;
        CollectCount = currentCount;
        GoldReward = goldReward;
    }
}

public class PlantCollectEntry : EntryBase
{
    [SerializeField]
    private TMP_Text plantNameText;
    [SerializeField]
    private Image plantImage;
    [SerializeField]
    private Image rarityImage;
    //[SerializeField]
    //private TMP_Text goldRewardText;

    private string plantId;

    protected override void DoInitialize()
    {
    }

    public void ApplyData(PlantCollectEntryUIData data)
    {
        plantId = data.PlantId;
        plantImage.sprite = data.IconSprite;
        if (data.CollectCount > 0)
        {
            plantImage.color = Color.white;
            plantNameText.text = $"{data.DisplayName}";
        }
        else
        {
            plantImage.color = Color.black;
            plantNameText.text = $"???";
        }
        rarityImage.sprite = GameSystem.I.StaticData.GetRarityTextSprite(data.Rarity);
        //goldRewardText.text = $"{data.GoldReward} G";
    }
}