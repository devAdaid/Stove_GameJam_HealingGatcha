using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedInventoryEntryUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly int CurrentCount;

    public SeedInventoryEntryUIData(string seedId, string seedDisplayName, int currentCount)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        CurrentCount = currentCount;
    }
}

public class SeedInventoryEntry : EntryBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private Button button;

    private string seedId;

    protected override void DoInitialize()
    {
        button.onClick.AddListener(OnClicked);
    }

    public void ApplyData(SeedInventoryEntryUIData data)
    {
        seedId = data.SeedId;
        seedNameText.text = $"{data.SeedDisplayName} ({data.CurrentCount})";
    }

    private void OnClicked()
    {
        GameSystem.I.Event.InvokeEvent(new OpenSeedPrepareUI(seedId));
    }
}