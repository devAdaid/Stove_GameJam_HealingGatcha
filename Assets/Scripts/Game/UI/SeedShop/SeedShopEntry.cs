using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedShopEntryUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly int CurrentCount;
    public readonly int GoldCost;
    public readonly ItemRarity Rarity;

    public SeedShopEntryUIData(string seedId, string seedDisplayName, int currentCount, int goldCost, ItemRarity rarity)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        CurrentCount = currentCount;
        GoldCost = goldCost;
        Rarity = rarity;
    }
}

public class SeedShopEntry : EntryBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private TMP_Text goldCostText;
    [SerializeField]
    private Image rarityImage;
    [SerializeField]
    private Button button;

    private string seedId;

    protected override void DoInitialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void ApplyData(SeedShopEntryUIData data)
    {
        seedId = data.SeedId;
        seedNameText.text = $"{data.SeedDisplayName} ({data.CurrentCount}개)";
        goldCostText.text = $"{data.GoldCost} G";
        rarityImage.sprite = GameSystem.I.StaticData.GetRaritySprite(data.Rarity);
    }

    private void OnClicked()
    {
        GameSystem.I.Event.InvokeEvent(new RequestBuySeed(seedId));
    }
}