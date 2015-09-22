using UnityEngine;
using System.Collections;

public class RandomShakePosition : MonoBehaviour {

	public float range = 2.0f;
	private Vector3 startingPosition;

	void OnEnable() {
		startingPosition = transform.position;
	}

	void Update () {
		Vector3 shaky = new Vector3 (startingPosition.x + Random.Range(-range, range), startingPosition.y + Random.Range(-range, range), startingPosition.z + Random.Range(-range, range));
		transform.position = shaky;
	}
}
