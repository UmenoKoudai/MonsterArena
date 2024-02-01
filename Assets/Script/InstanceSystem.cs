using UnityEngine;

public class InstanceSystem<T> : MonoBehaviour where T : MonoBehaviour
{
    private T _instance;
    public T Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<T>();
            if (_instance == null) Debug.LogError($"{typeof(T)}オブジェクトが存在しません");
            return _instance;
        }
    }
}
