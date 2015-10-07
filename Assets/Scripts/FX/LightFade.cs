using UnityEngine;
using System.Collections;

public class LightFade : MonoBehaviour
{
	private Light lightComponent;
	public float fadeSpeed;
	public float startingIntensity = 1.00f;

	void OnEnable ()
	{
		lightComponent = gameObject.GetComponent<Light> ();
		lightComponent.intensity = startingIntensity;
	}

	void Update ()
	{
		lightComponent.intensity = lightComponent.intensity - Time.deltaTime * fadeSpeed;
	}
}
