using UnityEngine;
using System.Collections;

public class PlayerMovementTracker : MonoBehaviour
{
	public float sampleRate = 2.0f;
	private int directionStagnation = 0;
	public float stagnationThreshold = 0.25f;
	private Vector2 shortTermGeneralDirection = Vector2.one;
	private Vector2 lastPosition;

	void OnEnable ()
	{
		lastPosition = Position ();
		InvokeRepeating ("UpdateGeneralDirection", 0.0f, sampleRate);
	}

	public Vector2 GetDirection ()
	{
		return shortTermGeneralDirection.normalized;
	}

	public int GetStagnation ()
	{
		return directionStagnation;
	}

	private Vector2 Position ()
	{
		return transform.position;
	}

	private void UpdateGeneralDirection ()
	{
		Vector2 lastGeneralDirection = shortTermGeneralDirection;
		shortTermGeneralDirection = (Position () - lastPosition).normalized;
		if (Vector2.Distance (lastGeneralDirection, shortTermGeneralDirection) < stagnationThreshold) {
			directionStagnation++;
		} else {
			directionStagnation = 0;
		}
		lastPosition = Position ();
	}
}
