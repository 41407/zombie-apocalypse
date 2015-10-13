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
		if (anyKey && (Input.anyKeyDown || Input.GetMouseButtonDown (0))) {
			EndGame ();
		}
	}

	private void PlayerDied ()
	{
	}

	void EndGame ()
	{
		StartCoroutine (LoadNextLevel ());
	}

	IEnumerator LoadNextLevel ()
	{
		if (resetScoreOnLevelEnd) {
			if (Score.GetScore () > PlayerPrefs.GetInt ("High score")) {
				PlayerPrefs.SetInt ("High score", Score.GetScore ());
			}
			Score.Reset ();
		}
		AsyncOperation async = Application.LoadLevelAsync (nextLevel);
		Debug.Log ("Loading next scene.");
		yield return async;
	}

	private void AnyKey ()
	{
		anyKey = true;
	}
}
