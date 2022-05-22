using System.Collections.Generic;
using System.Linq;

public class GameEventSystem
{
    private StaticDataHolder staticData;
    private UIHolder ui;
    private MainContext main;
    private TimingGameContext timingGame;
    private CollectionContext collection;

    public GameEventSystem(StaticDataHolder staticData,
        UIHolder ui,
        MainContext main, TimingGameContext timingGame, CollectionContext collection)
    {
        this.staticData = staticData;
        this.ui = ui;
        this.main = main;
        this.timingGame = timingGame;
        this.collection = collection;
    }

    public void InvokeEvent(IGameEvent evt)
    {
        if (evt is RequestStartGame startGameButtonClicked)
        {
            ui.StartGameUI.SetActive(false);
            SetGoldUI();
        }
        else if (evt is RequestBuySeed buySeed)
        {
            if (staticData.TryGetSeed(buySeed.SeedId, out var seedData))
            {
                if (main.CanDecreaseGold(seedData.GoldCost))
                {
                    main.DecreaseGold(seedData.GoldCost);
                    main.AddSeed(buySeed.SeedId, 1);
                }
            }
        }
        else if (evt is RequestUseSeed useSeed)
        {
            if (staticData.TryGetSeed(useSeed.SeedId, out var seedData))
            {
                if (main.CanDecreaseSeed(useSeed.SeedId, 1))
                {
                    if (staticData.TryGetPlant(useSeed.PlantId, out var plantData))
                    {
                        main.DecreaseSeed(useSeed.SeedId, 1);
                        main.AddGold(plantData.GoldReward);
                        collection.AddPlantCount(useSeed.PlantId);

                        if (collection.GetPlantCount(useSeed.PlantId) == 1)
                        {
                            var bonusReward = Constants.GetBonusGoldReward(plantData.Rarity);
                            main.AddGold(bonusReward);
                        }
                    }
                }
            }
        }
        else if (evt is SeedUpdated seedUpdated)
        {
            SetShopUI();
            SetInventoryUI();
            if (main.SelectedSeedId == seedUpdated.SeedId)
            {
                SetSeedPrepareUI(seedUpdated.SeedId);
            }
        }
        else if (evt is GoldUpdated goldUpdated)
        {
            SetGoldUI();
        }
        else if (evt is PlantAdded plantAdded)
        {
            if (plantAdded.IsFirst && staticData.TryGetPlant(plantAdded.PlantId, out var plantData))
            {
                if (plantData.Rarity >= ItemRarity.SR)
                {
                    GameSystem.I.Sound.PlayOneShot("SR");
                }
                else
                {
                    GameSystem.I.Sound.PlayOneShot("Shine");
                }
                var bgSprite = staticData.GetRarityEffectBgSprite(plantData.Rarity);
                ui.FirstCollectEffectUI.Play(plantData.FirstCollectLine, plantAdded.PlantId, bgSprite);
            }
            else
            {
                GameSystem.I.Sound.PlayOneShot("Tada");
                SetGachaResultUI(plantAdded.PlantId);
                ui.GachaResultUI.SetActive(true);
                ui.GoldUI.SetActive(true);
            }
        }
        else if (evt is OpenSeedPrepareUI prepareUI)
        {
            main.SetSelectedSeedId(prepareUI.SeedId);
            SetSeedPrepareUI(prepareUI.SeedId);
            ui.SeedPrepareUI.SetActive(true);
            ui.SeedInventoryUI.SetActive(false);
        }
        else if (evt is OpenPlantCollectUI collectUI)
        {
            SetPlantCollectUI();
            ui.PlantCollectUI.SetActive(true);
        }
        else if (evt is OpenSeedShopUI seedShopUI)
        {
            SetShopUI();
            ui.SeedShopUI.SetActive(true);
        }
        else if (evt is OpenSeedInventoryUI seedInventoryUI)
        {
            SetInventoryUI();
            ui.SeedInventoryUI.SetActive(true);
        }
        else if (evt is OpenGachaResultUI gachaResultUI)
        {
            SetGachaResultUI(gachaResultUI.PlantId);
            ui.GachaResultUI.SetActive(true);
            ui.GoldUI.SetActive(true);
        }
        else if (evt is SetGoldUIActive setGoldUIActive)
        {
            ui.GoldUI.SetActive(setGoldUIActive.Active);
        }
    }

