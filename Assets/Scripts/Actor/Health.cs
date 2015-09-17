using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public int health;
	public int currentHealth;
	public int healthVariance;
	public bool applyScoring = true;
	public GameObject explosion;
	public GameObject tookDamage;
	public bool pooledObject = true;

	void OnEnable ()
	{
		if (explosion) {
			ObjectPool.pool.Initialize (explosion);
		}
		if (tookDamage) {
			ObjectPool.pool.Initialize (tookDamage);
		}
		health = Mathf.Max (1, health + Random.Range (-healthVariance, healthVariance));
		currentHealth = health;
	}

	public void TakeDamage (int damage)
	{
		currentHealth -= damage;
		if (tookDamage) {
			ObjectPool.pool.Pull (tookDamage, transform.position, transform.rotation).SetActive (true);
		
		}
		CheckHealth ();
	}
	
	void CheckHealth ()
	{
		if (currentHealth <= 0) {
			gameObject.SendMessage ("ZeroHealth", SendMessageOptions.DontRequireReceiver);
			if (applyScoring) {
				gameObject.SendMessage ("ApplyScoring", SendMessageOptions.DontRequireReceiver);
			}
			if (explosion) {
				ObjectPool.pool.Pull (explosion, transform.position, transform.rotation).SetActive (true);
		
			}
			if (pooledObject) {
				gameObject.SetActive (false);
			} else {
				Destroy (gameObject);		
			}
		}
	}
}
