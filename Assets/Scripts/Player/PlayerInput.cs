using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	public float acceleration;
	public float speedupStartTime = 30.0f;
	public float speedupIncrement = 1.0f;
	public float finalAcceleration = 100.0f;

	void OnEnable ()
	{
		InvokeRepeating ("Speedup", speedupStartTime, 1.0f);
	}

	void Update ()
	{
		Movement ();
		Firing ();
	}

	void Movement ()
	{	
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		gameObject.GetComponent<Rigidbody2D> ().AddForce (input * acceleration);
	}

	void Firing ()
	{
		if (Input.GetMouseButtonDown (0)) {
			gameObject.SendMessage ("StartFiring");
		}
		if (Input.GetMouseButtonUp (0)) {
			gameObject.SendMessage ("StopFiring");
		}
	}

	void Speedup ()
	{
		acceleration += speedupIncrement;
		if (acceleration > finalAcceleration) {
			CancelInvoke ();
		}
	}
}
