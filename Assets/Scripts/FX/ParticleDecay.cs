using UnityEngine;
using System.Collections;

public class ParticleDecay : MonoBehaviour
{
	void Update ()
	{
		if (gameObject.GetComponent<ParticleSystem> ().isStopped) {
			if (transform.parent) {
				transform.parent.gameObject.SetActive (false);
			} else {
				gameObject.SetActive (false);
			}
		}
	}

	void OnEnable ()
	{
		gameObject.GetComponent<ParticleSystem> ().Play ();
	}
	
	void OnDisable ()
	{
		gameObject.GetComponent<ParticleSystem> ().Stop ();
	}
}
