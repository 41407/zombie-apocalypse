using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed = 500.0f;
	public GameObject trailParticle;
	private Rigidbody2D body;

	void Awake ()
	{
		body = GetComponent<Rigidbody2D> ();
	}

	void OnEnable ()
	{
		body.AddForce (transform.rotation * Vector3.up * speed);
	}

	void Update ()
	{
		if (trailParticle) {
			Factory.create.ByReference (trailParticle, transform.position, transform.rotation);
		}
	}

	public void SetVelocity (Vector2 velocity)
	{
		body.velocity = velocity;
	}

	public void SetSpeed (float magnitude)
	{
		body.AddForce (transform.rotation * Vector3.up * magnitude);
	}
}
