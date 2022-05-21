using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaritySpriteData
{
    public ItemRarity Rarity;
    public Sprite TextSprite;
    public Sprite GlowSprite;
    public Sprite EffectBGSprite;
}

[CreateAssetMenu]
public class RaritySpriteScriptableData : ScriptableObject
{
    public List<RaritySpriteData> DataList;
}
