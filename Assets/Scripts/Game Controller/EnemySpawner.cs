using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public GameObject player;
	public int hordeSize;
	public int hordeSizeExplosiveThreshold = 10;
	public float hordeExplosiveChance = 0.25f;
	public float spawnInterval = 0.5f;
	public float minimumDistanceFromPlayer = 5.0f;
	public float distanceVariance = 5.0f;
	private Vector2 cameraPosition;
	public List<GameObject> enemyTypes;

	void OnEnable ()
	{
		InvokeRepeating ("Spawn", spawnInterval, spawnInterval);
	}

	public void Spawn ()
	{
		if (GetComponent<SceneController> ().player) {
			cameraPosition = Camera.main.transform.position;
			Arc (PlayerTravelDirection (), Random.Range (1, PlayerDirectionStagnation ()));
			Formation ();
		}
	}

	void Formation ()
	{
		int formation = Random.Range (0, 10);
		switch (formation) {
		case 0:
			Horde ();
			break;
		case 1:
			Surround (Random.Range (10, 50), 5);
			break;
		case 2:
			Arc (PlayerTravelDirection (), Random.Range (10, 20));
			break;
		default:
			Surround (Random.Range (1, 20), 1);
			break;
		}
	}

	private void Arc (Vector2 direction, int numberOfEnemies)
	{
		Vector2 groupPosition = direction * Distance () + cameraPosition;
		groupPosition = Quaternion.AngleAxis (-numberOfEnemies / 2, Vector3.back) * groupPosition;
		for (int i = 0; i < numberOfEnemies; i++) {
			CreateFromList (groupPosition);
			groupPosition = Quaternion.AngleAxis (1, Vector3.back) * groupPosition;
		}
	}

	private void Surround (int numberOfGroups, int enemiesInEachGroup)
	{
		Vector2 groupPosition;
		for (int i = 0; i < numberOfGroups; i++) {
			groupPosition = RandomDirection () * Distance () + cameraPosition;
			for (int j = 0; j < Random.Range (1, enemiesInEachGroup); j++) {
				CreateFromList (RandomDirection () * Random.Range (0, 2.0f) + groupPosition);
			}
		}
	}

	private void Horde ()
	{
		Vector2 groupPosition = RandomDirection () * Distance (5) + cameraPosition;
		if (hordeSize > hordeSizeExplosiveThreshold && Random.value <= hordeExplosiveChance) {
			Factory.create.ExplosiveEnemy (groupPosition, Quaternion.identity);
		}
		for (int j = 0; j < hordeSize; j++) {
			CreateFromList (RandomDirection () * Random.Range (0, 5.0f) + groupPosition);
		}
		hordeSize++;
	}

	private void CreateFromList (Vector2 position)
	{
		Factory.create.ByReference (enemyTypes [Random.Range (0, enemyTypes.Count)], position, Quaternion.identity);
	}

	private Vector2 RandomDirection ()
	{
		return Random.insideUnitCircle.normalized;
	}
	
	private float Distance ()
	{
		return Distance (0);
	}

	private float Distance (float additionalDistance)
	{
		return minimumDistanceFromPlayer + Random.Range (additionalDistance, distanceVariance);
	}

	private Vector2 PlayerTravelDirection ()
	{
		return player.GetComponent<PlayerMovementTracker> ().GetDirection ();
	}

	private int PlayerDirectionStagnation ()
	{
		return player.GetComponent<PlayerMovementTracker> ().GetStagnation ();
	}
}
