using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLamaAttack : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public GameObject llama;
	private SpriteRenderer spriteRender;
	private int alt;

	void Start () {

		spriteRender = llama.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody>();
		if (spriteRender.flipX) {
			alt = 1;
		} else {
			alt = -1;
		}

		rb.velocity = transform.right * alt * speed;
	} 
}
