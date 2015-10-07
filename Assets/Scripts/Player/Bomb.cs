using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public float bombReloadTime = 10f;
	public float bombTimer = 0f;
	public GameObject bomb;
	private bool reloading = true;

	void Update ()
	{
		if (bombTimer < bombReloadTime && reloading) {
			bombTimer = Mathf.Clamp (bombTimer + Time.deltaTime, 0, bombReloadTime);
		}
	}

	void FireBomb ()
	{
		if (bombTimer >= bombReloadTime) {
			bombTimer = 0;
			CreateExplosion ();
		}
	}

	void StartFiring ()
	{
		reloading = false;
	}

	void StopFiring ()
	{
		reloading = true;
	}

	void CreateExplosion ()
	{
		Factory.create.ByReference (bomb, transform.position, transform.rotation);
	}
}
