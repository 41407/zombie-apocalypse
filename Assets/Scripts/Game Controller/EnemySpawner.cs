using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public int hordeSize;
	public float spawnInterval = 0.5f;
	public float minimumDistanceFromPlayer = 5.0f;
	public float distanceVariance = 5.0f;
	private Vector2 cameraPosition;

	void OnEnable ()
	{
		InvokeRepeating ("Spawn", spawnInterval, spawnInterval);
	}

	public void Spawn ()
	{
		if (GetComponent<SceneController> ().player) {
			cameraPosition = Camera.main.transform.position;
			int formation = Random.Range (0, 10);
			switch (formation) {
			case 0:
				Horde ();
				break;
			case 1:
				Surround (Random.Range (10, 50), 5);
				break;
			default:
				Surround (Random.Range (1, 3), 1);
				break;
			}
		}
	}

	public void Surround (int numberOfGroups, int enemiesInGroup)
	{
		Vector2 groupPosition;
		for (int i = 0; i < numberOfGroups; i++) {
			groupPosition = RandomDirection () * Distance () + cameraPosition;
			for (int j = 0; j < Random.Range (1, enemiesInGroup); j++) {
				Factory.create.Enemy (RandomDirection () * Random.Range (0, 2.0f) + groupPosition, Quaternion.identity);
			}
		}
	}

	public void Horde ()
	{
		Vector2 groupPosition = RandomDirection () * Distance () + cameraPosition;
		for (int j = 0; j < hordeSize; j++) {
			Factory.create.Enemy (RandomDirection () * Random.Range (0, 2.0f) + groupPosition, Quaternion.identity);
		}
		hordeSize++;
	}

	static Vector2 RandomDirection ()
	{
		return Random.insideUnitCircle.normalized;
	}

	private float Distance ()
	{
		return minimumDistanceFromPlayer + Random.Range (0, distanceVariance);
	}
}
