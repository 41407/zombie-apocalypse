using UnityEngine;
using System.Collections;

public class MoveWithPlayer : MonoBehaviour
{
	public GameObject player;
	public float textureSize = 10.0f;
	public float updateInterval = 2.0f;

	void OnEnable() {
		InvokeRepeating ("UpdatePosition", updateInterval, updateInterval);
	}

	void UpdatePosition ()
	{
		if (player) {
			Vector3 deltaPosition = transform.position - player.transform.position; 
			if (Mathf.Abs (transform.position.x - player.transform.position.x) > textureSize) {
				transform.Translate(new Vector2 (Mathf.Clamp(-deltaPosition.x, -textureSize, textureSize), 0));
			}
		
			if (Mathf.Abs (transform.position.y - player.transform.position.y) > textureSize) {
				transform.Translate(new Vector2 (0, Mathf.Clamp(-deltaPosition.y, -textureSize, textureSize)));
			}
		}
	}
}
