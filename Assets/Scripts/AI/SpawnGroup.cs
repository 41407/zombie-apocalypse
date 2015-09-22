﻿using UnityEngine;
using System.Collections;

public class SpawnGroup : MonoBehaviour
{
	public int numberOfEnemies = 0;
	public bool startSpawning = false;

	void Update ()
	{
		if (startSpawning) {
			Factory.create.Enemy (transform.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
			numberOfEnemies--;
			if (numberOfEnemies <= 0) {
				gameObject.SetActive (false);
			}
		}
	}

	public void Spawn (int numberOfEnemies)
	{
		this.numberOfEnemies = numberOfEnemies;
		startSpawning = true;
	}
}
