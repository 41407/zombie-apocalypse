using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour
{
	public GameObject player;
	public GameObject playerBullet;
	public GameObject enemy;
	public GameObject spawner;
	public GameObject machineGun;
	public GameObject shotgun;
	public GameObject revolver;

	//Here is a private reference only this class can access
	private static Factory _instance;
	
	//This is the public reference that other classes will use
	public static Factory create {
		get {
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<Factory> ();
			return _instance;
		}
	}

	GameObject InitializeParameters (GameObject created)
	{
		created.SetActive (true);
		created.SendMessage ("SetPlayer", player, SendMessageOptions.DontRequireReceiver);
		return created;
	}

	public GameObject ByReference (GameObject gameObject, Vector2 position, Quaternion rotation)
	{
		return InitializeParameters (ObjectPool.pool.Pull (gameObject, position, rotation));
	}
	
	public GameObject PlayerBullet (Vector2 position, Quaternion rotation)
	{
		return ByReference (playerBullet, position, rotation);
	}
	
	public GameObject Enemy (Vector2 position, Quaternion rotation)
	{
		return ByReference (enemy, position, rotation);
	}
	
	public GameObject Spawner (Vector2 position, Quaternion rotation)
	{
		return ByReference (spawner, position, rotation);
	}

	public GameObject Revolver (Vector2 position, Quaternion rotation)
	{
		return ByReference (revolver, position, rotation);
	}

	public GameObject MachineGun (Vector2 position, Quaternion rotation)
	{
		return ByReference (machineGun, position, rotation);
	}

	public GameObject Shotgun (Vector2 position, Quaternion rotation)
	{
		return ByReference (shotgun, position, rotation);
	}
}
