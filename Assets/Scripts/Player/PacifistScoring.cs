using UnityEngine;
using System.Collections;

public class PacifistScoring : MonoBehaviour
{

	public float pacifistScoreDelay = 5.0f;
	public float pacifistScoreInterval = 0.25f;
	public int pacifistScore = 1;

	void OnEnable ()
	{
		StartScoring ();
	}

	public void PlayerWasViolent ()
	{
		StartScoring ();
	}

	void StartFiring ()
	{
		CancelInvoke ();
	}

	void StopFiring ()
	{
		StartScoring ();
	}

	void StartScoring ()
	{
		pacifistScore = 1;
		InvokeRepeating ("PacifistScore", pacifistScoreDelay, pacifistScoreInterval);
	}

	void PacifistScore ()
	{
		// This is absolutely magic numbered
		Score.AddScore (pacifistScore, false);
		if (Score.GetScore () % 13 == 0) {
			pacifistScore++;
		}
	}
}
