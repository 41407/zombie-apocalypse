using UnityEngine;
using System.Collections;

public class DisableIfChildDisabled : MonoBehaviour
{

	public GameObject child;

	void OnEnable ()
	{
		if (!child) {
			child = transform.GetChild (0).gameObject;
		}
		child.SetActive (true);
	}

	void Update ()
	{
		if (!child.activeSelf) {
			gameObject.SetActive (false);
		}
	}
}
