using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyGroup;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			GameObject group = Factory.create.ByReference(enemyGroup, Vector2.zero, Quaternion.identity);
			group.SendMessage("Spawn", 10);
		}
	}
}
