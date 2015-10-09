using UnityEngine;
using System.Collections;

public static class Score
{
	public static int score = 0;
	public static bool isViolent = true;

	public static void Reset ()
	{
		score = 0;
	}

	public static void AddScore ()
	{
		AddScore (1, true);
	}
	
	public static void AddScore (int amount)
	{
		AddScore (amount, true);
	}

	public static void AddScore (int amount, bool violent)
	{
		score += amount;
		isViolent = violent;
	}

	public static int GetScore ()
	{
		return score;
	}

	public static bool IsViolent ()
	{
		return isViolent;
	}
}
