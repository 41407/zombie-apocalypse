using UnityEngine;
using System.Collections;

public class RandomAudioClip : MonoBehaviour
{
	public AudioClip[] clips;
	private AudioSource source;
	public float pitchMin = 1f;
	public float pitchMax = 1f;
	public bool playOnEnable = true;

	void Awake ()
	{
		source = GetComponent<AudioSource> ();
	}

	void OnEnable ()
	{
		source.clip = clips [Random.Range (0, clips.Length)];
		source.pitch = Random.Range (pitchMin, pitchMax);
		if (playOnEnable) {
			source.Play ();
		}
	}
}
