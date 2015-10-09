using UnityEngine;
using System.Collections;

public class PowerupFinder : MonoBehaviour
{
	public GameObject powerUp;
	public float pollingRate = 5.0f;
	private GameObject finderGraphic;

	void OnEnable ()
	{
		InvokeRepeating ("FindPowerup", pollingRate, pollingRate);
		finderGraphic = transform.GetChild (0).gameObject;
		finderGraphic.SetActive (false);
	}

	void Update ()
	{
		if (powerUp) {
			if (powerUp.activeSelf) {
				finderGraphic.SetActive (true);
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (powerUp.transform.position - transform.position), 0.1f);
			} else {
				finderGraphic.SetActive (false);
			}
		}
	}

	void FindPowerup ()
	{
		powerUp = GameObject.FindGameObjectWithTag ("Power up");
	}
}
