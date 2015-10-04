using UnityEngine;
using System.Collections;

public class RandomAudioClip : MonoBehaviour
{
	public AudioClip[] clips;
	public float pitchMin = 1f;
	public float pitchMax = 1f;

	void OnEnable ()
	{
		gameObject.GetComponent<AudioSource> ().clip = clips [Random.Range (0, clips.Length)];
		gameObject.GetComponent<AudioSource> ().Play ();
		gameObject.GetComponent<AudioSource> ().pitch = Random.Range (pitchMin, pitchMax);
	}
}
