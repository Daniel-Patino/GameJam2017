using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {

    public GameObject[] lazerBeam;
    public Transform showSpawn;

    public float fireRate = 0.5f;
    public float moveSpeed = 5.0f;

    private float nextFire = 0.0f;
    private Vector3 axis;
    private Vector3 pos;

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
