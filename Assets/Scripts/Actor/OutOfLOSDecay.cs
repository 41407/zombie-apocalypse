using UnityEngine;
using System.Collections;

public class OutOfLOSDecay : MonoBehaviour
{
	public float decayTime = 0.0f;

	void OnEnable ()
	{
		Invoke("Destroy", decayTime);
	}


	void OnBecameVisible ()
	{
		CancelInvoke();
	}

	void OnBecameInvisible ()
	{
		Invoke("Destroy", decayTime);
	}

	private void Destroy () 
	{
		gameObject.SetActive (false);
	}
}
