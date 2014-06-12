using UnityEngine;
using System.Collections;

public class HandButton : MonoBehaviour {

	public GameObject baseHand;
	public GameObject hlHand;
	public TextMesh title;

	// Use this for initialization
	void Start () {
		title.renderer.sortingLayerName = "Labels";
		OnMouseUp ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown(){
		Debug.Log ("mouse Down");
		hlHand.renderer.enabled = true;
		baseHand.renderer.enabled = false;
	}
	
	void OnMouseUp(){
		Debug.Log ("mouse Up");
		hlHand.renderer.enabled = false;
		baseHand.renderer.enabled = true;
	}
}
