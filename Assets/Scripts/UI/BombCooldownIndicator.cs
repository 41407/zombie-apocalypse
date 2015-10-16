using UnityEngine;
using System.Collections;

public class BombCooldownIndicator : MonoBehaviour
{
	private AudioSource aud;
	public GameObject player;
	private Bomb bombScript;
	private ParticleSystem particles;
	public float startingAngle = 120f;
	private bool bombReady = false;

	void OnEnable ()
	{
		aud = GetComponent<AudioSource> ();
		bombScript = player.GetComponent<Bomb> ();
		particles = gameObject.GetComponent<ParticleSystem> ();
	}
	
	void Update ()
	{
		float angle = startingAngle - (bombScript.bombTimer / bombScript.bombReloadTime) * startingAngle;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		if (bombScript.bombTimer == bombScript.bombReloadTime && bombReady == false) {
			bombReady = true;
			particles.Play ();
			aud.Play ();
		}
		if (bombScript.bombTimer < 0.1f) {
			bombReady = false;
		}
	}
}
