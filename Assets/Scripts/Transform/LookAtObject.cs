﻿using UnityEngine;
using System.Collections;

public class LookAtObject : MonoBehaviour
{
	public GameObject objectToLookAt;
	public bool continuous = true;
	public float slerp = 1.0f;

	void OnEnable ()
	{
		if (objectToLookAt) {
			TurnTowardsObject ();
		}
	}

	void Update ()
	{
		if (objectToLookAt && continuous) {
			TurnTowardsObject ();
		}
	}

	private void TurnTowardsObject ()
	{
		Vector3 relativeLookDirection = transform.position - objectToLookAt.transform.position;
		float angle = Mathf.Atan2 (relativeLookDirection.y, relativeLookDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis (angle, Vector3.forward), slerp);
	}
}
