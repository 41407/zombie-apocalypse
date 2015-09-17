using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

	public float speed = 500.0f;

	void OnEnable ()
	{
		GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * speed);
	}

	public void SetVelocity (Vector2 velocity)
	{
		GetComponent<Rigidbody2D> ().velocity = velocity;
	}

	public void SetSpeed (float magnitude)
	{
		GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * magnitude);
	}
}
