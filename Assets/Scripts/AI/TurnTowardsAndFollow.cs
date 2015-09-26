using UnityEngine;
using System.Collections;

public class TurnTowardsAndFollow : MonoBehaviour
{
	public GameObject player;
	public float turningRate = 0.1f;
	public float baseMoveSpeed = 300f;
	public float moveSpeedModifier = 1.0f;
	public float moveSpeedVariance;
	private float randomSpeedModifier;
	private float moveSpeed;

	void SetPlayer (GameObject player)
	{
		this.player = player;
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
	}
	
	void Update ()
	{
		if (player) {
			TurnTowardsPlayer ();
		}
		GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector2.up * moveSpeed * Time.deltaTime);
	}

	private float CalculateSpeed ()
	{
		return (baseMoveSpeed + randomSpeedModifier) * moveSpeedModifier;
	}

	private void TurnTowardsPlayer ()
	{
		Vector3 relativeLookDirection = gameObject.transform.position - player.transform.position;
		float angle = Mathf.Atan2 (relativeLookDirection.y, relativeLookDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.AngleAxis (angle, Vector3.forward), turningRate);
	}
}
