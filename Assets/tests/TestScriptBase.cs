using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * A single mouse interaction with a widget
 * Originally designed for the Minecraft sim where screen is a control panel
 * and button is the targeted widget name.
 */

public struct ClickStruct {
	public string screen;
	public string button;
	public string value;
	
	public ClickStruct (string s, string b){
		screen = s;
		button = b;
		value = "";
	}
	
	public ClickStruct (string s, string b, string v){
		screen = s;
		button = b;
		value = v;
	}
}

/**
 * This class is the basis for any mono's that need a log. 
 * It has an indepenant history of clicks -- basically recorded hits on
 * buttons and other UX widgets. 
 * 
 */

public abstract class TestScriptBase : MonoBehaviour {
	
	protected TestScript script;
	public string testName;
	public List<ClickStruct> clicks = new List<ClickStruct>();
	bool done = false;
	int _state = -1;
	public List<string> iText = new List<string>();
	
	public TextMesh instructionText;
	protected int state = -1;
	
	// Use this for initialization
	void Start () {
		InitScript();
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void InitScript(){
		script = new TestScript(testName);
	}
	
	public void AddClick(string s, string b){
		if (done){
			throw new UnityException("tried to add a click to a done test");
		}
		clicks.Add(new ClickStruct(s, b));
		script.AddFeedback("click " + s + ":" + b);

		CheckState(s, b, "");
	}
	
	public void AddClick(string s, string b, string v){
		if (done){
			throw new UnityException("tried to add a click to a done test");
		}
		clicks.Add(new ClickStruct(s, b, v));
		script.AddFeedback("click " + s + ":" + b + "=" + v);
		CheckState(s, b, v);
	}
	
	public void Finish(){
		if (!done){
			script.Report ();
			done = true;
		}
	}

	public abstract void CheckState(string screen, string button, string value);
}
