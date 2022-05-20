using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedShopEntryUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly int CurrentCount;
    public readonly int GoldCost;

    public SeedShopEntryUIData(string seedId, string seedDisplayName, int currentCount, int goldCost)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        CurrentCount = currentCount;
        GoldCost = goldCost;
    }
}

public class SeedShopEntry : EntryBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private TMP_Text goldCostText;
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
        seedNameText.text = $"{data.SeedDisplayName} ({data.CurrentCount})";
        goldCostText.text = $"{data.GoldCost} G";
    }

    private void OnClicked()
    {
        GameSystem.I.Event.InvokeEvent(new RequestBuySeed(seedId));
    }
}