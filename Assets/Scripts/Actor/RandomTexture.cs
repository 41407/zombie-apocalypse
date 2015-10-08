using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour {

	public Sprite[] textures;
	private SpriteRenderer sr;

	void OnEnable () {
		if(!sr) {
			sr = gameObject.GetComponent<SpriteRenderer>();
		}
		sr.sprite = textures[Random.Range(0, textures.Length)];
	}
}
