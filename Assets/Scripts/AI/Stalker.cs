using UnityEngine;
using System.Collections;

public class Stalker : MonoBehaviour
{
	public float chargeSpeed;
	public bool onCooldown = false;
	public float cooldownTime = 2.0f;
	public string targetTag;

	void OnTriggerEnter2D (Collider2D col)
	{
		if (!onCooldown && targetTag.Contains (col.tag)) {
			Turn (col.gameObject);
			Charge ();
			onCooldown = true;
			Invoke ("CancelCooldown", cooldownTime);
		}
	}

	private void Turn (GameObject towards)
	{
		Vector3 relativeLookDirection = transform.position - towards.transform.position;
		float angle = Mathf.Atan2 (relativeLookDirection.y, relativeLookDirection.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	void Charge ()
	{
		gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector2.up * chargeSpeed);
		gameObject.GetComponent<TrailRenderer> ().enabled = true;
	}

	private void CancelCooldown ()
	{
		onCooldown = false;
		gameObject.GetComponent<TrailRenderer> ().enabled = false;
	}
}
