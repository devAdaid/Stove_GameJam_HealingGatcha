using UnityEngine;

[CreateAssetMenu]
public class PlantScriptableData : ScriptableObject
{
    public string Id;
    public int Order;

    public string DisplayName;
    public ItemRarity Rarity;
    public int GoldReward;
    public Sprite IconSprite;
    [TextArea]
    public string FirstCollectLine;
}
