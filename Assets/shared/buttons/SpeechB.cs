using UnityEngine;
using System.Collections;

public class SpeechB : MonoBehaviour {
	public GameObject balloon;
	public SpeechB parent;
	public GameObject background;
	public GameObject text;
	bool add = false;
	
	// Use this for initialization
	void Start () {
		if (parent != null){
			return;
		}
		balloon.SetActive(false);
		background.renderer.sortingLayerName = "DoneButton";
		text.renderer.sortingLayerName = "Labels";
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void OnMouseDown(){
		if (parent != null){
			parent.OnMouseDown();
			return;
		}
		add = !add;
		balloon.SetActive(add);
	}
}
