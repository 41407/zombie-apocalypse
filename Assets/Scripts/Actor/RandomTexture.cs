using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

	public Sprite[] textures;

	void OnEnable () {
		gameObject.GetComponent<SpriteRenderer>().sprite = textures[Random.Range(0, textures.Length)];
	}
}
