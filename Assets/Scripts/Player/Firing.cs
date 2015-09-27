using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{
	private bool firing = false;
	private float fireTimer = 0;
	public float rateOfFire = 0.08f;
	public GameObject muzzleFlash;
	public float muzzleFlashOffset = 1.0f;

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
	}

	void StopFiring ()
	{
		firing = false;
	}

	void Fire ()
	{		
		fireTimer = rateOfFire;
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
		if (muzzleFlash) {
			Factory.create.ByReference (muzzleFlash, transform.position + transform.rotation * Vector2.up * muzzleFlashOffset, transform.rotation);
		}
		return bullet;
	}
}
