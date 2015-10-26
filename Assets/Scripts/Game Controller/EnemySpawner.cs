using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public GameObject player;
	private int hordeSize = 11;
	public float minimumDistanceFromPlayer = 5.0f;
	public float distanceVariance = 5.0f;
	public float spawnInterval = 0.75f;
	public int pauseInterval = 30;
	public float pauseDuration = 2.0f;
	public int waveNumber = 0;
	private Vector2 cameraPosition;
	public List<GameObject> enemyTypes;
	private Sack enemySack;
	private bool paused = false;

	void OnEnable ()
	{
		InvokeRepeating ("GenerateEnemies", spawnInterval, spawnInterval);
		enemySack = gameObject.GetComponent<Sack> ();
	}

	void Pause (float time)
	{
		paused = true;
		CancelInvoke ();
		Invoke ("Resume", time);
	}
	
	void Ambush ()
	{
		cameraPosition = Camera.main.transform.position;
		Surround (20, 10);
		Explosive ();
	}

	void Resume ()
	{
		paused = false;
		InvokeRepeating ("GenerateEnemies", spawnInterval, spawnInterval);
	}

	private void GenerateEnemies ()
	{
		Debug.Log ("Wave " + waveNumber, this);
		if (!paused) {
			cameraPosition = Camera.main.transform.position;
			if (GetComponent<SceneController> ().player) {
				waveNumber++;
				Arc (PlayerTravelDirection (), Mathf.Clamp (Random.Range (PlayerDirectionStagnation (), PlayerDirectionStagnation () * 2), 1, waveNumber));
				RandomFormation ();
				if (waveNumber % pauseInterval == 0) {
					Pause (pauseDuration);
				}
				if (waveNumber == 20) {
					enemySack.Push (EnemyType.Quick);
				}
				if (waveNumber == 30) {
					enemySack.Push (EnemyType.Tough);
				}
				if (waveNumber > 60 && waveNumber < 65) {
					enemySack.Push (EnemyType.Stalking);
					enemySack.Push (EnemyType.Simple);
				}
				if (waveNumber > 90 && waveNumber < 95) {
					enemySack.Push (EnemyType.Stalking);
					enemySack.Push (EnemyType.Quick);
				}
				if (waveNumber > 95 && waveNumber < 100) {
					enemySack.Push (EnemyType.Quick);
				}
				if (waveNumber > 100 && waveNumber < 110) {
					enemySack.Push (EnemyType.Simple);
				}
				GeneratePowerup ();
			}
		}
	}

	private void GeneratePowerup ()
	{
		if (!GameObject.FindGameObjectWithTag ("Power up") && waveNumber > 40 && player.GetComponent<Firing> ().tripleMachineGunTimer <= 1) {
			float spawnDistance = Mathf.Clamp((waveNumber - 40) * 1.5f, 0, 80);
			Factory.create.Powerup (cameraPosition + RandomDirection () * Distance (spawnDistance), Quaternion.identity);
		}
	}

	private void RandomFormation ()
	{
		int formation = Random.Range (0, 6);
		switch (formation) {
		case 0:
			Horde ();
			break;
		case 1:
			Surround (Random.Range (
					Mathf.Clamp (waveNumber / 20,
				             2, 10),
					Mathf.Clamp (waveNumber / 10,
			             10, 60)),
			    Mathf.Clamp (waveNumber / 40,
			             1, 5));
			break;
		case 2:
			Arc (PlayerTravelDirection (),
			     Random.Range (5,
			              Mathf.Clamp (waveNumber / 4,
			             5, 40)));
			break;
		default:
			Surround (
				Random.Range (1,
			              Mathf.Clamp (waveNumber / 9,
			             1, 30)),
				1);
			break;
		}
	}

	private void Arc (Vector2 direction, int numberOfEnemies)
	{
		if (!direction.Equals (Vector2.zero)) {
			Vector2 groupPosition = direction * Distance () + cameraPosition;
			Vector2 normal = Quaternion.AngleAxis (90, Vector3.forward) * direction;
			for (int i = 0; i < numberOfEnemies; i++) {
				Spawn (groupPosition + Random.insideUnitCircle * 2.0f + normal * Random.Range (-12, 12));
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
		EnemyType specialType = (EnemyType)Random.Range (0, 4);
		if (waveNumber > 50 & Random.value < 0.75f) {
			specialHorde = true;
			if (GameObject.FindGameObjectsWithTag ("Explosive Enemy").Length < 1) {
				Factory.create.ExplosiveEnemy (groupPosition, Quaternion.identity);
			}
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
	
	private void Explosive ()
	{
		Vector2 position = RandomDirection () * Distance (3) + cameraPosition;
		Factory.create.ExplosiveEnemy (position, Quaternion.identity);
	
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
		return minimumDistanceFromPlayer + Random.Range (additionalDistance, additionalDistance + distanceVariance);
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
