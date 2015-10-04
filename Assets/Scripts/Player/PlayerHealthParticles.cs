using UnityEngine;
using System.Collections;

public class PlayerHealthParticles : MonoBehaviour
{
	private ParticleSystem particles;
	private PlayerHealth health;
	private Color flameColor;
	public float woundedSize = 0.5f;
	public float fullHealthSize = 2.0f;
	public float woundedRate = 5;
	public float fullHealthRate = 20;

	void OnEnable ()
	{
		flameColor = new Color (1, 1, 0);
		particles = gameObject.GetComponent<ParticleSystem> ();
		health = transform.parent.GetComponent<PlayerHealth> ();
	}

	void Update ()
	{
		if (health.currentHealth < health.maxHealth) {
			flameColor.g = 0.25f;
			particles.emissionRate = woundedRate;
		} else {
			particles.startSize = fullHealthSize;
			flameColor.g = 0.75f;
			particles.emissionRate = fullHealthRate;
		}
		if (health.regenerate && health.currentHealth < health.maxHealth) {
			flameColor.g = 0.75f;
			flameColor.r = 0;
			particles.startSize = fullHealthSize * (health.currentHealth / (health.maxHealth + 1));
		} else {
			flameColor.r = 1;
		}
		if (gameObject.GetComponentInParent<Firing> ().tripleMachineGunTimer > 0) {
			flameColor.b = 1;
			flameColor.r = 0.25f;
			flameColor.g = 0.45f;
		} else {
			flameColor.b = 0;
		}
		particles.startColor = flameColor;
	}
}
