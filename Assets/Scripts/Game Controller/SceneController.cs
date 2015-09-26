using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

	public GameObject player;
	public float nextLevelTimeout;
	public string nextLevel;
	private bool playerIsAlive = true;
	public bool resetScoreOnLevelEnd = false;

	void Update ()
	{
		if (!player && playerIsAlive) {
			Invoke ("PlayerDied", 0);
			Invoke ("EndGame", nextLevelTimeout);
			playerIsAlive = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Factory.create.SimpleEnemy (new Vector2 (Random.Range (-10, 10), Random.Range (-10, 10)), Quaternion.identity);
		}
	}

	private void PlayerDied ()
	{
		print ("Player died!");
	}

	private void EndGame ()
	{
		print ("Next scene.");
		if (resetScoreOnLevelEnd) {
			if (Score.GetScore () > PlayerPrefs.GetInt ("High score")) {
				PlayerPrefs.SetInt ("High score", Score.GetScore ());
			}
			Score.Reset ();
		}
		Application.LoadLevel (nextLevel);
	}
}
