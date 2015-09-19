using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour
{
	void Update ()
	{
		string comparator = "<";
		if (Score.GetScore () == PlayerPrefs.GetInt ("High score")) {
			comparator = "=";
		} else if (Score.GetScore () > PlayerPrefs.GetInt ("High score")) {
			comparator = ">";
		}
		GetComponent<Text> ().text = Score.GetScore () + " " + comparator + " " + PlayerPrefs.GetInt ("High score");
	}
}
