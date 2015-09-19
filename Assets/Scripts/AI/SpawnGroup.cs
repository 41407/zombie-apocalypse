using UnityEngine;
using System.Collections;

public class SpawnGroup : MonoBehaviour
{
	public int numberOfEnemies = 0;

	void Update() {
		Factory.create.Enemy(transform.position, Quaternion.identity);
		numberOfEnemies--;
		if (numberOfEnemies < 0) {
			gameObject.SetActive(false);
		}
	}

	public void Spawn(int numberOfEnemies) {
		this.numberOfEnemies = numberOfEnemies;
	}
}
