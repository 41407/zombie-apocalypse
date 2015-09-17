using UnityEngine;
using System.Collections;

public class TrailDecay : MonoBehaviour
{
	/**
	 * 
	 *  Source: 
	 * 	http://forum.unity3d.com/threads/trailrenderer-reset.38927/
	 */


	protected TrailRenderer trail;
	protected float decayTime = 0;
		
	void Awake ()
	{
		trail = gameObject.GetComponent<TrailRenderer> ();
		if (!trail) {
			Debug.LogError ("[TrailRendererHelper.Awake] invalid TrailRenderer.");
			return;
		}
		decayTime = trail.time;
	}
		
	void OnEnable ()
	{
		if (!trail) {
			return;
		}
		StartCoroutine (ResetTrails ());
	}
		
	IEnumerator ResetTrails ()
	{
		trail.time = 0;
		yield return new WaitForEndOfFrame ();
		trail.time = decayTime;
	}
}

