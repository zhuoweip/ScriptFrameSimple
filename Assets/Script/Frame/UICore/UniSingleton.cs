using UnityEngine;

public class UniSingleton<T> : MonoBehaviour where T : UniSingleton<T>
{
    private static bool _applicationIsQuitting = false;
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (_applicationIsQuitting)
            {
                return null;
            }
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    instance = new GameObject("_" + typeof(T).Name).AddComponent<T>();
                }
                if (instance == null)
                    Debug.LogError("Failed to create instance of " + typeof(T).FullName + ".");
            }
            return instance;
        }
    }

    void OnApplicationQuit() {
        _applicationIsQuitting = true;
        if (instance != null) instance = null; }

    public static T CreateInstance()
    {
        if (Instance != null) Instance.OnCreate();
        return Instance;
    }

    protected virtual void OnCreate()
    {

    }
}
