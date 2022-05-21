using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedInventoryEntryUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly Sprite SeedSprite;
    public readonly int CurrentCount;
    public readonly ItemRarity Rarity;

    public SeedInventoryEntryUIData(string seedId, string seedDisplayName, Sprite seedSprite, int currentCount, ItemRarity rarity)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        SeedSprite = seedSprite;
        CurrentCount = currentCount;
        Rarity = rarity;
    }
}

public class SeedInventoryEntry : EntryBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private Image seedImage;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Image rarityImage;

    private string seedId;

    protected override void DoInitialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void ApplyData(SeedInventoryEntryUIData data)
    {
        seedId = data.SeedId;
        seedImage.sprite = data.SeedSprite;
        seedNameText.text = $"{data.SeedDisplayName} ({data.CurrentCount}개)";
        rarityImage.sprite = GameSystem.I.StaticData.GetRaritySprite(data.Rarity);
    }

    private void OnClicked()
    {
        GameSystem.I.Event.InvokeEvent(new OpenSeedPrepareUI(seedId));
    }
}