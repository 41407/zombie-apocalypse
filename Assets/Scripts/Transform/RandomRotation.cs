using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{
	public bool x;
	public bool y;
	public bool z;

	void OnEnable ()
	{
		if (x) {
			transform.Rotate (Vector3.right, Random.Range (0, 360));
		}
		if (y) {
			transform.Rotate (Vector3.up, Random.Range (0, 360));
		}
		if (z) {
			transform.Rotate (Vector3.forward, Random.Range (0, 360));
		}
	}
}
