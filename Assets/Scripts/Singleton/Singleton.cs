public class Singleton<T> where T : class, new()
{
    public static bool IsInitialized => _instance != null;

    public static T I
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    protected static T _instance = null;

    public virtual void EchoForCreate()
    {
        if (_instance == null)
        {
            _instance = new T();
        }
    }
}