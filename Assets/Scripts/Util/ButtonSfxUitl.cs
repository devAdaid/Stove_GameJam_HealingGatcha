using UnityEngine;
using UnityEngine.UI;

public class ButtonSfxUitl : MonoBehaviour
{
    [SerializeField]
    private string overrideClipName;

    void Start()
    {
        var button = GetComponent<Button>();
        if (button != null)
        {
            if (string.IsNullOrEmpty(overrideClipName))
            {
                button.onClick.AddListener(() => GameSystem.I.Sound.PlayOneShot("Click"));
            }
            else
            {
                button.onClick.AddListener(() => GameSystem.I.Sound.PlayOneShot(overrideClipName));
            }
        }
    }
}
