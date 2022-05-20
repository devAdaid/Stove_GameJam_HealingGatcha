using UnityEngine;
using UnityEngine.UI;

public class StartGameUI : UIBase
{
    [SerializeField]
    private Button startButton;

    public override void Initialize()
    {
        startButton.onClick.AddListener(() => GameSystem.I.Event.InvokeEvent(new RequestStartGame()));
    }
}
