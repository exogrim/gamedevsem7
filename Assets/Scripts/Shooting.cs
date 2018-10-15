using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject Bullet;
	private Transform playerPos;

	// Use this for initialization
	void Start () {
		playerPos = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (Bullet, playerPos.position, Quaternion.identity);
		}
	}
}
