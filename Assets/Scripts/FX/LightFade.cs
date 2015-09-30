using UnityEngine;
using System.Collections;

public class LightFade : MonoBehaviour
{
	private Light light;
	public float fadeSpeed;

	void OnEnable ()
	{
		light = gameObject.GetComponent<Light> ();
		light.intensity = 1.00f;
	}

	void Update ()
	{
		light.intensity = light.intensity - Time.deltaTime * fadeSpeed;
	}
}
