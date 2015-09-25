using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	public GameObject enemyGroup;
	public int hordeSize;
	public float spawnInterval = 2.0f;
	public float distanceFromPlayer = 5.0f;
	private Vector2 playerPosition;

	void OnEnable ()
	{
		InvokeRepeating ("Spawn", 0, spawnInterval);
	}

	public void Spawn ()
	{
		if (GetComponent<SceneController> ().player) {
			playerPosition = GetComponent<SceneController> ().player.transform.position;
			int formation = Random.Range (1, 1);
			switch (formation) {
			case 0:
				Horde ();
				break;
			case 1:
				Surround ();
				break;
			default:
				break;
			}
		}
	}

	public void Surround ()
	{
		Vector2 groupPosition;
		for (int i = 0; i < Random.Range(10, 50); i++) {
			groupPosition = Random.insideUnitCircle.normalized * distanceFromPlayer + playerPosition;
			GameObject group = Factory.create.ByReference (enemyGroup, groupPosition, Quaternion.identity);
			group.SendMessage ("Spawn", Random.Range (1, 5));
		}
	}

	public void Horde ()
	{
		Vector2 groupPosition = Random.insideUnitCircle.normalized * distanceFromPlayer + playerPosition;
		GameObject group = Factory.create.ByReference (enemyGroup, groupPosition, Quaternion.identity);
		group.SendMessage ("Spawn", hordeSize);
		hordeSize++;
	}
}
