using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	public bool hideCursor = true;

	void OnEnable ()
	{
		if (hideCursor) {
			Cursor.visible = false;
		}
	}

	void Update ()
	{
		Vector2 newPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = newPosition;
	}
}
