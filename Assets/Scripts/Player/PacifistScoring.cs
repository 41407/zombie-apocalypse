using UnityEngine;
using System.Collections;

public class PacifistScoring : MonoBehaviour {

	public float pacifistScoreDelay = 5.0f;
	public float pacifistScoreInterval = 0.25f;
	public int pacifistScore = 1;

	void OnEnable ()
	{
		InvokeRepeating ("PacifistScore", pacifistScoreDelay, pacifistScoreInterval);
	}

	void StartFiring ()
	{
		CancelInvoke ();
	}

	void StopFiring ()
	{
		InvokeRepeating ("PacifistScore", pacifistScoreDelay, pacifistScoreInterval);
		pacifistScore = 1;
	}

	void PacifistScore ()
	{
		Score.AddScore (pacifistScore, false);
		if (Score.GetScore () % 13 == 0) {
			pacifistScore++;
		}
	}
}
