using UnityEngine;
using System.Collections;

public class LightFlutter : MonoBehaviour
{

	private Light source;
	public float min = 0;
	public float max = 4;
	private float target;
	public float rate = 0.25f;
	public float lerp = 0.4f;

	void Awake ()
	{
		source = GetComponent<Light> ();
	}

	void OnEnable ()
	{
		InvokeRepeating ("Flutter", rate, rate);
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}

	void Update ()
	{
		source.intensity = Mathf.Lerp (source.intensity, target, lerp);
	}

	void Flutter ()
	{
		target = Random.Range (min, max);
	}
}
