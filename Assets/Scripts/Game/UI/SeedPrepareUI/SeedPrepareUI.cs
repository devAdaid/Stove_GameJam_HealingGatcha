using System.Collections;
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
    [SerializeField]
    private Animator animator;

    private string seedId;
    private int seedCount;

    public override void Initialize()
    {
        gachaButton.onClick.AddListener(OnGachaButtonClicked);
        closeButton.onClick.AddListener(() => SetActive(false));
        SetActive(false);
    }

    public void ApplyData(SeedPrepareUIData data)
    {
        seedId = data.SeedId;
        seedCount = data.SeedCount;
        if (data.SeedCount > 0)
        {
            seedNameText.text = $"{data.SeedDisplayName} ({data.SeedCount}개 남음)";
        }
        else
        {
            seedNameText.text = $"{data.SeedDisplayName} <color=red>({data.SeedCount}개 남음)</color>";
        }
        seedImage.sprite = data.SeedIconSprite;
    }

    private void OnGachaButtonClicked()
    {
        if (seedCount > 0)
        {
            StartCoroutine(Gacha());
        }
    }

    private IEnumerator Gacha()
    {
        var plantId = string.Empty;
        if (!GameSystem.I.StaticData.TryGetSeed(seedId, out var staticData))
        {
            yield break;
        }

        plantId = staticData.PlantProbabilityTable.PickPlant();
        if (!GameSystem.I.StaticData.TryGetPlant(plantId, out var plantData))
        {
            yield break;
        }

        gachaButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        seedNameText.transform.parent.gameObject.SetActive(false);

        ItemRarity rarity = plantData.Rarity;
        switch (rarity)
        {
            case ItemRarity.N:
                animator.Play("Effect_Normal");
                break;
            case ItemRarity.R:
                animator.Play("Effect_Silver");
                break;
            case ItemRarity.SR:
                animator.Play("Effect_Gold");
                break;
            case ItemRarity.SSR:
                animator.Play("Effect_Rainbow");
                break;
        }

        yield return new WaitForSeconds(1.2f);

        gachaButton.gameObject.SetActive(true);
        closeButton.gameObject.SetActive(true);
        seedNameText.transform.parent.gameObject.SetActive(true);
        GameSystem.I.Event.InvokeEvent(new RequestUseSeed(seedId, plantId));
    }
}
