using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	private float moveSpeed;
	private Animator anim;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		moveSpeed = 7f;
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			rb2d.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal")*moveSpeed, rb2d.velocity.y);
		}
		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x,Input.GetAxisRaw ("Vertical")*moveSpeed );
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0f );
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	}
		
}
