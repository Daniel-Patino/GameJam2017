using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {

    public GameObject[] lazerBeam;
    public Transform showSpawn;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shots = Instantiate(lazerBeam[Random.Range(0, lazerBeam.Length)], showSpawn.position, showSpawn.rotation) as GameObject;
        }
    }
}
