using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTrans;
	private Rigidbody rigidB;
	private SpriteRenderer spriteRender;

    private bool isInAir;
    private float oldV;
    private float newV;

	public Image healthbar;
	public float max_health = 100f;
	public float cur_health = 0f;

    public float speed = 0.5f;
	public float jumpDist = 450f;
	public float walkDist = 25f;
	public int maxSpeed = 8;

	void Start () {
		cur_health = max_health;
        isInAir = false;
		spriteRender = GetComponent<SpriteRenderer>();
        playerTrans = GetComponent<Transform>();
        rigidB = GetComponent<Rigidbody>();
        float oldV = playerTrans.position.y;
		InvokeRepeating ("decreaseHealth", 0f, 2f);
	}

	void OnCollisionEnter(Collision other){
		isInAir = false;
	}

	void decreaseHealth(){
		cur_health -= 5f;
		SetHealth (cur_health / max_health);
	}

	void SetHealth(float health) {
		healthbar.fillAmount = health;
	}

	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		oldV = playerTrans.position.y;
		Debug.Log((oldV - newV) + ", isInAir: "+ isInAir);
		Vector3 jumpForce = new Vector3(0.0f, jumpDist, 0.0f);

		if (!isInAir)
        {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				rigidB.AddForce (jumpForce);
				isInAir = true;
			} 
		} 
		if (moveHorizontal < 0) {

			spriteRender.flipX = true;
			if (isInAir) {
				Vector3 walkForce = new Vector3 (-1*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			} else {
				Vector3 walkForce = new Vector3 (-2*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			}
		} else if (moveHorizontal > 0) {

			spriteRender.flipX = false;
			if (isInAir) {
				Vector3 walkForce = new Vector3 (1*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			} else {
				Vector3 walkForce = new Vector3 (2*walkDist, 0.0f, 0.0f);
				rigidB.AddForce (walkForce);
			}

		}

		if(rigidB.velocity.magnitude > maxSpeed){
			rigidB.velocity = Vector3.ClampMagnitude(rigidB.velocity, maxSpeed);
		}

		Debug.Log ("Y: "+rigidB.velocity.y);


		Debug.Log ("X: "+rigidB.velocity.x);
        
		newV = playerTrans.position.y;
    }
}
