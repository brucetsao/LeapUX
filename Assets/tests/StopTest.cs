using UnityEngine;
using System.Collections;

public class StopTest : GoScene {

	public TestScriptBase testBase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		testBase.Finish();
		Application.LoadLevel(targetSceneName);
	}
}
