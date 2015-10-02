using UnityEngine;
using System.Collections;

public class ShakeOnDemand : MonoBehaviour
{
	private float currentMagnitude = 0;
	public float damping = 0.5f;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Shake (0.1f);
		}
		if (currentMagnitude > 0) {
			transform.position = (Vector3)transform.position + (Vector3)(Vector2)Random.insideUnitCircle * currentMagnitude;
			currentMagnitude *= damping;
		}
	}

	public void Shake (float magnitude)
	{
		currentMagnitude += magnitude;
	}
}
