using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTrans;
    private Rigidbody rigidB;

    private bool isInAir;
    private float oldV;
    private float newV;

    public float speed;
    public float jumpDist;

	void Start () {
        isInAir = false;
        playerTrans = GetComponent<Transform>();
        rigidB = GetComponent<Rigidbody>();
        float oldV = playerTrans.position.y;
    }
	
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        oldV = playerTrans.position.y;
        Debug.Log(oldV - newV);
        Vector3 jumpForce = new Vector3(0.0f, jumpDist, 0.0f);

        if (rigidB.velocity.y <= (0 + float.Epsilon) && rigidB.velocity.y >= (0 - float.Epsilon) && !isInAir)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidB.AddForce(jumpForce);
                isInAir = true;
            }
            else
            {
                playerTrans.Translate(moveHorizontal * speed, 0.0f, 0.0f);
            }
        }
        else
        {
            playerTrans.Translate(moveHorizontal * speed, 0.0f, 0.0f);
            isInAir = false;
        }

        newV = playerTrans.position.y;
    }
}
