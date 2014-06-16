using UnityEngine;
using System.Collections;

/**
 * A ButtonLeapEnabled is "registered" with a leapMotionController enabled Controller.
 * As it is the controller, not the button, that determines functionality, 
 * the only functionality delivered here is to properly layer the label
 * and to change the appearance when hovered. 
 */

public class ButtonLeapEnabled : MonoBehaviour {

	public GameObject onInstance; // the sprite that should show on hover/use
	public GameObject offInstance; // the sprite that shows by default (on not hover/use);
	public static Vector3 TITLE_POSITION = new Vector3(0, -0.1116991f, -1f);
	public TextMesh title;
	public string titleSortingLayer = "Buttons";
	public Color textColor = new Color(1f,1f,1f);
	public Color textColorHover = new Color(1f,1f,1f);

	// Use this for initialization
	void Start () {
		Hover(false);
		title.renderer.sortingLayerName = titleSortingLayer;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// flips the backgrounds on rollover/out
	public void Hover(bool overMe){
		if (overMe){
			((SpriteRenderer) onInstance.GetComponent<SpriteRenderer>()).enabled = true;
			((SpriteRenderer) offInstance.GetComponent<SpriteRenderer>()).enabled = false;
			title.renderer.material.color = textColorHover;
		} else {
			((SpriteRenderer) onInstance.GetComponent<SpriteRenderer>()).enabled = false;
			((SpriteRenderer) offInstance.GetComponent<SpriteRenderer>()).enabled = true;
			title.renderer.material.color = textColor;

		}
	}

}
