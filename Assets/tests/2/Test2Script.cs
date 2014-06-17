using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Test2Script : TestScriptBase {

	public GameObject doneButton;
	public ButtonStruct startButton;
	public ButtonLeapEnabled startButtonLE;

	// Use this for initialization
	void Start () {
		InitScript("Test 2 - Goatcraft Leap Motion Controller - V1");

		instructionText.text = "Swipe over the \"Start Test\" button to begin the test";
		iText[0] = "Tap the \"Options\" button to open the configuration screens";
		iText[1] = "Set the Master Volume to 50% (Under \"Music & Sound\")";
		iText[2] = "Very Good! Return to the Configuration home screen by clicking the  \"Done\" button";
		iText[3] = "Now set the \"3D Anaglyph\" to \"on\" in the \"Video Settings\" panel";

		InitLeap();
		startButton = ListenToButton(startButtonLE, "wave", 6.0f, 1f);

	}

	// Update is called once per frame
	void Update () {
		if (leapController != null){
			HoverButtons(leapController.Frame ());
		}
	}

	public void Report(){
		script.Report ();
	}
	
	public override void CheckState(string screen, string button, string value){
		//Debug.Log ("Checking state with screen " + screen + ", button " + button + ", value " + value + ", state " + state.ToString());
		
		script.AddFeedback("screen: " + screen + ", button: " + button + ", value: " + value);

		int oldState = state;
		switch(state){
		case -1:
			if (value == "title" && button == "(opened)"){
				state = 0;
			}
			break;

		case 0: 
			if (value == "main" && button == "(opened)"){
				state = 1;
			}
			break;
		case 1:
			if (screen == "music" && button == "Master Volume" && value == "50"){
				state = 2;
			}
			break;
		case 2 :
			if(value == "title" && button == "(opened)"){
				state = 3;
			}
			break;

		case 3: 
			if (button == "3D Anaglyph:" ){
				if (value == "ON"){
					state = 4;
				}
			}

			break;

		case 4:
			
			if (value == "title" && button == "(opened)"){
				state = 5;
				doneButton.SetActive(true);
			}


			break;
		}
		
		if (oldState != state){
			script.AddFeedback("State changed to " + state);
			instructionText.text = iText[state];

		}
	}
}
