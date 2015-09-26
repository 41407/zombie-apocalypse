using UnityEngine;
using System.Collections;

public class GivesScore : MonoBehaviour
{
		public int score = 0;

		void ApplyScoring ()
		{
				Score.AddScore (score);
		}
}
