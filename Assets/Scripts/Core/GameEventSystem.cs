using System.Collections.Generic;

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
            SetShopUI();
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
                    var plantId = seedData.PlantProbabilityTable.PickOne();
                    if (staticData.TryGetPlant(plantId, out var plantData))
                    {
                        main.DecreaseSeed(useSeed.SeedId, 1);
                        main.AddGold(plantData.GoldReward);
                        collection.AddPlantCount(plantId);
                    }
                }
            }
        }
        else if (evt is SeedUpdated seedUpdated)
        {
            SetShopUI();
            SetInventoryUI();
        }
        else if (evt is GoldUpdated goldUpdated)
        {
            // TODO: GOLD
        }
    }

    private void SetShopUI()
    {
        var entryDatas = new List<SeedShopEntryUIData>();
        var seedDatas = GameSystem.I.StaticData.Seeds;
        foreach (var seedData in seedDatas)
        {
            var seedCount = main.GetSeedCount(seedData.Id);
            entryDatas.Add(new SeedShopEntryUIData(seedData.Id, seedData.DisplayName, seedCount, seedData.GoldCost));
        }

        var uiData = new SeedShopUIData(entryDatas);
        GameSystem.I.UI.SeedShopUI.ApplyData(uiData);
    }

    private void SetInventoryUI()
    {
        var entryDatas = new List<SeedInventoryEntryUIData>();
        var seedDatas = GameSystem.I.StaticData.Seeds;
        foreach (var seedData in seedDatas)
        {
            var seedCount = main.GetSeedCount(seedData.Id);
            if (seedCount > 0)
            {
                entryDatas.Add(new SeedInventoryEntryUIData(seedData.Id, seedData.DisplayName, seedCount));
            }
        }

        var uiData = new SeedInventoryUIData(entryDatas);
        GameSystem.I.UI.SeedInventoryUI.ApplyData(uiData);
    }
}