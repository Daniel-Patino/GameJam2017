using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float lazerLife = 3.0f;

    void Update()
    {
        Destroy(gameObject, lazerLife);
    }
}
