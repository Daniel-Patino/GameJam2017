using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static readonly object _creationObject = new object();
    private static T _instance = default(T);

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_creationObject)
                {
                    if (_instance == null)
                    {
                        var newGO = new GameObject(typeof(T).Name);
                        _instance = newGO.AddComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }
}
