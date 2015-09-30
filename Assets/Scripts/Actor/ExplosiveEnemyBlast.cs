using UnityEngine;
using System.Collections;

public class ExplosiveEnemyBlast : MonoBehaviour
{
	void OnEnable ()
	{
		gameObject.GetComponent<CircleCollider2D> ().enabled = true;
		Invoke ("DisableCollider", 0.1f);
	}

	private void DisableCollider ()
	{
		gameObject.GetComponent<CircleCollider2D> ().enabled = false;
	}
}
