using UnityEngine;

public class UIHolder
{
    public StartGameUI StartGameUI;
    public SeedShopUI SeedShopUI;
    public SeedInventoryUI SeedInventoryUI;
    public GachaResultUI GachaResultUI;
    public SeedPrepareUI SeedPrepareUI;
    public PlantCollectUI PlantCollectUI;
    public GoldUI GoldUI;
    public FirstCollectEffectUI FirstCollectEffectUI;
    //public TimingGameUI TimingGameUI;

    public UIHolder()
    {
        StartGameUI = GameObject.FindAnyObjectByType<StartGameUI>();
        StartGameUI.Initialize();
        StartGameUI.SetActive(true);

        SeedShopUI = GameObject.FindAnyObjectByType<SeedShopUI>();
        SeedShopUI.Initialize();

        SeedInventoryUI = GameObject.FindAnyObjectByType<SeedInventoryUI>();
        SeedInventoryUI.Initialize();

        GachaResultUI = GameObject.FindAnyObjectByType<GachaResultUI>();
        GachaResultUI.Initialize();

        SeedPrepareUI = GameObject.FindAnyObjectByType<SeedPrepareUI>();
        SeedPrepareUI.Initialize();

        PlantCollectUI = GameObject.FindAnyObjectByType<PlantCollectUI>();
        PlantCollectUI.Initialize();

        GoldUI = GameObject.FindAnyObjectByType<GoldUI>();
        GoldUI.Initialize();

        FirstCollectEffectUI = GameObject.FindAnyObjectByType<FirstCollectEffectUI>();
        FirstCollectEffectUI.Initialize();

        //TimingGameUI = GameObject.FindAnyObjectByType<TimingGameUI>();
        //TimingGameUI.Initialize();
    }
}