using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoveButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private TMP_Text delayText;
    [SerializeField]
    private int waitDelaySeconds;

    public void OnClick()
    {
        button.interactable = false;
        GameSystem.I.Main.AddGold(1000);
        StartCoroutine(WaitForDelay());
    }

    private IEnumerator WaitForDelay()
    {
        for (int i = 0; i < waitDelaySeconds; i++)
        {
            delayText.text = $"{(waitDelaySeconds - i)}초 남음";
            yield return new WaitForSeconds(1f);
        }
        delayText.text = string.Empty;
        button.interactable = true;
    }
}
