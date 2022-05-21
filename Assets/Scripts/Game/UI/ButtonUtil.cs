using UnityEngine;

public class ButtonUtil : MonoBehaviour
{
    public void OpenPlantCollectUI()
    {
        GameSystem.I.Event.InvokeEvent(new OpenPlantCollectUI());
    }
    public void OpenSeedShopUI()
    {
        GameSystem.I.Event.InvokeEvent(new OpenSeedShopUI());
    }
    public void OpenSeedInventoryUI()
    {
        GameSystem.I.Event.InvokeEvent(new OpenSeedInventoryUI());
    }
}
