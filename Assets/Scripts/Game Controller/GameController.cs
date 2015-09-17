using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Factory.create.Enemy (new Vector2 (Random.Range (-10, 10), Random.Range (-10, 10)), Quaternion.identity);
		}
	}
}