    private void SetGoldUI()
    {
        var gold = main.Gold;
        ui.GoldUI.ApplyData(gold);
    }

    private void SetShopUI()
    {
        var entryDatas = new List<SeedShopEntryUIData>();
        var seedDatas = staticData.Seeds;
        foreach (var seedData in seedDatas)
        {
            var seedCount = main.GetSeedCount(seedData.Id);
            var isAllCollected = seedData.PlantProbabilityTable.Plants.All(x => collection.GetPlantCount(x) > 0);
            var isEnoughGold = main.Gold >= seedData.GoldCost;
            var isNotMaxCount = main.CanAddSeed(seedData.Id);
            entryDatas.Add(new SeedShopEntryUIData(seedData.Id, seedData.DisplayName, seedData.IconSprite,
                seedCount, seedData.GoldCost,
                isNotMaxCount, isEnoughGold,
                seedData.Rarity, isAllCollected));
        }

        var uiData = new SeedShopUIData(entryDatas);
        ui.SeedShopUI.ApplyData(uiData);
    }

    private void SetInventoryUI()
    {
        var entryDatas = new List<SeedInventoryEntryUIData>();
        var seedDatas = staticData.Seeds;
        foreach (var seedData in seedDatas)
        {
            var seedCount = main.GetSeedCount(seedData.Id);
            if (seedCount > 0)
            {
                entryDatas.Add(new SeedInventoryEntryUIData(seedData.Id, seedData.DisplayName, seedData.IconSprite, seedCount, seedData.Rarity));
            }
        }

        var uiData = new SeedInventoryUIData(entryDatas);
        ui.SeedInventoryUI.ApplyData(uiData);
    }

    private void SetGachaResultUI(string plantId)
    {
        if (staticData.TryGetPlant(plantId, out var plantData))
        {
            var isNew = collection.GetPlantCount(plantId) == 1;
            var bonusReward = isNew ? Constants.GetBonusGoldReward(plantData.Rarity) : 0;
            var uiData = new GachaResultUIData(plantData.DisplayName, plantData.IconSprite, plantData.Rarity, isNew, plantData.GoldReward, bonusReward);
            ui.GachaResultUI.ApplyData(uiData);
        }
    }

    private void SetSeedPrepareUI(string seedId)
    {
        if (!staticData.TryGetSeed(seedId, out var seedData))
        {
            return;
        }

        var seedCount = main.GetSeedCount(seedData.Id);
        var uiData = new SeedPrepareUIData(seedId, seedData.DisplayName, seedCount, seedData.IconSprite);
        ui.SeedPrepareUI.ApplyData(uiData);
    }

    private void SetPlantCollectUI()
    {
        var collectedCount = 0;
        var entryDatas = new List<PlantCollectEntryUIData>();
        foreach (var plantData in staticData.Plants)
        {
            var plantCount = collection.GetPlantCount(plantData.Id);
            if (plantCount > 0)
            {
                collectedCount += 1;
            }
            entryDatas.Add(new PlantCollectEntryUIData(
                plantData.Id, plantData.DisplayName, plantData.Rarity,
                plantData.IconSprite, plantCount, plantData.GoldReward));
        }

        var collectedPercent = (collectedCount * 100f) / staticData.Plants.Count;
        var uiData = new PlantCollectUIData((int)collectedPercent, entryDatas);
        ui.PlantCollectUI.ApplyData(uiData);
    }
}