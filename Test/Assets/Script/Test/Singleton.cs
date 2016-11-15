using UnityEngine;  

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        if(Singleton<T>.Instance == null)
        {
            Singleton<T>.Instance = this as T;
        }else{

        }
    }
}
