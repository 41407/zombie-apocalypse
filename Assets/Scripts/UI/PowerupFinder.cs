using UnityEngine;
using System.Collections;

public class PowerupFinder : MonoBehaviour
{
	public GameObject powerUp;
	public float pollingRate = 5.0f;

	void OnEnable ()
	{
		InvokeRepeating ("FindPowerup", pollingRate, pollingRate);
	}

	void Update ()
	{
		if (powerUp) {
			if (powerUp.activeSelf) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (powerUp.transform.position - transform.position), 0.1f);
			}
		}
	}

	void FindPowerup ()
	{
		powerUp = GameObject.FindGameObjectWithTag ("Power up");
	}
}
