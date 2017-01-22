using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaAttack : MonoBehaviour {

	public float speed = 8;
	private Rigidbody rb;
	private GameObject llama;
	private Transform transLlama;
	private int alt;

	void Start () {

		llama = GameObject.Find ("Llama");
		transLlama = llama.GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		Debug.Log ("turn: " + transLlama.localScale.x);
		if (transLlama.localScale.x > 0) {
			alt = 1;
			transform.position = new Vector3(transLlama.position.x + 4, transLlama.position.y, transLlama.position.z);
		} else {
			alt = -1;
			transform.position = new Vector3(transLlama.position.x - 6, transLlama.position.y, transLlama.position.z);
		}
		rb.velocity = transform.right * alt * speed;
	} 
}
