using System.Collections.Generic;
using UnityEngine;

public class PlantProbabilityTable
{
    public readonly List<string> Plants;
    private readonly List<(int, ItemRarity)> rarityList;
    private readonly Dictionary<ItemRarity, List<string>> plantsByRarities;
    private readonly string defaultPlantId;
    private readonly int maxValue;

    public PlantProbabilityTable(List<SeedRarityProbabilityData> probabilityDataList, List<PlantScriptableData> plantDataList)
    {
        rarityList = new List<(int, ItemRarity)>();
        var accumulateWeight = 0;
        for (int i = 0; i < probabilityDataList.Count; i++)
        {
            var probabilityData = probabilityDataList[i];
            accumulateWeight += probabilityData.Weight;
            rarityList.Add((accumulateWeight, probabilityData.Rarity));
        }
        maxValue = accumulateWeight;

        plantsByRarities = new Dictionary<ItemRarity, List<string>>();
        Plants = new List<string>();
        foreach (var plantData in plantDataList)
        {
            var rarity = plantData.Rarity;
            Plants.Add(plantData.Id);
            if (plantsByRarities.TryGetValue(rarity, out var list))
            {
                list.Add(plantData.Id);
            }
            else
            {
                plantsByRarities.Add(rarity, new List<string>() { plantData.Id });
            }
        }
        defaultPlantId = plantDataList[0].Id;
    }

    public string PickPlant()
    {
        var rarity = PickRarity();
        if (plantsByRarities.TryGetValue(rarity, out var list))
        {
            if (list.Count > 0)
            {
                var rand = Random.Range(0, list.Count);
                return list[rand];
            }
        }

        Debug.LogWarning($"희귀도 [{rarity}]에 해당하는 씨앗 후보가 없어 임의로 식물 {defaultPlantId}가 선택됨");
        return defaultPlantId;
    }

    private ItemRarity PickRarity()
    {
        var rand = Random.Range(0, maxValue);
        for (int i = 0; i < rarityList.Count; i++)
        {
            var data = rarityList[i];
            var value = data.Item1;
            if (rand < value)
            {
                return data.Item2;
            }
        }

        return ItemRarity.N;
    }
}