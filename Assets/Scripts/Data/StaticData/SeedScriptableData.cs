using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantProbabilityData
{
    public string PlantId;
    public int Weight;
}

[CreateAssetMenu]
public class SeedScriptableData : ScriptableObject
{
    public string Id;
    public int Order;
    public string DisplayName;
    public ItemRarity Rarity;
    public int GoldCost;
    public Sprite IconSprite;
    public List<PlantProbabilityData> ProbabilityDataList;
}