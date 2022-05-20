using UnityEngine;

public class UIHolder
{
    public StartGameUI StartGameUI;
    public SeedShopUI SeedShopUI;
    public SeedInventoryUI SeedInventoryUI;

    public UIHolder()
    {
        StartGameUI = GameObject.FindObjectOfType<StartGameUI>();
        StartGameUI.Initialize();
        StartGameUI.SetActive(true);

        SeedShopUI = GameObject.FindObjectOfType<SeedShopUI>();
        SeedShopUI.Initialize();

        SeedInventoryUI = GameObject.FindObjectOfType<SeedInventoryUI>();
        SeedInventoryUI.Initialize();
    }
}