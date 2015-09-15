using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	void Update () {
		Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = newPosition;
	}
}
