using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	public GameObject player;
	public float nextLevelTimeout;
	public string nextLevel;
	private bool playerIsAlive = true;

	void Update ()
	{
		if(!player && playerIsAlive) {
			Invoke("PlayerDied", 0);
			Invoke("EndGame", nextLevelTimeout);
			playerIsAlive = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Factory.create.Enemy (new Vector2 (Random.Range (-10, 10), Random.Range (-10, 10)), Quaternion.identity);
		}
	}

	private void PlayerDied() {
		print("Player died!");
	}

	private void EndGame() {
		print("Next scene.");
		Application.LoadLevel(nextLevel);
	}
}
