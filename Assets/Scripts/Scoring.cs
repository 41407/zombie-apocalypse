using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour
{
		public int scoreOnDeath = 0;

		void ApplyScoring ()
		{
				Score.AddScore (scoreOnDeath);
		}
}
