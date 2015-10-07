using UnityEngine;
using System.Collections;

public class PowerupFinder : MonoBehaviour
{

	public GameObject powerUp;

	void Update ()
	{
		if (powerUp) {
			if (powerUp.activeSelf) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (powerUp.transform.position - transform.position), 0.1f);
			}
		}
		powerUp = GameObject.FindGameObjectWithTag ("Power up");
	}
}
