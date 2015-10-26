using UnityEngine;
using System.Collections;

public class ExplosiveEnemyBlast : MonoBehaviour
{
	private CircleCollider2D blastCollider;

	void Awake ()
	{
		blastCollider = GetComponent<CircleCollider2D> ();
	}

	void OnEnable ()
	{
		blastCollider.enabled = true;
		Invoke ("DisableCollider", 0.1f);
	}

	private void DisableCollider ()
	{
		blastCollider.enabled = false;
	}
}
