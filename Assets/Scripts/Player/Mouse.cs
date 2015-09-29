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
		transform.position = GetWorldPositionOnPlane (Input.mousePosition, 0);
	}

	/**
	 *  Uses raycasting to find given screen position on a plane perpendicular to the camera
	 *  in given z coordinate;
	 * 
	 *  http://answers.unity3d.com/questions/566519/camerascreentoworldpoint-in-perspective.html
	 */
	private Vector3 GetWorldPositionOnPlane (Vector3 screenPosition, float z)
	{
		Ray ray = Camera.main.ScreenPointToRay (screenPosition);
		Plane xy = new Plane (Vector3.forward, new Vector3 (0, 0, z));
		float distance;
		xy.Raycast (ray, out distance);
		return ray.GetPoint (distance);
	}
}
