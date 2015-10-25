using UnityEngine;
using System.Collections;

public class ShakeOnDemand : MonoBehaviour
{
	private float currentMagnitude = 0;
	public float damping = 0.5f;
	public float limit = 4.0f;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Shake (0.1f);
		}
		if (currentMagnitude > 0) {
			transform.position = (Vector3)transform.position + (Vector3)(Vector2)Random.insideUnitCircle * currentMagnitude;
			currentMagnitude = Mathf.Clamp(Mathf.Lerp(currentMagnitude, 0, damping), 0, limit);
		}
	}

	public void Shake (float magnitude)
	{
		currentMagnitude += magnitude;
	}
}
