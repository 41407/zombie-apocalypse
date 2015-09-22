using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyGroup;
	public int numberOfEnemies;
	public float spawnInterval = 2.0f;
	public float distanceFromPlayer = 5.0f;

	void OnEnable ()
	{
		InvokeRepeating ("Spawn", 0, spawnInterval);
	}

	public void Spawn ()
	{
		try {
			Vector2 playerPosition = GetComponent<SceneController> ().player.transform.position;
			Vector2 groupPosition = Random.insideUnitCircle.normalized * distanceFromPlayer + playerPosition;
			GameObject group = Factory.create.ByReference (enemyGroup, groupPosition, Quaternion.identity);
			group.SendMessage ("Spawn", numberOfEnemies);
			numberOfEnemies++;
		} catch (MissingReferenceException e) {
			print ("Exception caught: " + e);
		}
	}
}
