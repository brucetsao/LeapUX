using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

/**
 * A single mouse interaction with a widget
 * Originally designed for the Minecraft sim where screen is a control panel
 * and button is the targeted widget name.
 */

public struct ClickStruct
{
		public string screen;
		public string button;
		public string value;

		public ClickStruct (string s, string b)
		{
				screen = s;
				button = b;
				value = "";
		}
	
		public ClickStruct (string s, string b, string v)
		{
				screen = s;
				button = b;
				value = v;

		}
}


/**
 * this struct records an imperitave to start managing a button via the Leap controller cycle. 
 */

public struct ButtonStruct
{
		public ButtonLeapEnabled button;
		public string gesture;
		public bool active;
		public float width;
		public float height;

		public ButtonStruct (ButtonLeapEnabled b, string g, float w, float h)
		{
				button = b;
				gesture = g;
				active = true;
				width = w;
				height = h;
		}
}

/**
 * This class is the basis for scripts for scenes used as test contexts.
 * It manages logs and leap gestures. 
 * 
 * It has an indepenant history of clicks -- basically recorded hits on
 * buttons and other UX widgets. 
 * 
 * By default this list is echoed in the log.
 * 
 */

public abstract class TestScriptBase : MonoBehaviour
{
	
		protected TestScript script;
		public string testName;
		public List<ClickStruct> clicks = new List<ClickStruct> ();
		bool done = false;
		int _state = -1;
		public List<string> iText = new List<string> ();
		public Controller leapController;
		public GameObject cursorGraphic;
		public TextMesh instructionText;
		protected int state = -1;
		List<string> legalGestures = new List<string>{"wave", "tap"};
		List<ButtonStruct> leapButtons;
		Vector2 leapCursorPosition;
		public Camera orthoCamera;
	
		// Use this for initialization
		void Start ()
		{
				// NOTE : MUST OVERRIDE to initialize script. 
				// SHOULD include InitLeap();
		}
	
		/**
		 * Update is called once per frame
		 * 
		 * When you write a subclass, 
		 * if you have buttons 
		 * you will want to call SetLeapCursorPosition and  hoverButtons inside your Update method.
		 */

		void Update ()
		{
				// NOTE : MUST OVERRIDE to initialize script. 
				// SHOULD INCLUDE SetCursorPosition();
				// PROBABLY SHOULD INCLUDE HoverButtons();
		}

		public void InitLeap ()
		{
				leapController = new Controller ();
				leapButtons = new List<ButtonStruct> ();
		}

		public void InitScript (string testName)
		{
				script = new TestScript (testName);
		}

		public ButtonStruct ListenToButton (ButtonLeapEnabled button)
		{
				return ListenToButton (button, "wave", 3.0f, 0.4f);
		}

		public bool SetLeapCursorPosition (Frame leapFrame)
		{
				Hand fmh = LeapUtils.FrontHand (leapFrame);
				if (!fmh.IsValid) {
						return false;
				}

				leapCursorPosition = LeapUtils.ToVector2 (fmh, true);
				leapCursorPosition.x *= orthoCamera.orthographicSize;
				leapCursorPosition.x -= orthoCamera.orthographicSize / 2;
				float ySize = orthoCamera.orthographicSize * orthoCamera.aspect;
				leapCursorPosition.y *= ySize;
				leapCursorPosition.y -= ySize / 2;

				if (cursorGraphic != null) {
						cursorGraphic.transform.position = new Vector3 (leapCursorPosition.x, leapCursorPosition.y, 0);
				}

				return true;
		}

		public void HoverButtons (Frame leapFrame)
		{
				//@TODO: purge inactive buttons from list

				if (!SetLeapCursorPosition (leapFrame)) {
						return;
				}

				Vector3 cursorPos = new Vector3 (cursorGraphic.transform.position.x, cursorGraphic.transform.position.y, 0);

				foreach (ButtonStruct b in leapButtons) {
						Vector3 cursorRel = cursorPos - b.button.transform.position;
						cursorRel.y *= -1;


						if ((cursorRel.x >= 0) && (cursorRel.x <= b.width) && (cursorRel.y >= 0) && (cursorRel.y <= b.height)) {
								b.button.Hover (true);

								switch (b.gesture) {
								case "wave": 
										b.button.AddWave (true, cursorRel);
										break;

								}


						} else {
								b.button.Hover (false);
								switch (b.gesture) {
								case "wave":
										b.button.AddWave (false);
										break;
								}
						}
				}
		}

		void TestGesture (string gesture)
		{
				foreach (string g in legalGestures) {
						if (gesture.Equals (g)) {
								return;
						}
				}

				throw new UnityException ("Cannot find match for gesture " + gesture);
		}

		public ButtonStruct ListenToButton (ButtonLeapEnabled button, string gesture, float w, float h)
		{
				TestGesture (gesture);

				ButtonStruct bs = new ButtonStruct (button, gesture, w, h);
				leapButtons.Add (bs);
				return bs;
		}

		public void AddClick (string s, string b)
		{
				if (done) {
						throw new UnityException ("tried to add a click to a done test");
				}
				clicks.Add (new ClickStruct (s, b));
				script.AddFeedback ("click " + s + ":" + b);

				CheckState (s, b, "");
		}
	
		public void AddClick (string s, string b, string v)
		{
				if (done) {
						throw new UnityException ("tried to add a click to a done test");
				}
				clicks.Add (new ClickStruct (s, b, v));
				script.AddFeedback ("click " + s + ":" + b + "=" + v);
				CheckState (s, b, v);
		}
	
		public void Finish ()
		{
				if (!done) {
						script.Report ();
						done = true;
				}
		}

		public abstract void CheckState (string screen, string button, string value);
}
