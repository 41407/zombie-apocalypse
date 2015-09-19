using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	public string staticText = "";

	void Update ()
	{
		GetComponent<Text> ().text = staticText + " " + Score.GetScore ();
	}
}
