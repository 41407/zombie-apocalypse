using UnityEngine;
using System.Collections;

public class RandomAudioClip : MonoBehaviour
{
	public AudioClip[] clips;
	private AudioSource source;
	public float pitchMin = 1f;
	public float pitchMax = 1f;

	void OnEnable ()
	{
		if(!source) {
			source = gameObject.GetComponent<AudioSource> ();
		}
		source.clip = clips [Random.Range (0, clips.Length)];
		source.pitch = Random.Range (pitchMin, pitchMax);
		source.Play ();
	}
}
