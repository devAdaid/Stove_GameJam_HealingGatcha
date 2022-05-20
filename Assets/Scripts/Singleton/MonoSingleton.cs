using System.Linq;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static bool IsInitialized => _instance != null;

    public static T I
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    T prefab = Resources.LoadAll<T>("Prefabs/Singleton").SingleOrDefault();
                    if (prefab != null)
                    {
                        _instance = Instantiate(prefab) as T;
                        _instance.name = typeof(T).ToString();
                    }
                    else
                    {
                        _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }

    protected static T _instance = null;

    public void EchoForCreate() { }

    protected virtual void OnApplicationQuit()
    {
        _instance = null;
    }
}