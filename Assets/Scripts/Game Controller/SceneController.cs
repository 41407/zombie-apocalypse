using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

	public GameObject player;
	public float nextLevelTimeout;
	public string nextLevel;
	private bool playerIsAlive = true;
	public bool resetScoreOnLevelEnd = false;
	public float anyKeyToContinueTime = 2.0f;
	private bool anyKey = false;

	void Update ()
	{
		if (!player && playerIsAlive) {
			Invoke ("PlayerDied", 0);
			Invoke ("EndGame", nextLevelTimeout);
			Invoke ("AnyKey", anyKeyToContinueTime);
			playerIsAlive = false;
		}
		if (anyKey && (Input.anyKeyDown || Input.GetMouseButtonDown(0))) {
			EndGame ();
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
		Application.LoadLevelAsync (nextLevel);
	}

	private void AnyKey ()
	{
		anyKey = true;
	}
}
