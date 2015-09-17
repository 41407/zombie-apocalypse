using UnityEngine;
using System.Collections;

public class TurnTowardsAndFollow : MonoBehaviour
{
	public GameObject player;
	public float turningSpeed;
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

	private float CalculateSpeed() {
		return (baseMoveSpeed + randomSpeedModifier) * moveSpeedModifier;
	}

	private void TurnTowardsPlayer ()
	{
		Vector2 heading = player.transform.position - transform.position;
		float angle = transform.rotation.eulerAngles.z;
		float angleBetween = Vector2.Angle (Vector2.up, heading);
		if (heading.x > 0) {
			angleBetween = 360 - angleBetween;
		}
		if (angleBetween - angle > 180) {
			angleBetween -= 360;	
		}
		
		if (angleBetween - angle < -180) {
			angleBetween += 360;	
		}
		if (angleBetween - angle > 0) {
			gameObject.transform.Rotate (new Vector3 (0, 0, turningSpeed * Time.deltaTime));
		} else {
			gameObject.transform.Rotate (new Vector3 (0, 0, -turningSpeed * Time.deltaTime));
		}	
	}
}
