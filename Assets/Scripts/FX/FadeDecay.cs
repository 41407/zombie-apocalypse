using UnityEngine;
using System.Collections;

public class FadeDecay : MonoBehaviour
{
	public float initialAlpha = 1.0f;
	public float decayRate = 5.0f;
	private bool outOfLOS;

	void OnEnable ()
	{
		SetAlpha (initialAlpha);
	}

	void Update ()
	{
		if (outOfLOS) {
			Color newColor = GetComponent<Renderer> ().material.color;
			float newAlpha = newColor.a - Time.deltaTime / decayRate;
			if (newAlpha > 0) {
				newColor.a = newAlpha;
				GetComponent<Renderer> ().material.color = newColor;
			} else {
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

	private void SetAlpha (float alpha)
	{
		Color initialColor = GetComponent<Renderer> ().material.color;
		initialColor.a = alpha;
		GetComponent<Renderer> ().material.color = initialColor;
	}
}