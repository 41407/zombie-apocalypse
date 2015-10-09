using UnityEngine;
using System.Collections;

public class ConstantTranslate : MonoBehaviour
{

	public Vector3 translation;

	void Update ()
	{
		transform.Translate (translation * Time.deltaTime);
	}
}
