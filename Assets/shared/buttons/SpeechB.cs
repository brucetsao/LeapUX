using UnityEngine;
using System.Collections;

/**
 * This class manages an info popout; something wherein the info layer is toggled on click. 
 * 
 * Note that this script is applied to the info group as a whole which includes the trigger button 
 * and the popup layer, and is also applied to the popup layer so that clicking it also toggles the
 * parent. 
 * 
 * When applied to the popup layer, 
 * the parent is set to the group (which should have its own
 * SpeechB) to delegate action to that parent's OnMouseDown handler. 
 */

public class SpeechB : MonoBehaviour {
	public GameObject balloon; // the subgroup that contains the text and the background layer
	public SpeechB parent; // when applied to the background layer, set this to the info group as a whole

	public GameObject background;
	public GameObject text;
	public string backgroundLayer = "DoneButton";
	public string textLayer = "Labels";
	bool add = false;
	
	// Use this for initialization
	void Start () {
		if (parent != null){
			return;
		}
		background.renderer.sortingLayerName = backgroundLayer;
		text.renderer.sortingLayerName = textLayer;
		balloon.SetActive(false);
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
