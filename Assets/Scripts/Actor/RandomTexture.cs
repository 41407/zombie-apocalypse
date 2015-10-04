using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

	public Texture2D[] textures;

	void OnEnable () {
		gameObject.GetComponent<Renderer>().material.mainTexture = textures[Random.Range(0, textures.Length)];
	}
}
