using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                Debug.Log(_instance);
                if (_instance == null )
                {
                    Debug.Log("null");

                }
                Debug.Log("�ν��Ͻ� ����");
            }

            return _instance;
        }
    }
}
