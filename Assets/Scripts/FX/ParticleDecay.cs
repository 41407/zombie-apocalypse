using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
	private ParticleSystem particles;

	void OnEnable ()
	{
		particles = gameObject.GetComponent<ParticleSystem> ();
		particles.Play ();
		Invoke ("Disable", particles.duration);
	}

	void Disable ()
	{
		particles.Stop ();
		if (transform.parent) {
			transform.parent.gameObject.SetActive (false);
		} else {
			gameObject.SetActive (false);
		}
	}
}
