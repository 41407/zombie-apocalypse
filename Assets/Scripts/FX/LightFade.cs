using UnityEngine;
using System.Collections;

public class LightFade : MonoBehaviour
{
	private Light lightComponent;
	public float fadeSpeed;

	void OnEnable ()
	{
		lightComponent = gameObject.GetComponent<Light> ();
		lightComponent.intensity = 1.00f;
	}

	void Update ()
	{
		lightComponent.intensity = lightComponent.intensity - Time.deltaTime * fadeSpeed;
	}
}
