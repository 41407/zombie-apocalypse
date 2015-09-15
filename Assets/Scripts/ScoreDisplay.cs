using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	private Text text;

	void OnEnable ()
	{
		text = GetComponent<Text> ();
	}

	void Update ()
	{
		text.text = "" + Score.score;
	}
}
