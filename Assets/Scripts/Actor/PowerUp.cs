using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
	public string powerup;
	public GameObject pickupEffect;
	public GameObject spawnEffect;
	
	void OnEnable ()
	{
		if (spawnEffect) {
			Factory.create.ByReference (spawnEffect, transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			col.gameObject.SendMessage (powerup, SendMessageOptions.DontRequireReceiver);
			if (pickupEffect) {
				Factory.create.ByReference (pickupEffect, transform.position, transform.rotation);
			}
			gameObject.SetActive (false);
		}
	}
}
