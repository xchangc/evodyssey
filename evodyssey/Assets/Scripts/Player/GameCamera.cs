﻿using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Vector3 cameraTarget;

	private Transform target;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {

		// Main Camera following the player's position
		cameraTarget = new Vector3 (target.position.x, transform.position.y, target.position.z);
		transform.position = Vector3.Lerp (transform.position, cameraTarget, Time.deltaTime * 8);
	}
}
