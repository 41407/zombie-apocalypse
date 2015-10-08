using UnityEngine;
using System.Collections;

public class ExplosiveEnemyBlast : MonoBehaviour
{
	private CircleCollider2D blastCollider;

	void OnEnable ()
	{
		if (!blastCollider) {
			blastCollider = gameObject.GetComponent<CircleCollider2D> ();
		}
		blastCollider.enabled = true;
		Invoke ("DisableCollider", 0.1f);
	}

	private void DisableCollider ()
	{
		blastCollider.enabled = false;
	}
}
