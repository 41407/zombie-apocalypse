using UnityEngine;
using System.Collections;

public class FadeDecay : MonoBehaviour
{
	public float initialAlpha = 1.0f;
	public float decayRate = 5.0f;
	private bool outOfLOS;
	private Renderer rend;

	void OnEnable ()
	{
		if (!rend) {
			rend = GetComponent<Renderer>();
		}
		SetAlpha (initialAlpha);
	}

	void Update ()
	{
		if (outOfLOS) {
			Color newColor = rend.material.color;
			float newAlpha = newColor.a - Time.deltaTime / decayRate;
			if (newAlpha > 0) {
				newColor.a = newAlpha;
				rend.material.color = newColor;
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
		Color initialColor = rend.material.color;
		initialColor.a = alpha;
		rend.material.color = initialColor;
	}
}