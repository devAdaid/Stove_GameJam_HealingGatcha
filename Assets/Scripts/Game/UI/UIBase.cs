using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    [SerializeField]
    private GameObject root;

    public void SetActive(bool active)
    {
        root.SetActive(active);
    }

    public abstract void Initialize();
}