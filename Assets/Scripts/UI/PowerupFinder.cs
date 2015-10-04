using UnityEngine;
using System.Collections;

public class PowerupFinder : MonoBehaviour
{

	public GameObject powerUp;

	void Update ()
	{
		if (powerUp) {
			transform.LookAt (powerUp.transform.position);
		} else {
			powerUp = GameObject.FindGameObjectWithTag ("PowerUp");
		}
	}
}
