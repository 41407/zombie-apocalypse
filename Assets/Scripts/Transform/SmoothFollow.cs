﻿using UnityEngine;
using System.Collections;
using System;

public class SmoothFollow : MonoBehaviour
{

	public GameObject objectToFollow;
	public GameObject mouse;
	public Vector3 targetPosition;
	public float z;
	public float smoothness;
	public float mousiness;

	void Update ()
	{
		if (objectToFollow) {	
			targetPosition = mouse.transform.position;
			targetPosition = Vector3.Lerp (objectToFollow.transform.position, targetPosition, mousiness);
			Vector3 newPosition = new Vector3 (targetPosition.x, targetPosition.y, z);
			transform.position = Vector3.Lerp (transform.position, newPosition, smoothness);
		} else {
			transform.position = new Vector3 (targetPosition.x, targetPosition.y, z);
		}
	}
}
