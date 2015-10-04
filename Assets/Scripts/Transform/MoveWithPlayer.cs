using UnityEngine;
using System.Collections;

public class MoveWithPlayer : MonoBehaviour
{
	public GameObject player;
	public float repeatRate = 10.0f;

	void Update ()
	{
		Vector3 deltaPosition = transform.position - player.transform.position; 
		if (Mathf.Abs (transform.position.x - player.transform.position.x) > repeatRate) {
			transform.Translate (new Vector2 (-deltaPosition.x, 0));
		}
		
		if (Mathf.Abs (transform.position.y - player.transform.position.y) > repeatRate) {
			transform.Translate (new Vector2 (0, -deltaPosition.y));
		}
	}
}
