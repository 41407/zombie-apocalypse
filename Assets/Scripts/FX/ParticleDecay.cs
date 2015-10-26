using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
	private ParticleSystem particles;

	void Awake ()
	{
		particles = gameObject.GetComponent<ParticleSystem> ();
	}

	void OnEnable ()
	{
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
