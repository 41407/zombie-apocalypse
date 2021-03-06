﻿using UnityEngine;
using System.Collections;

public class TurnTowardsAndFollow : MonoBehaviour
{
	public Transform player;
	public float turningRate = 0.1f;
	public float baseMoveSpeed = 300f;
	public float moveSpeedModifier = 1.0f;
	public float moveSpeedVariance;
	private float randomSpeedModifier;
	private float moveSpeed;
	public float maxStunInterval = 2.0f;
	public float stunLength = 1.0f;
	public bool stunned = false;
	private Rigidbody2D body;

	void SetPlayer (GameObject player)
	{
		this.player = player.transform;
	}

	void SetMoveSpeedModifier (float newModifier)
	{
		moveSpeedModifier = newModifier;
		moveSpeed = CalculateSpeed ();
	}

	void OnEnable ()
	{
		randomSpeedModifier = Random.Range (0, moveSpeedVariance);
		moveSpeed = CalculateSpeed ();
		if (maxStunInterval > 0) {
			RemoveStun ();
		}
		if (!body) {
			body = gameObject.GetComponent<Rigidbody2D> ();
		}
	}
	
	void Update ()
	{
		if (!stunned) {
			if (player) {
				TurnTowardsPlayer ();
			}
			body.AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
		}
	}

	private void SetStunned ()
	{
		stunned = true;
		Invoke ("RemoveStun", stunLength);
	}

	private void RemoveStun ()
	{
		stunned = false;
		Invoke ("SetStunned", Random.Range (1, maxStunInterval));
	}

	private float CalculateSpeed ()
	{
		return (baseMoveSpeed + randomSpeedModifier) * moveSpeedModifier;
	}

	private void TurnTowardsPlayer ()
	{
		Vector3 relativeLookDirection = transform.position - player.position;
		float angle = Mathf.Atan2 (relativeLookDirection.y, relativeLookDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis (angle, Vector3.forward), turningRate);
	}
}
