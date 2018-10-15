using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	private Vector3 target;
	public float speed	;
	private GameObject bullet;
	// Use this for initialization
	void Start () {
		target = (Camera.main.ScreenToWorldPoint (Input.mousePosition) - 	transform.position).normalized;
		target.z = 0f;
		bullet = GetComponent<GameObject> ();
		//Vector3 mousePos = Input.mousePosition;
		//mousePos.z = -0.1f;
		//mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//transform.LookAt (mousePos);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		transform.position += target * speed * Time.deltaTime;
		//transform.Translate(transform.forward * speed * Time.deltaTime);
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Stage")
			Debug.Log ("HIT!");
		Destroy (this.gameObject);
	}
}
