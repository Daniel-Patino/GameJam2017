using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    private Transform trans;
    private float startingVert;
    private bool movingUp;

    public float intensity;
    public float distance;

	// Use this for initialization
	void Start () {
        trans = GetComponent<Transform>();
        startingVert = trans.position.y;
        movingUp = true;
    }
	
	// Update is called once per frame
	void Update () {

        

        if(trans.position.y < startingVert + distance && movingUp)
        {
            trans.Translate(0.0f, +intensity, 0.0f);
            if (trans.position.y >= startingVert + distance)
            {
                movingUp = false;
            }
        }
        
        if(trans.position.y > startingVert && !movingUp)
        {
            trans.Translate(0.0f, -intensity, 0.0f);
            if (trans.position.y <= startingVert)
            {
                movingUp = true;
            }
        }
	}
}
