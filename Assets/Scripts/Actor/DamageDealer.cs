using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
	public string tags;
	public int damage;
	public int variance;
	public bool destroyOnImpact = false;
	public GameObject impactParticle;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (tags.Equals(col.gameObject.tag)) {
			col.gameObject.SendMessage ("TakeDamage", (Mathf.Max (damage + Random.Range (-variance, variance), 1)));
		}
		if (impactParticle) {
			Factory.create.ByReference (impactParticle, transform.position, transform.rotation);
		}
		if (destroyOnImpact) {
			gameObject.SetActive (false);
		}
	}

	void SetDamage (int newDamage)
	{
		damage = newDamage;
	}
}
