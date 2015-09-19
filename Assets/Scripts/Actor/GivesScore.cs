using UnityEngine;
using System.Collections;

public class GivesScore : MonoBehaviour
{
		public int scoreOnDeath = 0;

		void ApplyScoring ()
		{
				Score.AddScore (scoreOnDeath);
		}
}
