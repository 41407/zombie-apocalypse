using UnityEngine;
using System.Collections;

public class PowerupFinder : MonoBehaviour
{

	public GameObject powerUp;

	void Update ()
	{
		if (powerUp) {
			if (powerUp.activeSelf) {
				transform.LookAt (powerUp.transform.position);
			}
		}
		powerUp = GameObject.FindGameObjectWithTag ("Power up");
	}
}
