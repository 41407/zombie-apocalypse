using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour
{
	public GameObject player;
	public GameObject simpleEnemy;
	public GameObject toughEnemy;
	public GameObject playerBullet;

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

	void OnEnable() {
		ObjectPool.pool.Initialize (simpleEnemy, 200);
		ObjectPool.pool.Initialize (toughEnemy, 200);
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
	
	public GameObject SimpleEnemy (Vector2 position, Quaternion rotation)
	{
		return ByReference (simpleEnemy, position, rotation);
	}
	
	public GameObject ToughEnemy (Vector2 position, Quaternion rotation)
	{
		return ByReference (simpleEnemy, position, rotation);
	}

	public GameObject PlayerBullet (Vector2 position, Quaternion rotation)
	{
		return ByReference (playerBullet, position, rotation);
	}
}