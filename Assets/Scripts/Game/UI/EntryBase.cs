using UnityEngine;


public abstract class EntryBase : MonoBehaviour
{
    protected bool isInitialized;

    public void Initialize()
    {
        if (!isInitialized)
        {
            DoInitialize();
            isInitialized = true;
        }
    }

    protected abstract void DoInitialize();
}