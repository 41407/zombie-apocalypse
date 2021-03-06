﻿using UnityEngine;
using System.Collections;

public class SpritePulsate : MonoBehaviour
{

	public Color a;
	public Color b;
	public float lerpRate = 0.1f;
	public float frequency = 1.0f;
	private SpriteRenderer rend;

	void Awake ()
	{
		rend = GetComponent<SpriteRenderer> ();			
	}

	void OnEnable ()
	{
		InvokeRepeating ("SwapColors", frequency, frequency);
	}

	void Update ()
	{
		rend.color = Color.Lerp (rend.color, b, lerpRate);
	}

	void SwapColors ()
	{
		Color c = a;
		a = b;
		b = c;
	}

	void OnDisable ()
	{
		CancelInvoke ();
	}
}
