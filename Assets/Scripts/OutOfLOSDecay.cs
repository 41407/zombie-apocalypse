using UnityEngine;
using System.Collections;

public class OutOfLOSDecay : MonoBehaviour
{
	public float decayTime = 0.0f;
	public float decayTimer;
	public bool outOfLOS;
	
	void OnEnable ()
	{
		decayTimer = decayTime;
	}

	void Update ()
	{
		if (outOfLOS) {
			if (decayTime > 0f) {
				decayTimer -= Time.deltaTime / decayTime;
			}
			if (decayTimer <= 0f || decayTime == 0f) {
				gameObject.SetActive (false);
			}
		}
	}
	
	void OnBecameVisible ()
	{
		outOfLOS = false;
	}

	void OnBecameInvisible ()
	{
		outOfLOS = true;
	}
}
