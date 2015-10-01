using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  This is a data structure that contains an array which holds EnemyTypes.
 *  It can be:
 *    - popped, which returns random EnemyType without removing it from the array
 *    - pushed into, which adds that EnemyType into the array.
 */

public class Sack : MonoBehaviour
{
	[System.Serializable]
	public struct EnemyAmount
	{
		public EnemyType type;
		public int amount;
	}
 
	public EnemyAmount[] initialEnemies;
	public List<EnemyType> sack;

	void OnEnable ()
	{
		InitializeSack ();
	}

	private void InitializeSack ()
	{ 
		sack = new List<EnemyType> ();
		foreach (EnemyAmount e in initialEnemies) {
			for (int i = 0; i < e.amount; i++) {
				sack.Add (e.type);
			}
		}
	}
	
	public EnemyType Pop ()
	{
		return sack [Random.Range (0, sack.Count)];
	}

	public void Push (EnemyType newType)
	{
		sack.Add (newType);
	}
}
