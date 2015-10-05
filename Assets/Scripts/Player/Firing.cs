using UnityEngine;
using System.Collections;

public class Firing : MonoBehaviour
{
	public float rateOfFire = 0.08f;
	public GameObject muzzleFlash;
	public float muzzleFlashOffset = 1.0f;
	public float tripleMachineGunTimeout = 30;
	public float tripleMachineGunTimer;

	void Update ()
	{
		if (tripleMachineGunTimer > 0) {
			tripleMachineGunTimer -= Time.deltaTime;
		}
	}

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
		tripleMachineGunTimer = tripleMachineGunTimeout;
	}

	void Fire ()
	{		
		if (tripleMachineGunTimer > 0) {
			ShootBullet (30);
			ShootBullet (5);
			ShootBullet (30);
		} else {
			ShootBullet (5);
		}
	}

	void ShootBullet (float accuracy)
	{
		Quaternion rotation = transform.rotation * Quaternion.AngleAxis (Random.Range (-accuracy, (accuracy != 0 ? accuracy + 1 : 0)), Vector3.forward);
		GameObject bullet = Factory.create.PlayerBullet (transform.position, rotation);
		bullet.SendMessage ("SetVelocity", GetComponent<Rigidbody2D> ().velocity);
		if (muzzleFlash) {
			Factory.create.ByReference (muzzleFlash, transform.position + transform.rotation * Vector2.up * muzzleFlashOffset, transform.rotation);
		}
	}
}
