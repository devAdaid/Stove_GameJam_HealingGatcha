using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataHolder
{
    public List<PlantStaticData> Plants => plantsByOrder;
    public List<SeedStaticData> Seeds => seedsByOrder;

    private readonly Dictionary<string, PlantStaticData> plantsById;
    private readonly Dictionary<string, SeedStaticData> seedsById;
    private readonly List<PlantStaticData> plantsByOrder;
    private readonly List<SeedStaticData> seedsByOrder;
    private readonly Dictionary<ItemRarity, RaritySpriteData> raritySprites;

    public StaticDataHolder()
    {
        var plantDatas = Resources.LoadAll<PlantScriptableData>("StaticData/Plants/N").ToList();
        plantDatas.AddRange(Resources.LoadAll<PlantScriptableData>("StaticData/Plants/R"));
        plantDatas.AddRange(Resources.LoadAll<PlantScriptableData>("StaticData/Plants/SR"));
        plantDatas.AddRange(Resources.LoadAll<PlantScriptableData>("StaticData/Plants/SSR"));
        plantsById = new Dictionary<string, PlantStaticData>();
        foreach (var plantData in plantDatas)
        {
            var plant = new PlantStaticData(plantData);
            plantsById.Add(plant.Id, plant);
        }
        plantsByOrder = plantsById.Values.OrderBy(x => x.Order).ToList();

        var seedDatas = Resources.LoadAll<SeedScriptableData>("StaticData/Seeds");
        seedsById = new Dictionary<string, SeedStaticData>();
        foreach (var seedData in seedDatas)
        {
            var seed = new SeedStaticData(seedData);
            seedsById.Add(seed.Id, seed);
        }
        seedsByOrder = seedsById.Values.OrderBy(x => x.Order).ToList();

        raritySprites = new Dictionary<ItemRarity, RaritySpriteData>();
        var raritySpriteData = Resources.Load<RaritySpriteScriptableData>("StaticData/Rarity");
        foreach (var rarityData in raritySpriteData.DataList)
        {
            raritySprites.Add(rarityData.Rarity, rarityData);
        }

        Debug.Log($"Data: {plantsByOrder.Count} plants, {seedsByOrder.Count} seeds");
    }

    public bool TryGetPlant(string id, out PlantStaticData data)
    {
        return plantsById.TryGetValue(id, out data);
    }

    public bool TryGetSeed(string id, out SeedStaticData data)
    {
        return seedsById.TryGetValue(id, out data);
    }

    public Sprite GetRarityTextSprite(ItemRarity rarity)
    {
        return raritySprites[rarity].TextSprite;
    }

    public Sprite GetRarityGlowSprite(ItemRarity rarity)
    {
        return raritySprites[rarity].GlowSprite;
    }

    public Sprite GetRarityEffectBgSprite(ItemRarity rarity)
    {
        return raritySprites[rarity].EffectBGSprite;
    }
}
