using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedPrepareUIData
{
    public readonly string SeedId;
    public readonly string SeedDisplayName;
    public readonly int SeedCount;
    public readonly Sprite SeedIconSprite;

    public SeedPrepareUIData(string seedId, string seedDisplayName, int seedCount, Sprite seedIconSprite)
    {
        SeedId = seedId;
        SeedDisplayName = seedDisplayName;
        SeedCount = seedCount;
        SeedIconSprite = seedIconSprite;
    }
}

public class SeedPrepareUI : UIBase
{
    [SerializeField]
    private TMP_Text seedNameText;
    [SerializeField]
    private Image seedImage;
    [SerializeField]
    private Button gachaButton;
    [SerializeField]
    private Button closeButton;

    private string seedId;

    public override void Initialize()
    {
        //TODO: 가챠 연출 후  
        gachaButton.onClick.AddListener(() => GameSystem.I.Event.InvokeEvent(new RequestUseSeed(seedId)));
        closeButton.onClick.AddListener(() => SetActive(false));
        SetActive(false);
    }

    public void ApplyData(SeedPrepareUIData data)
    {
        seedId = data.SeedId;
        seedNameText.text = $"{data.SeedDisplayName} ({data.SeedCount}개 남음)";
        seedImage.sprite = data.SeedIconSprite;
    }
}
