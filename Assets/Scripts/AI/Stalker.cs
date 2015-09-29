using UnityEngine;
using System.Collections;

public class Stalker : MonoBehaviour
{
	public float chargeSpeed;
	public bool onCooldown = false;
	public float cooldownTime = 2.0f;

	void OnTriggerStay2D (Collider2D col)
	{
		if (!onCooldown) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector2.up * chargeSpeed);
			onCooldown = true;
			Invoke ("CancelCooldown", cooldownTime);
		}
	}

	private void CancelCooldown ()
	{
		onCooldown = false;
	}
}
