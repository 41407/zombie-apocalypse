using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugDisplay : MonoBehaviour
{
	void Update ()
	{
		GetComponent<Text> ().text = "Number of enemies: " + GameObject.FindGameObjectsWithTag ("Enemy").Length;
	}
}