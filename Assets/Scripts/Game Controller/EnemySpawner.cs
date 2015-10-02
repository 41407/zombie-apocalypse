using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public GameObject player;
	public int hordeSize;
	public int hordeSizeExplosiveThreshold = 10;
	public float hordeExplosiveChance = 0.5f;
	public float spawnInterval = 0.75f;
	public float minimumDistanceFromPlayer = 5.0f;
	public float distanceVariance = 5.0f;
	public int waveNumber = 0;
	private Vector2 cameraPosition;
	public List<GameObject> enemyTypes;
	private Sack enemySack;

	void OnEnable ()
	{
		InvokeRepeating ("GenerateEnemies", spawnInterval, spawnInterval);
		enemySack = gameObject.GetComponent<Sack> ();
	}

	private void GenerateEnemies ()
	{
		cameraPosition = Camera.main.transform.position;
		if (GetComponent<SceneController> ().player) {
			waveNumber++;
			Arc (PlayerTravelDirection (), Random.Range (PlayerDirectionStagnation (), PlayerDirectionStagnation () * 2));
			RandomFormation ();
		}
	}

	private void RandomFormation ()
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
		if (!direction.Equals (Vector2.zero)) {
			Vector2 groupPosition = direction * Distance () + cameraPosition;
			for (int i = 0; i < numberOfEnemies; i++) {
				Spawn (groupPosition + Random.insideUnitCircle * 2.0f);
			}
		}
	}

	private void Surround (int numberOfGroups, int enemiesInEachGroup)
	{
		Vector2 groupPosition;
		for (int i = 0; i < numberOfGroups; i++) {
			groupPosition = RandomDirection () * Distance (3) + cameraPosition;
			for (int j = 0; j < Random.Range (1, enemiesInEachGroup); j++) {
				Spawn (RandomDirection () * Random.Range (0, 2.0f) + groupPosition);
			}
		}
	}

	private void Horde ()
	{
		Vector2 groupPosition = PlayerTravelDirection () * Distance (5) + cameraPosition;
		if (hordeSize > hordeSizeExplosiveThreshold && Random.value <= hordeExplosiveChance) {
			Factory.create.ExplosiveEnemy (groupPosition, Quaternion.identity);
		}
		for (int j = 0; j < hordeSize; j++) {
			Spawn (RandomDirection () * Random.Range (0, 5.0f) + groupPosition);
		}
		hordeSize++;
	}

	private void Spawn (Vector2 position)
	{
		Factory.create.ByReference (enemyTypes [(int)enemySack.Pop ()], position, Quaternion.identity);
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
