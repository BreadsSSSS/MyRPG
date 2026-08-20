using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigonTon<T>: MonoBehaviour where T : SigonTon<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = (T)this;
        }
    }
}
