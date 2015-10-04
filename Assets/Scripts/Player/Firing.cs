using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{
	public float rateOfFire = 0.08f;
	public GameObject muzzleFlash;
	public float muzzleFlashOffset = 1.0f;
	public int tripleMachineGunMax = 30;
	public int tripleMachineGunAmmo;

	void StartFiring ()
	{
		InvokeRepeating ("Fire", 0, rateOfFire);
	}

	void StopFiring ()
	{
		CancelInvoke ();
	}

	void TripleMachineGun ()
	{
		tripleMachineGunAmmo = tripleMachineGunMax;
	}

	void Fire ()
	{		
		if (tripleMachineGunAmmo > 0) {
			ShootBullet (30).SendMessage ("SetDamage", 2);
			ShootBullet (5).SendMessage ("SetDamage", 2);
			ShootBullet (30).SendMessage ("SetDamage", 2);
			tripleMachineGunAmmo--;
		} else {
			ShootBullet (5).SendMessage ("SetDamage", 1);
		}
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
