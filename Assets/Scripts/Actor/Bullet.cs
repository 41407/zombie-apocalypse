using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed = 500.0f;
	public GameObject trailParticle;

	void OnEnable ()
	{
		GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * speed);
	}

	void Update ()
	{
		if (trailParticle) {
			Factory.create.ByReference (trailParticle, transform.position, transform.rotation);
		}
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
