using UnityEngine;

public class ButtonUtil : MonoBehaviour
{
    public void OpenPlantCollectUI()
    {
        GameSystem.I.Event.InvokeEvent(new OpenPlantCollectUI());
    }
}
