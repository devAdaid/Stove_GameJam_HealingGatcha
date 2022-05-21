using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedShopEntryUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly int CurrentCount;
    public readonly int GoldCost;
    public readonly bool IsNotMaxCount;
    public readonly bool IsEnoughGold;
    public readonly ItemRarity Rarity;
    public readonly bool IsAllCollected;

    public SeedShopEntryUIData(string seedId, string seedDisplayName, int currentCount,
        int goldCost, bool isNotMaxCount, bool isEnoughGold,
        ItemRarity rarity, bool isAllCollected)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        CurrentCount = currentCount;
        GoldCost = goldCost;
        IsNotMaxCount = isNotMaxCount;
        IsEnoughGold = isEnoughGold;
        Rarity = rarity;
        IsAllCollected = isAllCollected;
    }
}

public class SeedShopEntry : EntryBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private TMP_Text seedCountText;
    [SerializeField]
    private TMP_Text goldCostText;
    [SerializeField]
    private Image rarityImage;
    [SerializeField]
    private Button button;
    [SerializeField]
    private GameObject allCollectBadge;

    private string seedId;

    protected override void DoInitialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void ApplyData(SeedShopEntryUIData data)
    {
        seedId = data.SeedId;
        seedNameText.text = $"{data.SeedDisplayName}";

        if (data.IsNotMaxCount)
        {
            seedCountText.text = $"{data.CurrentCount}/{Constants.MAX_SEED_COUNT}";
        }
        else
        {
            seedCountText.text = $"<color=red>{data.CurrentCount}/{Constants.MAX_SEED_COUNT}</color>";
        }

        if (data.IsEnoughGold)
        {
            goldCostText.text = $"{data.GoldCost} G";
        }
        else
        {
            goldCostText.text = $"<color=red>{data.GoldCost} G</color>";
        }
        rarityImage.sprite = GameSystem.I.StaticData.GetRarityTextSprite(data.Rarity);
        allCollectBadge.SetActive(data.IsAllCollected);
    }

    private void OnClicked()
    {
        GameSystem.I.Event.InvokeEvent(new RequestBuySeed(seedId));
    }
}