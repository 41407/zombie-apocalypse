using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public GameObject player;
	public int hordeSize;
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
			if (waveNumber > 10 && waveNumber < 20) {
				enemySack.Push (EnemyType.Quick);
			}
			if (waveNumber == 20) {
				enemySack.Push (EnemyType.Tough);
			}
			if (waveNumber > 50 && waveNumber < 60) {
				enemySack.Push (EnemyType.Stalking);
				enemySack.Push (EnemyType.Quick);
			}
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
			Surround (Random.Range (
				Mathf.Clamp (waveNumber / 4,
			             2, 10),
				Mathf.Clamp (waveNumber / 2, 10, 60)),
			          Mathf.Clamp (waveNumber / 20,
			             1, 5));
			break;
		case 2:
			Arc (PlayerTravelDirection (),
			     Random.Range (5,
			              Mathf.Clamp (waveNumber / 2,
			             5, 40)));
			break;
		default:
			Surround (
				Random.Range (1,
			              Mathf.Clamp (waveNumber / 3,
			             1, 30)),
				1);
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
		Vector2 direction = PlayerTravelDirection ();
		if (direction.Equals (Vector2.zero)) {
			direction = RandomDirection ();
		}
		Vector2 groupPosition = direction * Distance (5) + cameraPosition;
		bool specialHorde = false;
		EnemyType specialType = (EnemyType)Random.Range (0, 3);
		if (waveNumber > 50 & Random.value < 0.25f) {
			specialHorde = true;
			Factory.create.ExplosiveEnemy (groupPosition, Quaternion.identity);
		}
		for (int j = 0; j < hordeSize; j++) {
			if (specialHorde) {
				Factory.create.ByReference (enemyTypes [(int)specialType], RandomDirection () * Random.Range (0, 5.0f) + groupPosition, Quaternion.identity);
			} else {
				Spawn (RandomDirection () * Random.Range (0, 5.0f) + groupPosition);
			}
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
