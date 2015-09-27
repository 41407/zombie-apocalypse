using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	public string staticText = "";
	public Vector3 targetScale = Vector3.one;
	public float scoreUpdateScalingSmoothness = 0.5f;
	public int score = 0;

	void Update ()
	{
		UpdateData ();
		UpdateDisplay ();
	}

	private void UpdateData ()
	{
		int newScore = Score.GetScore ();
		if (newScore > score) {
			transform.localScale = transform.localScale + Vector3.one * (newScore - score);
		}
		score = newScore;
	}

	private void UpdateDisplay ()
	{
		GetComponent<Text> ().text = staticText + " " + score;
		transform.localScale = Vector3.Lerp (transform.localScale, targetScale, scoreUpdateScalingSmoothness);
	}
}
