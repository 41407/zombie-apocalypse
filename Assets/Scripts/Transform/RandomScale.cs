using UnityEngine;
using System.Collections;

public class RandomScale : MonoBehaviour {

	public float min = 1;
	public float max = 1;

	void OnEnable() {
		transform.localScale = Vector3.one * Random.Range (min, max);
	}
}
