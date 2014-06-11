﻿using UnityEngine;
using System.Collections;

public class ButtonMC : MonoBehaviour {
	public TextMesh title;

	public GameObject onInstance;
	public GameObject offInstance;
	public static Vector3 TITLE_POSITION = new Vector3(0, -0.1116991f, -1f);

	// Use this for initialization
	void Start () {
		Toggle(false);
		title.renderer.sortingLayerName = "Buttons";
		title.renderer.transform.localPosition = TITLE_POSITION;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Toggle(bool overMe){
		if (overMe){
			((SpriteRenderer) onInstance.GetComponent<SpriteRenderer>()).enabled = true;
			((SpriteRenderer) offInstance.GetComponent<SpriteRenderer>()).enabled = false;
			title.renderer.material.color = new Color(1f, 1f, 0.5f);
		} else {
			((SpriteRenderer) onInstance.GetComponent<SpriteRenderer>()).enabled = false;
			((SpriteRenderer) offInstance.GetComponent<SpriteRenderer>()).enabled = true;
			title.renderer.material.color = Color.white;

		}
	}

	void OnMouseEnter(){
		Debug.Log ("over button");
		Toggle(true);
	}

	void OnMouseExit(){
		Debug.Log ("off button");
		Toggle(false);
	}
}