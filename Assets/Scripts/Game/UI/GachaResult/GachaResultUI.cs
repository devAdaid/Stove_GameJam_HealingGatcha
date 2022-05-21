
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaResultUIData
{
    public readonly string DisplayName;
    public readonly Sprite IconSprite;
    public readonly ItemRarity Rarity;

    public GachaResultUIData(string displayName, Sprite iconSprite, ItemRarity rarity)
    {
        DisplayName = displayName;
        IconSprite = iconSprite;
        Rarity = rarity;
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
    private Sprite srGlowSprite;
    [SerializeField]
    private Sprite ssrGlowSprite;
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
        rarityImage.sprite = GameSystem.I.StaticData.GetRaritySprite(data.Rarity);

        glowImage.gameObject.SetActive(data.Rarity >= ItemRarity.SR);
        switch (data.Rarity)
        {
            case ItemRarity.SR:
                glowImage.sprite = srGlowSprite;
                break;
            case ItemRarity.SSR:
                glowImage.sprite = ssrGlowSprite;
                break;
        }
    }
}
