using UnityEngine;
using System.Collections;

public class ConstantRotation : MonoBehaviour
{
	public float rate;
	private float angle = 0;
	
	void Update ()
	{
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		angle += rate * Time.deltaTime;
	}
}
