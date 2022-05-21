using UnityEngine;

public class UIHolder
{
    public StartGameUI StartGameUI;
    public SeedShopUI SeedShopUI;
    public SeedInventoryUI SeedInventoryUI;
    public GachaResultUI GachaResultUI;
    public SeedPrepareUI SeedPrepareUI;
    public PlantCollectUI PlantCollectUI;
    //public TimingGameUI TimingGameUI;

    public UIHolder()
    {
        StartGameUI = GameObject.FindObjectOfType<StartGameUI>();
        StartGameUI.Initialize();
        StartGameUI.SetActive(true);

        SeedShopUI = GameObject.FindObjectOfType<SeedShopUI>();
        SeedShopUI.Initialize();

        SeedInventoryUI = GameObject.FindObjectOfType<SeedInventoryUI>();
        SeedInventoryUI.Initialize();

        GachaResultUI = GameObject.FindObjectOfType<GachaResultUI>();
        GachaResultUI.Initialize();

        SeedPrepareUI = GameObject.FindObjectOfType<SeedPrepareUI>();
        SeedPrepareUI.Initialize();

        PlantCollectUI = GameObject.FindObjectOfType<PlantCollectUI>();
        PlantCollectUI.Initialize();

        //TimingGameUI = GameObject.FindObjectOfType<TimingGameUI>();
        //TimingGameUI.Initialize();
    }
}