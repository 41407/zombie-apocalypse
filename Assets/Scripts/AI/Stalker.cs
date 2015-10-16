using UnityEngine;
using System.Collections;

public class Stalker : MonoBehaviour
{
	public float chargeSpeed;
	public bool onCooldown = false;
	public float cooldownTime = 2.0f;
	public string targetTag;
	private CircleCollider2D trigger;
	private Rigidbody2D body;
	private TrailRenderer trail;
	private AudioSource aud;

	void OnEnable ()
	{
		if (!trigger) {
			trigger = gameObject.GetComponent<CircleCollider2D> ();
		}
		if (!body) {
			body = gameObject.GetComponent<Rigidbody2D> ();
		}
		if (!trail) {
			trail = gameObject.GetComponent<TrailRenderer> ();
		}
		if (!aud) {
			aud = GetComponent<AudioSource> ();
		}
	}

	void OnBecameVisible ()
	{
		trigger.enabled = true;
	}
	
	void OnBecameInvisible ()
	{
		trigger.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (!onCooldown && targetTag.Contains (col.tag)) {
			Turn (col.gameObject.transform.position);
			Charge ();
			onCooldown = true;
			Invoke ("CancelCooldown", cooldownTime);
		}
	}

	private void Turn (Vector3 targetPosition)
	{
		Vector3 relativeLookDirection = transform.position - targetPosition;
		float angle = Mathf.Atan2 (relativeLookDirection.y, relativeLookDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void Charge ()
	{
		body.AddForce (transform.rotation * Vector2.up * chargeSpeed);
		trail.enabled = true;
		aud.Play ();
	}

	private void CancelCooldown ()
	{
		onCooldown = false;
		trail.enabled = false;
	}
}
