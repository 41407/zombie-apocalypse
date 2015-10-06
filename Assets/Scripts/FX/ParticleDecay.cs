using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
	private ParticleSystem particles;

	void Update ()
	{
		if (particles.isStopped) {
			if (transform.parent) {
				transform.parent.gameObject.SetActive (false);
			} else {
				gameObject.SetActive (false);
			}
		}
	}

	void OnEnable ()
	{
		particles = gameObject.GetComponent<ParticleSystem> ();
		particles.Play ();
	}
	
	void OnDisable ()
	{
		particles.Stop ();
	}
}
