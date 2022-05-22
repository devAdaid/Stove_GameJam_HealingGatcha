using TMPro;
using UnityEngine;

public class GoldUI : UIBase
{
    [SerializeField]
    private TMP_Text goldText;

    public override void Initialize()
    {
    }

    public void ApplyData(int gold)
    {
        goldText.text = $"{gold} G";
    }
}
