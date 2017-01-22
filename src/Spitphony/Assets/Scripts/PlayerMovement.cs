using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTrans;
    private Rigidbody rigidB;

    private bool isInAir;
    private float oldV;
    private float newV;

    public float speed = 0.5f;
	public float jumpDist = 450f;
	public float walkDist = 25f;
	public int maxSpeed = 8;

	void Start () {
        isInAir = false;
        playerTrans = GetComponent<Transform>();
        rigidB = GetComponent<Rigidbody>();
        float oldV = playerTrans.position.y;
	}

	void OnCollisionEnter(Collision other){
		isInAir = false;
	}

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		oldV = playerTrans.position.y;
		Debug.Log((oldV - newV) + ", isInAir: "+ isInAir);
		Vector3 jumpForce = new Vector3(0.0f, jumpDist, 0.0f);


//		if (rigidB.velocity.y <= 0 + float.Epsilon && !isInAir) // replaced with collision testing
		if (!isInAir)
        {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				rigidB.AddForce (jumpForce);
				isInAir = true;
			} 
		} 
		if (moveHorizontal < 0) {

			if (isInAir) {
				Vector3 walkForce = new Vector3 (-1*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			} else {
				Vector3 walkForce = new Vector3 (-2*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			}
		} else if (moveHorizontal > 0) {

			if (isInAir) {
				Vector3 walkForce = new Vector3 (1*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			} else {
				Vector3 walkForce = new Vector3 (2*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			}

		}

//		if (rigidB.velocity.y > 20) {
//			rigidB.velocity.y = 20;
//		}else if(rigidB.velocity.y < -20){
//			rigidB.velocity.y = -20;
//		}

//		if (rigidB.velocity.x > maxHozSpeed) {
//			rigidB.velocity = new Vector3(rigidB.velocity.x, maxHozSpeed, rigidB.velocity.z);
//		}else if(rigidB.velocity.x < -1*maxHozSpeed){
//			rigidB.velocity = new Vector3(rigidB.velocity.x, -1*maxHozSpeed, rigidB.velocity.z);
//		}
		if(rigidB.velocity.magnitude > maxSpeed){
			rigidB.velocity = Vector3.ClampMagnitude(rigidB.velocity, maxSpeed);
		}

		Debug.Log ("Y: "+rigidB.velocity.y);


		Debug.Log ("X: "+rigidB.velocity.x);
        
		newV = playerTrans.position.y;
    }
}
