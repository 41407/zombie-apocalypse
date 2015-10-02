using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float maxHealth = 3.0f;
	public float currentHealth;
	public float regenRate = 0.5f;
	public bool regenerate = true;
	public bool screenShakeOnDamage = true;
	public GameObject explosion;
	public GameObject tookDamage;

	void OnEnable ()
	{
		currentHealth = maxHealth;
	}
	
	void Update ()
	{
		if (regenerate && currentHealth < maxHealth) {
			currentHealth = Mathf.Clamp (currentHealth + regenRate * Time.deltaTime, 0, maxHealth);
		}
	}

	void StartFiring ()
	{
		regenerate = false;
	}

	void StopFiring ()
	{
		regenerate = true;
	}

	void TakeDamage (float damage)
	{
		currentHealth -= damage;
		Camera.main.SendMessage ("Shake", 2.0f);
		if (tookDamage) {
			Factory.create.ByReference (tookDamage, transform.position, transform.rotation);
		}
		if (currentHealth < 0) {
			if (explosion) {
				Factory.create.ByReference (explosion, transform.position, transform.rotation);
			}
			Destroy (gameObject);
		}
	}
}
