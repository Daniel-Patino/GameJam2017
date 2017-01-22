using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    private Transform spike;
    private float startingVert;
    private bool Up;

    //public float intensity;
    //public float distance;

    // Use this for initialization
    void Start()
    {
        spike = GetComponent<Transform>();
        startingVert = spike.position.y;
        Up = true;
        //while(true)
        StartCoroutine(UpDown());
    }

    IEnumerator UpDown()
    {
        while(true)
        {
            if (Up == true)
            {
                spike.Translate(0.0f, -1, 0.0f);
                Up = false;
            }
            yield return new WaitForSeconds(2);

            if (Up == false)
            {
                spike.Translate(0.0f, +1, 0.0f);
                Up = true;
            }

            yield return new WaitForSeconds(2);
        }

    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
