
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaResultUIData
{
    public readonly string DisplayName;
    public readonly Sprite IconSprite;
    public readonly ItemRarity Rarity;
    public readonly bool IsNew;
    public readonly int GoldReward;
    public readonly int BonusGoldReward;

    public GachaResultUIData(string displayName, Sprite iconSprite, ItemRarity rarity, bool isNew,
        int goldReward, int bonusGoldReward)
    {
        DisplayName = displayName;
        IconSprite = iconSprite;
        Rarity = rarity;
        IsNew = isNew;
        GoldReward = goldReward;
        BonusGoldReward = bonusGoldReward;
    }
}

public class GachaResultUI : UIBase
{
    [SerializeField]
    private Image plantImage;
    [SerializeField]
    private TMP_Text plantNameText;
    [SerializeField]
    private Image rarityImage;
    [SerializeField]
    private Image glowImage;
    [SerializeField]
    private TMP_Text goldRewardText;
    [SerializeField]
    private TMP_Text bonusGoldRewardText;
    [SerializeField]
    private GameObject newTag;
    [SerializeField]
    private Button closeButton;

    public override void Initialize()
    {
        closeButton.onClick.AddListener(() => SetActive(false));
        SetActive(false);
    }

    public void ApplyData(GachaResultUIData data)
    {
        plantImage.sprite = data.IconSprite;
        plantNameText.text = $"{data.DisplayName}";
        rarityImage.sprite = GameSystem.I.StaticData.GetRarityTextSprite(data.Rarity);
        goldRewardText.text = data.GoldReward.ToString();
        newTag.SetActive(data.IsNew);

        var glowSprite = GameSystem.I.StaticData.GetRarityGlowSprite(data.Rarity);
        glowImage.gameObject.SetActive(glowSprite != null);
        glowImage.sprite = glowSprite;

        if (data.BonusGoldReward > 0)
        {
            bonusGoldRewardText.gameObject.SetActive(true);
            bonusGoldRewardText.text = $"+{data.BonusGoldReward} (첫 수집 보너스)";
        }
        else
        {
            bonusGoldRewardText.gameObject.SetActive(false);
        }
    }
}
