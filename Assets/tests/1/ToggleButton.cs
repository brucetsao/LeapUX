using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToggleButton : MonoBehaviour {

	public List<string> options = new List<string>();
	public string prefix = "";
	public int currentStringIndex = 0;
	public TextMesh title;
	public bool binary = false;
	static List<string> binaryOptions = new List<string>(){"ON", "OFF"};
	public int OFF_INDEX = 1;
	public int ONN_INDEX = 0;
	public TestScriptBase testScript;
	public string screen;

	// Use this for initialization
	void Start () {
		if (binary) options = binaryOptions;
		SetTitle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetTitle(){
		string option = options[currentStringIndex];
		title.text = prefix + " " + option;
		if (testScript != null){
			testScript.CheckState (screen, prefix, option);
		} else {
			//Debug.Log ("BUTTON HAS NO testScript: " + prefix);
		}
	}

	void OnMouseDown(){
		currentStringIndex = (1 + currentStringIndex) % options.Count;
		SetTitle();
	}		                      
}
