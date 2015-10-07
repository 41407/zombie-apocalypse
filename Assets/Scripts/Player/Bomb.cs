using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public float bombReloadTime = 10f;
	public float bombTimer = 0f;

	void Update ()
	{
		if (bombTimer < bombReloadTime) {
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

	void CreateExplosion ()
	{

	}
}
