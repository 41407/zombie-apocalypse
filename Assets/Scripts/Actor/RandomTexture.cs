using UnityEngine;
using System.Collections;

public class RandomTexture : MonoBehaviour
{
	public Sprite[] textures;
	private SpriteRenderer sr;

	void Awake ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

	void OnEnable ()
	{
		sr.sprite = textures [Random.Range (0, textures.Length)];
	}
}
