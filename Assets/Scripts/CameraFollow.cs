﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - target.transform.position;
	}

	void LateUpdate()
	{
		transform.position = target.transform.position + offset;
	}
}
