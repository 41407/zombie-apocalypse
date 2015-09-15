using UnityEngine;
using System.Collections;

public class DefaultGun : MonoBehaviour
{
	private bool firing = false;
	private float fireTimer = 0;
	private bool triggerReleased = true;
	public GameObject gunsmoke;

	void Update ()
	{
		fireTimer -= Time.deltaTime;
		if (fireTimer <= 0 && firing) {
			Fire ();
		}
	}

	void StartFiring ()
	{
		firing = true;
		triggerReleased = false;
	}

	void StopFiring ()
	{
		firing = false;
		triggerReleased = true;
	}

	void Fire ()
	{		
		fireTimer = 0.16f;
		ShootBullet (5).SendMessage ("SetDamage", 1);
	}

	GameObject ShootBullet ()
	{
		return ShootBullet (0, 0);
	}
	
	GameObject ShootBullet (float accuracy)
	{
		return ShootBullet (accuracy, 0);
	}

	GameObject ShootBullet (float accuracy, float speed)
	{
		Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-accuracy, (accuracy != 0 ? accuracy + 1 : 0)), Vector3.forward);
		GameObject bullet = Factory.create.PlayerBullet (transform.position, rotation);
		bullet.SendMessage ("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
		bullet.SendMessage ("SetSpeed", speed);
		if (gunsmoke) {
			Factory.create.ByReference (gunsmoke, transform.position, transform.rotation);
		}
		return bullet;
	}
}
