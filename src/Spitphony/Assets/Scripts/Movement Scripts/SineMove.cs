using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMove : MonoBehaviour {

    public float sineIntensity = 20.0f;
    public float magnitude = 0.5f;
    public float moveSpeed = 5.0f;

    private Vector3 axis;
    private Vector3 pos;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        //DestroyObject(gameObject, 1.0f);
        axis = transform.up;  // May or may not be the axis you want
    }

    // Update is called once per frame
    void Update()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * sineIntensity) * magnitude;
    }
}
