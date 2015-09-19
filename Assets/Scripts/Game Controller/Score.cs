using UnityEngine;
using System.Collections;

public static class Score
{
		public static int score = 0;

		public static void Reset ()
		{
				score = 0;
		}

		public static void AddScore ()
		{
				AddScore (1);
		}

		public static void AddScore (int amount)
		{
				score += amount;
		}

		public static int GetScore ()
		{
				return score;
		}
}
